using System;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;

namespace AddMinion
{
    public class StartUp
    {

        private const string connectionText = @"Server=DESKTOP-URSLOO9\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";

        public static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionText);

            connection.Open();

            var minionData = ParseInput();


            var villainName = ParseInput()[0];

            var result = AddToDatabase(connection, minionData, villainName);

            Console.WriteLine(result);
        }

        private static string AddToDatabase(SqlConnection connection, string[] minionData, string villainName)
        {
            var minionName = minionData[0];
            var minionAge = int.Parse(minionData[1]);
            var minionTown = minionData[2];

            var result = new StringBuilder();

            //check if town exists in database

            var queryText = @"SELECT Id FROM TOWNS WHERE [NAME] = @townName";


            var townId = CheckIfEntryExists(queryText, connection, "@townName", minionTown);
            //add town to database if it does not exists

            if (townId is null)
            {
                queryText = @"INSERT INTO TOWNS([Name])
                                VALUES(@townName)";

                AddEntryToDatabase(queryText, connection, "@townName", minionTown);

                queryText = @"SELECT Id FROM TOWNS WHERE [NAME] = @townName";

                townId = CheckIfEntryExists(queryText, connection, "@townName", minionTown);

                result.AppendLine($"Town {minionTown} was added to the database.");
            }

            //check if villain exists in the database

            queryText = @"SELECT Id FROM Villains WHERE Name = @villainName";

            var villainId = CheckIfEntryExists(queryText, connection, "@villainName", villainName);

            //add villain to database if he does not exist
            if (villainId is null)
            {
                queryText = @"INSERT INTO Villains ([Name], EvilnessFactorId)  VALUES (@villainName, 4)";
                AddEntryToDatabase(queryText, connection, "@villainName", villainName);

                queryText = @"SELECT Id FROM Villains WHERE Name = @villainName";
                villainId = CheckIfEntryExists(queryText, connection, "@villainName", villainName);

                result.AppendLine($"Villain {villainName} was added to the database.");
            }

            //check if minion exists in database

            queryText = @"SELECT Id FROM Minions WHERE Name = @minionName";

            var minionId = CheckIfEntryExists(queryText, connection, "@minionName", minionName);

            //add minion if it does not exist in database

            if (minionId is null)
            {
                queryText = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@minionName, @age, @townId)";

                AddEntryToDatabase(queryText, connection, "@minionName", minionName, "@age", minionAge.ToString(), "@townId", townId);

                queryText = @"SELECT Id FROM Minions WHERE Name = @minionName";

                minionId = CheckIfEntryExists(queryText, connection, "@minionName", minionName);

            }

            //add minion to be servant of villain

            queryText = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";

            result = PairMinionAndVillain(queryText, connection, result, "@minionId", minionId, "@villainId", 
                                                            villainId, minionName, villainName);

            return result.ToString();
            
        }

        private static StringBuilder PairMinionAndVillain(string queryText, SqlConnection connection, 
                StringBuilder result, string param1, string minionId, string param2, string villainId, string minionName, string villainName)
        {
            try
            {                
                AddEntryToDatabase(queryText, connection, param1, minionId, param2, villainId);

                result.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");               
            }
            catch (Exception e)
            {
                Console.WriteLine($"Minion {minionName} is already a servant of villain {villainName}");
            }

            return result;
        }

        private static void AddEntryToDatabase(string queryText, SqlConnection connection, params string[] parameters)
        {
            var sqlCommand = new SqlCommand(queryText, connection);

            for (int i = 0; i < parameters.Length - 1; i += 2)
            {
                var parameter = parameters[i];
                var value = parameters[i + 1];
                sqlCommand.Parameters.AddWithValue(parameter, value);
            }

            sqlCommand.ExecuteNonQuery();
        }

        private static string CheckIfEntryExists(string queryText, SqlConnection connection, string parameter, string value)
        {
            var sqlCommand = new SqlCommand(queryText, connection);
            sqlCommand.Parameters.AddWithValue(parameter, value);

            var entryId = sqlCommand.ExecuteScalar()?.ToString();
            return entryId;
        }

        private static string[] ParseInput()
        {
            var initialInput = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            return initialInput[1]
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
        }
    }
}
