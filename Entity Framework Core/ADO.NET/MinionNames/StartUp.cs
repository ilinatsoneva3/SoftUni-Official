using System;
using Microsoft.Data.SqlClient;

namespace MinionNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var id = int.Parse(Console.ReadLine());

            using var connection = new SqlConnection(@"Server=DESKTOP-URSLOO9\SQLEXPRESS;Database=MinionsDB;Integrated Security=true");

            connection.Open();

            var command = new SqlCommand(@"SELECT Name FROM Villains WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            var villainName = command.ExecuteScalar() as string;

            if (villainName is null)
            {
                Console.WriteLine($"No villain with ID {id} exists in the database.");
            }
            else
            {
                Console.WriteLine($"Villain: {villainName}");          }

           

            command = new SqlCommand(@"SELECT ROW_NUMBER() OVER (ORDER BY Name) as RowNum,
                                                                                 Name, 
                                                                                 Age
                                                                            FROM MinionsVillains
                                                                            JOIN Minions ON MinionId = Id
                                                                           WHERE VillainId = @Id
                                                                        ORDER BY Name", connection);

            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                Console.WriteLine("(no minions)");
            }

            while (reader.Read())
            {
                Console.WriteLine($"{reader["RowNum"]}. {reader["Name"]} {reader["Age"]}");
            }
        }
    }
}
