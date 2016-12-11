using System;
using System.Data.SqlClient;

namespace _01.InitialSetup
{
    class InitialSetup
    {
        static void Main()
        {
            string connStr = "Server=.\\SQLEXPRESS;database=master;Trusted_connection=true";
            string databaseName = "MinionsDB";

            if (!CheckDatabaseExists(connStr, databaseName))
            {
                CreateDatabase(connStr, databaseName);
            }

            connStr = "Server=.\\SQLEXPRESS;database=" + databaseName + ";Trusted_connection=true";

            string tableName = "Towns";
            string sqlCommand;

            if (!CheckTableExists(connStr, tableName))
            {
                sqlCommand = "Create table Towns (ID int primary key identity, Name varchar(30), Country varchar(30))";
                SqlExNonQuert(connStr, sqlCommand);
            }

            sqlCommand = "Insert into Towns (Name, Country) values('Berlin', 'Germany'),('Varna','Bulgaria'),('Sofia','Bulgaria'),('Burgas','Bulgaria'),('Belgrade','Serbia')";

            SqlExNonQuert(connStr, sqlCommand);

            tableName = "Minions";

            if (!CheckTableExists(connStr, tableName))
            {
                sqlCommand = "Create table Minions (ID int primary key identity, Name varchar(30), Age int,TownID int, CONSTRAINT FK_Minions_Towns FOREIGN KEY(townID) REFERENCES Towns(ID))";
                SqlExNonQuert(connStr, sqlCommand);
            }

            sqlCommand = "Insert into Minions (Name, Age, TownID) values('Bob', 13, 1),('Kevin',14,2),('Steward',19,3),('Simon',22,4),('Jimmy',20,1)";

            SqlExNonQuert(connStr, sqlCommand);

            tableName = "EvilnessFactors";

            if (!CheckTableExists(connStr, tableName))
            {
                sqlCommand = "Create table EvilnessFactors (ID int primary key identity, Name varchar(30))";
                SqlExNonQuert(connStr, sqlCommand);
            }

            sqlCommand = "Insert into EvilnessFactors (Name) values('Good'),('Bad'),('Evil'),('Super evil')";

            SqlExNonQuert(connStr, sqlCommand);

            tableName = "Villains";

            if (!CheckTableExists(connStr, tableName))
            {
                sqlCommand = "Create table Villains (ID int primary key identity, Name varchar(30), EvilnessFactorID int, CONSTRAINT FK_Villains_EvilnessFactors FOREIGN KEY(EvilnessFactorID) REFERENCES EvilnessFactors(ID))";
                SqlExNonQuert(connStr, sqlCommand);
            }

            sqlCommand = "Insert into Villains (Name, EvilnessFactorID) values('Gru',1),('Victor',2),('Jilly',3),('Victor Jr.',4),('Gru Jr.',1)";

            SqlExNonQuert(connStr, sqlCommand);

            tableName = "VillainsMinions";

            if (!CheckTableExists(connStr, tableName))
            {
                sqlCommand = "Create table VillainsMinions (VillainID int, MinionID int, CONSTRAINT PK_VillainID_MinionID PRIMARY KEY (VillainID,MinionID), CONSTRAINT FK_VillainsMinions_Villains FOREIGN KEY(VillainID) REFERENCES Villains(ID), CONSTRAINT FK_VillainsMinions_Minions FOREIGN KEY(MinionID) REFERENCES Minions(ID))";
                SqlExNonQuert(connStr, sqlCommand);
            }
            sqlCommand = "Insert into VillainsMinions (VillainID, MinionID) values(1,1),(1,2),(1,3),(2,1),(2,4),(3,5)";

            SqlExNonQuert(connStr, sqlCommand);

        }

        private static void SqlExNonQuert(string connStr, string sqlCommand)
        {
            using (var connection = new SqlConnection(connStr))
            {
                using (var comm = new SqlCommand())
                {
                    comm.Connection = connection;
                    comm.CommandText = sqlCommand;
                    connection.Open();
                    comm.ExecuteNonQuery();
                }
            }
        }

        private static void CreateDatabase(string connStr, string databaseName)
        {
            string sqlQuery = "CREATE DATABASE " + databaseName + ";";
            using (var connection = new SqlConnection(connStr))
            {
                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static bool CheckDatabaseExists(string connStr, string databaseName)
        {
            using (var connection = new SqlConnection(connStr))
            {
                using (var command = new SqlCommand($"SELECT db_id('{databaseName}')", connection))
                {
                    connection.Open();
                    return (command.ExecuteScalar() != DBNull.Value);
                }
            }
        }

        public static bool CheckTableExists(string connStr, string tableName)
        {
            using (var connection = new SqlConnection(connStr))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    var sql = $"SELECT COUNT(*) FROM information_schema.tables WHERE table_name = '{tableName}'";
                    command.CommandText = sql;
                    connection.Open();
                    var count = Convert.ToInt32(command.ExecuteScalar());
                    return (count > 0);
                }
            }
        }
    }
}
