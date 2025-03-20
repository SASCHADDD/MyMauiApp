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

    public DataTable GetData()
    {
        DataTable dataTable = new DataTable();
        try
        {
            string query = "SELECT NIM, Nama, Email, Telpon, Alamat FROM mahasiswa";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            adapter.Fill(dataTable);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to retrieve data: {ex.Message}");
        }
        return dataTable;
    }

    
