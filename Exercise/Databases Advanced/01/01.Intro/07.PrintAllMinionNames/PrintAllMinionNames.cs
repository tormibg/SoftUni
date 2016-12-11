using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _07.PrintAllMinionNames
{
    class PrintAllMinionNames
    {
        static void Main()
        {
            string connStr = @"Server=.\SQLEXPRESS;database=MinionsDB;Trusted_Connection=true;";
            List<string> minionsList = new List<string>();

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                string sql = "Select m.Name from Minions as m";
                SqlCommand minionNamesCmd = new SqlCommand(sql, connection);
                connection.Open();
                using (SqlDataReader reader = minionNamesCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        minionsList.Add(reader[0].ToString());
                    }
                }
            }

            if (minionsList.Count > 0)
            {
                PrintMinionNames(minionsList);
            }
            else
            {
                Console.WriteLine("Not any minions in database");
            }
        }

        private static void PrintMinionNames(List<string> minionsList)
        {
            int oddName = 0;
            int lastName = minionsList.Count - 1;

            for (int i = 0; i < minionsList.Count; i++)
            {
                int curIndex;
                if (i % 2 == 0)
                {
                    curIndex = oddName;
                    oddName++;
                }
                else
                {
                    curIndex = lastName;
                    lastName--;
                }
                Console.WriteLine(minionsList[curIndex]);
            }
        }
    }
}
