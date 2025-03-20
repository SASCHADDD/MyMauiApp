using MySql.Data.MySqlClient;
using System;
using System.Data;

public class DatabaseHelper
{
    private MySqlConnection connection;

    public DatabaseHelper()
    {
        string connectionString = "server=127.0.0.1;database=organisasiMahasiswa;UID=root;password=[YourPassword]";
        connection = new MySqlConnection(connectionString);
    }

    public void Connect()
    {
        try
        {
            connection.Open();
            Console.WriteLine("Connected to the database");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to connect to the database: {ex.Message}");
        }
    }

    
