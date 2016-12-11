using System;
using System.Data;
using System.Data.SqlClient;

namespace _09.IncreaseAgeStoredProcedure
{
    class Program
    {
        static void Main()
        {
            int minionID = int.Parse(Console.ReadLine());
            string connStr = @"Server=.\SQLEXPRESS;database=MinionsDB;Trusted_connection=true;";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                SqlCommand getUsp = new SqlCommand("usp_GetOlder", connection);
                getUsp.CommandType = CommandType.StoredProcedure;
                getUsp.Parameters.AddWithValue("@MinionId", minionID);

                getUsp.ExecuteNonQuery();

                string sql = "Select m.[Name], m.Age from Minions as m where ID = @minionId";
                SqlCommand getAllMinion = new SqlCommand(sql, connection);
                getAllMinion.Parameters.AddWithValue("@minionId", minionID);

                using (SqlDataReader reader = getAllMinion.ExecuteReader())
                {
                    reader.Read();
                    Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
                }
            }
        }
    }
}
