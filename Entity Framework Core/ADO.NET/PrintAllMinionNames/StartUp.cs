using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintAllMinionNames
{
    class StartUp
    {
        private const string connectionText = @"Server=DESKTOP-URSLOO9\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionText);

            connection.Open();

            var result = PrintAllMinionNames(connection);

            Console.WriteLine(result);
        }

        private static string PrintAllMinionNames(SqlConnection connection)
        {
            var namesResult = new List<string>();
            var names = new List<string>();

            //get all minions names
            var queryText = "SELECT Name FROM Minions";
            var sqlCommand = new SqlCommand(queryText, connection);
            using var reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                names.Add(reader["Name"].ToString());
            }

            //reorder names

            var index = 0;

            while (namesResult.Count<names.Count)
            {
                namesResult.Add(names[index]);

                if (namesResult.Count==names.Count)
                {
                    break;
                }

                namesResult.Add(names[names.Count - 1 - index]);

                index++;
            }


            var result = string.Join("\n", namesResult);
            return result;
        }
    }
}
