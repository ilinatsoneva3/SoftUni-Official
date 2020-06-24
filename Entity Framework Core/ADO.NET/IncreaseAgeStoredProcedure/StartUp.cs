using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Text;

namespace IncreaseAgeStoredProcedure
{
    public class StartUp
    {
        private const string connectionText = @"Server=DESKTOP-URSLOO9\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionText);

            connection.Open();

            var minionId = int.Parse(Console.ReadLine());

            var result = IncreaseMinionAge(connection, minionId);

            Console.WriteLine(result);
        }

        private static object IncreaseMinionAge(SqlConnection connection, int minionId)
        {
            var result = new StringBuilder();

            var sqlCommand = new SqlCommand("usp_GetOlder", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@id", minionId);
            sqlCommand.ExecuteNonQuery();

            var queryText = "SELECT Name, Age FROM Minions WHERE Id = @Id";
            sqlCommand = new SqlCommand(queryText, connection);
            sqlCommand.Parameters.AddWithValue("@Id", minionId);

            using var reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                result.AppendLine($"{reader["Name"].ToString()} - {reader["Age"].ToString()} years old");
            }

            return result.ToString().TrimEnd();
        }
    }
}
