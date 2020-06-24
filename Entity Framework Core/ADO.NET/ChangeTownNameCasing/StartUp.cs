using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace ChangeTownNameCasing
{
    public class StartUp
    {
        private const string connectionText = @"Server=DESKTOP-URSLOO9\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionText);

            connection.Open();

            var country = Console.ReadLine();

            //find country id

            var queryText = @"SELECT Id FROM [Countries] WHERE [Name] = @countryName";
            var sqlCommand = new SqlCommand(queryText, connection);
            sqlCommand.Parameters.AddWithValue("@countryName", country);
            var countryId = sqlCommand.ExecuteScalar()?.ToString();

            //find if country exists in database

            var result = new StringBuilder();

            if (countryId is null)
            {
                result.AppendLine("No town names were affected.");
            }
            else
            {
                //change names to upper case
                var id = int.Parse(countryId);

                queryText = @"UPDATE Towns
                               SET Name = UPPER(Name)
                             WHERE CountryCode = @countryId";

                sqlCommand = new SqlCommand(queryText, connection);
                sqlCommand.Parameters.AddWithValue("@countryId", id);
                var numOfNames = sqlCommand.ExecuteNonQuery().ToString();
                result.AppendLine($"{numOfNames} town names were affected. ");

                //get names of towns
                queryText = @"SELECT [Name] FROM Towns WHERE CountryCode = @countryId";
                sqlCommand = new SqlCommand(queryText, connection);
                sqlCommand.Parameters.AddWithValue("@countryId", id);

                var towns = new List<string>();

                using var reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    towns.Add(reader["Name"].ToString());
                }

                result.AppendLine(string.Join(", ", towns));
            }

            Console.WriteLine(result.ToString());
        }
    }
}
