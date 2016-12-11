using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace _05.ChangeTownNamesCasing
{
    class ChangeTownNamesCasing
    {
        static void Main()
        {
            string countryName = Console.ReadLine().Trim();
            string connStr = @"Server=.\SQLEXPRESS;database=MinionsDB;Trusted_Connection=true;";
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                int countTowns = CheckTownsExistAndReturnCount(countryName, connection);
                if (countTowns == 0)
                {
                    Console.WriteLine("No town names were affected.");
                    return;
                }

                string sql = "Update Towns set Name = UPPER(Name) where country = @countryName";
                SqlCommand sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.Parameters.AddWithValue("@countryName", countryName);
                sqlCommand.ExecuteNonQuery();

                Console.WriteLine($"{countTowns} town names were affected.");
                sql = "Select t.[Name] from Towns as t where t.country = @countryName";
                sqlCommand.CommandText = sql;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                List<string> townNamesStr = new List<string>();
                while (reader.Read())
                {
                    //Console.Write("[");
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        townNamesStr.Add(reader[i].ToString());
                    }
                }
                reader.Close();
                Console.WriteLine($"[{string.Join<string>(", ", townNamesStr)}]");
            }
        }

        private static int CheckTownsExistAndReturnCount(string countryName, SqlConnection connection)
        {
            string sql = "Select count(1) from Towns as t where t.Country = @name";
            SqlCommand sqlCommand = new SqlCommand(sql, connection);
            sqlCommand.Parameters.AddWithValue("@name", countryName);
            return int.Parse(sqlCommand.ExecuteScalar().ToString());
        }
    }
}
