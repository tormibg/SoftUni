using System;
using System.Data.SqlClient;

namespace _04.AddMinion
{
    class AddMinion
    {
        static void Main()
        {
            string[] readMinions = Console.ReadLine().Split(':')[1].Trim().Split(' ');
            string minionName = readMinions[0];
            int minionAge = int.Parse(readMinions[1]);
            string minionTownName = readMinions[2];

            string villainName = Console.ReadLine().Split(':')[1].Trim();

            string connStr = @"Server=.\SQLEXPRESS;database=MinionsDB;Trusted_Connection=true;";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                if (!CheckTownInDatabase(minionTownName, connection))
                {
                    AddTown(minionTownName, connection);
                    Console.WriteLine($"Town {minionTownName} was added to the database.");
                }

                if (!CheckMinionInDataBase(minionName, connection))
                {
                    ADDMinion(minionName, minionAge, minionTownName, connection);
                    Console.WriteLine($"Minion {minionName} was added to the database.");
                }

                if (!CheckVillainInDataBase(villainName, connection))
                {
                    AddVilian(villainName, connection);
                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }

                int minionId = GetIdFormName(minionName, connection, "Minions");
                int villainId = GetIdFormName(villainName, connection, "Villains");

                try
                {
                    AddMinionToVilian(minionId, villainId, connection);
                    Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}");
                }
                catch (Exception)
                {
                    Console.WriteLine($"Connection between minion {minionName} and villain {villainName} already exist");
                }
            }
        }

        private static void AddMinionToVilian(int minionId, int villainId, SqlConnection connection)
        {
            string sql = "Insert into VillainsMinions (VillainID, MinionID) values (@villainId, @minionId)";
            SqlCommand sqlCommand = new SqlCommand(sql, connection);
            sqlCommand.Parameters.AddWithValue("@villainId", villainId);
            sqlCommand.Parameters.AddWithValue("@minionId", minionId);
            sqlCommand.ExecuteNonQuery();
        }

        private static void AddVilian(string villainName, SqlConnection connection)
        {
            string sql = "Insert into Villains(Name, EvilnessFactorID) Values(@name, 3)";
            SqlCommand sqlCommand = new SqlCommand(sql, connection);
            sqlCommand.Parameters.AddWithValue("@name", villainName);
            sqlCommand.ExecuteNonQuery();
        }

        private static bool CheckVillainInDataBase(string villainName, SqlConnection connection)
        {
            string sql = "Select count(1) from Villains as v where v.[Name] = @name";
            SqlCommand sqlCommand = new SqlCommand(sql, connection);
            sqlCommand.Parameters.AddWithValue("@name", villainName);
            return int.Parse(sqlCommand.ExecuteScalar().ToString()) != 0;
        }

        private static void ADDMinion(string minionName, int minionAge, string minionTownName, SqlConnection connection)
        {
            int townId = GetIdFormName(minionTownName, connection, "Towns");
            string sql = "Insert into Minions(Name, Age, TownID) Values(@name, @age, @townId)";
            SqlCommand sqlCommand = new SqlCommand
            {
                Connection = connection,
                CommandText = sql
            };
            sqlCommand.Parameters.AddWithValue("@name", minionName);
            sqlCommand.Parameters.AddWithValue("@age", minionAge);
            sqlCommand.Parameters.AddWithValue("@townId", townId);
            sqlCommand.ExecuteNonQuery();

        }

        private static int GetIdFormName(string minionName, SqlConnection connection, string table)
        {
            string sql = "Select ID from " + table + " as t where t.Name = @name";
            SqlCommand sqlCommand = new SqlCommand
            {
                Connection = connection,
                CommandText = sql
            };
            sqlCommand.Parameters.AddWithValue("@name", minionName);
            return int.Parse(sqlCommand.ExecuteScalar().ToString());
        }

        private static bool CheckMinionInDataBase(string minionName, SqlConnection connection)
        {
            string sql = "Select count(1) from Minions as m where m.[Name] = @name";
            SqlCommand sqlCommand = new SqlCommand
            {
                Connection = connection,
                CommandText = sql
            };
            sqlCommand.Parameters.AddWithValue("@name", minionName);
            return int.Parse(sqlCommand.ExecuteScalar().ToString()) != 0;
        }

        private static void AddTown(string minionTownName, SqlConnection connection)
        {
            string sql = "Insert into Towns([Name]) values(@name);";
            SqlCommand sqlCommand = new SqlCommand
            {
                Connection = connection,
                CommandText = sql
            };
            sqlCommand.Parameters.AddWithValue("@name", minionTownName);
            sqlCommand.ExecuteNonQuery();
        }

        private static bool CheckTownInDatabase(string minionTownName, SqlConnection connection)
        {
            string sql = "Select count(1) from Towns as t where t.[Name] = @name";
            SqlCommand sqlCommand = new SqlCommand
            {
                Connection = connection,
                CommandText = sql
            };
            sqlCommand.Parameters.AddWithValue("@name", minionTownName);
            return int.Parse(sqlCommand.ExecuteScalar().ToString()) != 0;
        }
    }
}
