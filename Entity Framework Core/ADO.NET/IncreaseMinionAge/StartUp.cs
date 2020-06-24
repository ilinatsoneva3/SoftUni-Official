using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Text;

namespace IncreaseMinionAge
{
    public class StartUp
    {
        private const string connectionText = @"Server=DESKTOP-URSLOO9\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionText);

            connection.Open();

            var inputIds = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse).ToArray();
            var result = IncreaseMinionAge(connection, inputIds);

            Console.WriteLine(result);
        }

        private static string IncreaseMinionAge(SqlConnection connection, int[] inputIds)
        {
            var result = new StringBuilder();

            //update minions age and name
            var idRange = string.Join(", ", inputIds);
            var queryText = $@" UPDATE Minions
                                   SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                 WHERE Id in ({idRange})";
            var sqlCommand = new SqlCommand(queryText, connection);     
            sqlCommand.ExecuteNonQuery();

            //get minions new name and age
            queryText = @"SELECT Name, Age FROM Minions";
            sqlCommand = new SqlCommand(queryText, connection);
            using var reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                result.AppendLine($"{reader["Name"].ToString()} {reader["Age"].ToString()}");
            }

            return result.ToString();
        }
    }
}
