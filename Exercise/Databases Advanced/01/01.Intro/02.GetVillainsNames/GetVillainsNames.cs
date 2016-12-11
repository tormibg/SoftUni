using System;
using System.Data.SqlClient;

namespace _02.GetVillainsNames
{
    class GetVillainsNames
    {
        static void Main()
        {
            string connStr = "Server=.\\SQLEXPRESS;database=MinionsDB;Trusted_Connection=true";

            using (var connection = new SqlConnection(connStr))
            {

                var sqlCommand = new SqlCommand();

                string sqlStr =
                        "SELECT v.[Name], COUNT(vm.MinionID) AS cc FROM Villains AS v JOIN VillainsMinions AS vm ON vm.VillainID = v.ID GROUP BY v.Name HAVING COUNT(vm.MinionID) > 3 ORDER BY cc DESC"
                    ;
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = sqlStr;
                connection.Open();

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write($"{reader[i]} ");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
