﻿namespace MiniORMLive
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using CustomORM.Core;
    using MiniORMLive.Attributes;

    class EntityManager : IDbContext
    {
        private SqlConnection connection;
        private string connectionString;
        private bool isCodeFirst;

        public EntityManager(string connectionString, bool isCodeFirst)
        {
            this.connectionString = connectionString;
            this.isCodeFirst = isCodeFirst;
        }

        public bool Persist(object entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Cannot persist null entity");
            }

            if (isCodeFirst && !CheckIfTableExists(entity.GetType()))
            {
                this.CreateTable(entity.GetType());
            }

            Type entityType = entity.GetType();
            FieldInfo idInfo = GetId(entityType);
            int id = (int)idInfo.GetValue(entity);

            if (id <= 0)
            {
                return this.Insert(entity, idInfo);
            }

            return this.Update(entity, idInfo);
        }

        private bool Update(object entity, FieldInfo idInfo)
        {
            int numberOfAffectedRows = 0;

            string updateString = this.PrepareEntityUpdateString(entity, idInfo);

            using (connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand updateCommand = new SqlCommand(updateString, connection);

                numberOfAffectedRows = updateCommand.ExecuteNonQuery();
            }

            return numberOfAffectedRows > 0;
        }

        private bool Insert(object entity, FieldInfo idInfo)
        {
            int numberOfAffectedRows = 0;

            string insertionString = this.PrepareEntityInsertonString(entity);

            using (connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand insertionCommand = new SqlCommand(insertionString, connection);

                numberOfAffectedRows = insertionCommand.ExecuteNonQuery();

                string sqlQuery = $"Selelct max(id) from {this.GetTableName(entity.GetType())}";
                SqlCommand queryCommand = new SqlCommand(sqlQuery, connection);
                int id = (int)queryCommand.ExecuteScalar();

                idInfo.SetValue(entity, id);
            }

            return numberOfAffectedRows > 0;
        }

        private string PrepareEntityUpdateString(object entity, FieldInfo idInfo)
        {
            StringBuilder updateStringBuilder = new StringBuilder();
            StringBuilder setStringBuilder = new StringBuilder();

            updateStringBuilder.Append($"Update {GetTableName(entity.GetType())} SET ");

            FieldInfo[] columnFields = entity.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(x => x.IsDefined(typeof(ColumnAttribute))).ToArray();

            foreach (var columnField in columnFields)
            {
                setStringBuilder.Append($"{this.GetColumnName(columnField)} = '{columnField.GetValue(entity)}', ");
            }
            setStringBuilder = setStringBuilder.Remove(setStringBuilder.Length - 2, 2);

            updateStringBuilder.Append(setStringBuilder);
            updateStringBuilder.Append($" where id = {idInfo.GetValue(entity)}");

            return updateStringBuilder.ToString();
        }

        private string PrepareEntityInsertonString(object entity)
        {
            StringBuilder insertionBuilder = new StringBuilder();
            StringBuilder columnNamesBuilder = new StringBuilder();
            StringBuilder valuesBuilder = new StringBuilder();

            insertionBuilder.Append($"Insert into {this.GetTableName(entity.GetType())}(");
            FieldInfo[] columnFields = entity.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(x => x.IsDefined(typeof(ColumnAttribute))).ToArray();

            foreach (var columnField in columnFields)
            {
                columnNamesBuilder.Append($"{this.GetColumnName(columnField)}, ");
                var value = columnField.GetValue(entity);
                if (this.GetColumnName(columnField) == "RegistrationDate")
                {
                    value = (DateTime)columnField.GetValue(entity);
                    valuesBuilder.Append($"'{value:yyyy-MM-dd HH:mm:ss.fff}', ");
                }
                else
                {
                    valuesBuilder.Append($"'{value}', ");
                }

            }

            columnNamesBuilder = columnNamesBuilder.Remove(columnNamesBuilder.Length - 2, 2);
            valuesBuilder = valuesBuilder.Remove(valuesBuilder.Length - 2, 2);

            insertionBuilder.Append(columnNamesBuilder);
            insertionBuilder.Append(") values(");
            insertionBuilder.Append(valuesBuilder);
            insertionBuilder.Append(");");

            return insertionBuilder.ToString();
        }

        private bool CheckIfTableExists(Type type)
        {
            string query =
                $"SELECT COUNT(name) " +
                $"FROM sys.sysobjects " +
                $"WHERE [Name] = '{this.GetTableName(type)}' AND [xtype] = 'U'";

            int numberOfTables = 0;
            using (connection = new SqlConnection(this.connectionString))
            {
                this.connection.Open();
                SqlCommand command = new SqlCommand(query, this.connection);
                numberOfTables = (int)command.ExecuteScalar();
            }

            return numberOfTables > 0;
        }

        public T FindById<T>(int id)
        {
            T wantedObject = default(T);
            string query = $"Select * from {this.GetTableName(typeof(T))} where id = {id}";

            using (connection = new SqlConnection(this.connectionString))
            {
                this.connection.Open();
                SqlCommand queryCommand = new SqlCommand(query, this.connection);
                SqlDataReader reader = queryCommand.ExecuteReader();
                wantedObject = CreateEntity<T>(reader);
            }

            return wantedObject;
        }

        private T CreateEntity<T>(SqlDataReader reader)
        {
            reader.Read();
            object[] columns = new object[reader.FieldCount];
            reader.GetValues(columns);

            Type[] types = new Type[columns.Length - 1];
            object[] fieldValues = new object[columns.Length - 1];

            for (int i = 1; i < columns.Length; i++)
            {
                types[i - 1] = columns[i].GetType();
                fieldValues[i - 1] = columns[i];
            }

            T createdObject =  (T)typeof(T).GetConstructor(types)?.Invoke(fieldValues);

            FieldInfo idInfo =  createdObject?.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(info => info.IsDefined(typeof(IdAttribute)));

            idInfo?.SetValue(createdObject, columns[0]);

            return createdObject;
        }

        public IEnumerable<T> FindAll<T>()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> FindAll<T>(string @where)
        {
            throw new System.NotImplementedException();
        }

        public T FindFirst<T>()
        {
            throw new System.NotImplementedException();
        }

        public T FindFirst<T>(string @where)
        {
            throw new System.NotImplementedException();
        }

        public void Delete<T>(object entity)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById<T>(int id)
        {
            throw new System.NotImplementedException();
        }

        private void CreateTable(Type entity)
        {
            string creationString = PrepareTableCreationString(entity);
            using (connection = new SqlConnection(this.connectionString))
            {
                this.connection.Open();
                SqlCommand command = new SqlCommand(creationString, this.connection);
                command.ExecuteNonQuery();
            }
        }

        private string PrepareTableCreationString(Type entity)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"CREATE TABLE {GetTableName(entity)} (");
            builder.Append($"Id INT PRIMARY KEY IDENTITY(1,1), ");

            FieldInfo[] columnsInfos =
                entity.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(x => x.IsDefined(typeof(ColumnAttribute)))
                .ToArray();


            foreach (FieldInfo columnField in columnsInfos)
            {
                builder.Append($"{this.GetColumnName(columnField)} {this.GetTypeToDB(columnField)}, ");
            }
            builder.Remove(builder.Length - 2, 2);
            builder.Append(")");

            return builder.ToString();
        }

        private string GetTypeToDB(FieldInfo field)
        {
            switch (field.FieldType.Name)
            {
                case "Int32":
                    return "int";
                case "String":
                    return "varchar(max)";
                case "DateTime":
                    return "datetime";
                case "Boolean":
                    return "bit";
                default:
                    Console.WriteLine(field.FieldType.Name);
                    throw new ArgumentException("No such present type - try extending the framework!");
            }
        }

        private FieldInfo GetId(Type entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Cannot get id for null type!");
            }

            FieldInfo id =
                entity.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .FirstOrDefault(x => x.IsDefined(typeof(IdAttribute)));

            if (id == null)
            {
                throw new ArgumentNullException("No id field was found the current class!");
            }

            return id;
        }

        private string GetTableName(Type entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Table null!");
            }

            if (!entity.IsDefined(typeof(EntityAttribute)))
            {
                throw new ArgumentException("Cannot get table name of entity!");
            }

            string tableName = entity.GetCustomAttribute<EntityAttribute>().TableName;

            if (tableName == null)
            {
                throw new ArgumentNullException("Table name cannot be null!");
            }

            return tableName;
        }

        private string GetColumnName(FieldInfo field)
        {
            if (field == null)
            {
                throw new ArgumentNullException("Field cannot be null");
            }

            if (!field.IsDefined(typeof(ColumnAttribute)))
            {
                return field.Name;
            }

            string columnName = field.GetCustomAttribute<ColumnAttribute>().ColumnName;
            if (columnName == null)
            {
                throw new ArgumentNullException("Column name cannot be null!");
            }

            return columnName;

        }
    }
}
