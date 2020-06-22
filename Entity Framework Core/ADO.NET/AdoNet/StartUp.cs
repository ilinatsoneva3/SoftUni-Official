using System;
using Microsoft.Data.SqlClient;

namespace VilainNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using var sqlConnection = new SqlConnection(@"Server=DESKTOP-URSLOO9\SQLEXPRESS;Database=MinionsDB;Integrated Security=true");

            sqlConnection.Open();

            var command = new SqlCommand("SELECT Name, COUNT(VillainId) AS MinionsCount "  +
                                            "FROM Villains " +
                                            "JOIN MinionsVillains ON Id = VillainId " +
                                        "GROUP BY Id, Name " +
                                          "HAVING COUNT(VillainId) > 3 " +
                                        "ORDER BY COUNT(VillainId) DESC", sqlConnection);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var name = reader["Name"];
                var count = reader["MinionsCount"];
                Console.WriteLine($"{name} - {count}");
            }
        }
    }
}
