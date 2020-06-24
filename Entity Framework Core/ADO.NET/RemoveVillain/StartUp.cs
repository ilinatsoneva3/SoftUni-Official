using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace RemoveVillain
{
    class StartUp
    {
        private const string connectionText = @"Server=DESKTOP-URSLOO9\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionText);

            connection.Open();

            var villainId = int.Parse(Console.ReadLine());
            var result = DeleteVillain(connection, villainId);
            Console.WriteLine(result);
        }

        private static string DeleteVillain(SqlConnection connection, int villainId)
        {
            var result = new StringBuilder();

            //find if villain exists

            var queryText = @"SELECT Name FROM Villains WHERE Id = @villainId";
            var sqlCommand = new SqlCommand(queryText, connection);
            sqlCommand.Parameters.AddWithValue("@villainId", villainId);

            var name = sqlCommand.ExecuteScalar()?.ToString();

            if (name is null)
            {
                result.AppendLine("No such villain was found.");
            }
            else
            {
                //delete minions
                queryText = @"DELETE FROM MinionsVillains WHERE VillainId = @villainId";
                sqlCommand = new SqlCommand(queryText, connection);
                sqlCommand.Parameters.AddWithValue("@villainId", villainId);
                var numOfMinions = sqlCommand.ExecuteNonQuery();

                //delete villain
                queryText = @"DELETE FROM Villains WHERE Id = @villainId";
                sqlCommand = new SqlCommand(queryText, connection);
                sqlCommand.Parameters.AddWithValue("@villainId", villainId);
                sqlCommand.ExecuteNonQuery();

                //append text to be printed
                result.AppendLine($"{name} was deleted.");
                result.AppendLine($"{numOfMinions} minions were released.");
            }

            return result.ToString();
        }
    }
}
