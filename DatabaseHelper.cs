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

    public void InsertData(string nim, string nama, string email, string telpon, string alamat)
    {
        try
        {
            string query = "INSERT INTO mahasiswa (NIM, Nama, Email, Telpon, Alamat) VALUES (@NIM, @Nama, @Email, @Telpon, @Alamat)";
            MySqlCommand cmd = new MySqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@NIM", nim);
            cmd.Parameters.AddWithValue("@Nama", nama);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Telpon", telpon);
            cmd.Parameters.AddWithValue("@Alamat", alamat);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Data inserted successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to insert data: {ex.Message}");
        }
    }

    public void CloseConnection()
    {
        if (connection.State == ConnectionState.Open)
        {
            connection.Close();
            Console.WriteLine("Database connection closed.");
        }
    }

    public void DeleteData(string nim)
    {
        try
        {
            string query = "DELETE FROM mahasiswa WHERE NIM = @NIM";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@NIM", nim); // Bind the NIM parameter
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data deleted successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to delete data: {ex.Message}");
        }
    }
}