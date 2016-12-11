using System;
using System.Data.SqlClient;

namespace _03.GetMinionNames
{
    class GetMinionNames
    {
        static void Main()
        {
            int vilianID = Convert.ToInt32(Console.ReadLine().Trim());
            string connStr = @"Server=.\SQLEXPRESS;database=MinionsDB;Trusted_Connection=true;";

            string vilianName = GetVilianName(vilianID, connStr);
            if (vilianName == "null")
            {
                Console.WriteLine($"No villain with ID {vilianID} exists in the database.");
                return;
            }
            Console.WriteLine($"Villain: {vilianName}");

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand sqlCommand = new SqlCommand();
                string sql =
                    "SELECT m.[Name], m.Age FROM Minions AS m JOIN VillainsMinions AS vm ON vm.MinionID = m.id AND vm.VillainID = @VillainID;";
                sqlCommand.CommandText = sql;
                sqlCommand.Connection = connection;
                sqlCommand.Parameters.AddWithValue("@VillainID", vilianID);
                connection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    int counter = 1;
                    bool isRecord = false;
                    while (reader.Read())
                    {
                        Console.Write($"{counter}. ");
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write($"{reader[i]} ");
                            isRecord = true;
                        }
                        Console.WriteLine();
                        counter++;
                    }
                    if (!isRecord)
                    {
                        Console.WriteLine("<no minions>");
                    }
                }
            }
        }

        private static string GetVilianName(int vilianId, string connStr)
        {
            var result = "null";
            using (var connection = new SqlConnection(connStr))
            {
                SqlCommand sqlCommand = new SqlCommand();
                string sql = "SELECT v.[name] FROM Villains AS v WHERE v.id = @VilianID; ";
                sqlCommand.CommandText = sql;
                sqlCommand.Connection = connection;
                sqlCommand.Parameters.AddWithValue("@VilianID", vilianId);
                try
                {
                    connection.Open();
                    result = sqlCommand.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                }
            }
            return result.ToString();
        }
    }
}
