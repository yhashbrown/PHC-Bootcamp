using System;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        // If your SSMS server was (local)\SQLEXPRESS, use this:
        var connectionString =
            "Server=(local)\\SQLEXPRESS;Database=TrainingDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True";

        using var conn = new SqlConnection(connectionString);
        conn.Open();

        using var cmd = new SqlCommand("SELECT Id, Name, Age FROM Students ORDER BY Id", conn);
        using var reader = cmd.ExecuteReader();

        Console.WriteLine("ID  Name          Age");
        Console.WriteLine("--  ------------  ---");

        int count = 0;
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            int age = reader.GetInt32(2);
            Console.WriteLine($"{id,-3} {name,-12} {age,3}");
            count++;
        }

        Console.WriteLine($"\nTotal rows: {count}");
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
