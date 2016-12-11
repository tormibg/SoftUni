using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace _08.IncreaseMinionsAge
{
    class IncreaseMinionsAge
    {
        static void Main()
        {
            int[] minionInts = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string connStr = @"Server=.\SQLEXPRESS;database=MinionsDB;Trusted_Connection=true;";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                StringBuilder sql = new StringBuilder();
                for (int i = 0; i < minionInts.Length; i++)
                {
                    sql.AppendLine(
                        "Update Minions set Age = Age + 1, Name = Upper(Left(Name,1))+substring(Name,2,Len(Name)) where ID = @minionID" +
                        i);
                    sql.AppendLine();
                }
                
                SqlCommand updateCmd = new SqlCommand(sql.ToString(), connection);
                for (int i = 0; i < minionInts.Length; i++)
                {
                    updateCmd.Parameters.AddWithValue("@minionID" + i, minionInts[i]);
                }

                updateCmd.ExecuteNonQuery();

                SqlCommand getNameCmd = new SqlCommand("SELECT * FROM Minions", connection);
                SqlDataReader reader = getNameCmd.ExecuteReader();
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
