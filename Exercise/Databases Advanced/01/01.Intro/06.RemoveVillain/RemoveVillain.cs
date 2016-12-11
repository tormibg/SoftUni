using System;
using System.Data.SqlClient;

namespace _06.RemoveVillain
{
    class RemoveVillain
    {
        static void Main()
        {
            int villainID = int.Parse(Console.ReadLine().Trim());
            string connStr = @"Server=.\SQLEXPRESS;database=MinionsDB;Trusted_Connection=true;";
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                SqlTransaction deleteVillainTransaction = connection.BeginTransaction();

                SqlCommand deleteVM = new SqlCommand("Delete from VillainsMinions where VillainID = @villainID", connection);
                deleteVM.Parameters.AddWithValue("@villainID", villainID);

                SqlCommand deleteVillain = new SqlCommand("Delete from Villains where ID = @villainID", connection);
                deleteVillain.Parameters.AddWithValue("@villainID", villainID);

                SqlCommand readVillain =
                    new SqlCommand("Select v.[Name] from Villains as v where ID = @villainID", connection);
                readVillain.Parameters.AddWithValue("@villainID", villainID);

                readVillain.Transaction = deleteVillainTransaction;
                try
                {
                    string villainName = String.Empty; 
                    using (SqlDataReader reader = readVillain.ExecuteReader())
                    {
                        reader.Read();
                        villainName = reader[0].ToString();
                        //Console.WriteLine(villainName);
                        reader.Close();
                    }

                    deleteVM.Transaction = deleteVillainTransaction;
                    int deleteMinions = deleteVM.ExecuteNonQuery();

                    deleteVillain.Transaction = deleteVillainTransaction;
                    deleteVillain.ExecuteNonQuery();

                    deleteVillainTransaction.Commit();
                    Console.WriteLine($"{villainName} was deleted");
                    Console.WriteLine($"{deleteMinions} minions released");
                }
                catch (Exception ex)
                {
                    deleteVillainTransaction.Rollback();
                    Console.WriteLine("No such villain was found");
                }
            }
        }
    }
}
