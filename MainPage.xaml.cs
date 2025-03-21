using System;
using System.Data;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;

namespace MyMauiApp
{
    public partial class MainPage : ContentPage
    {
        private DatabaseHelper dbHelper;

        public MainPage()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper(); // Diperbaiki: Penambahan '='
            dbHelper.Connect();
            LoadData();
        }

        private void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            string nim = nimEntry.Text;      // Diperbaiki: Tambah '='
            string nama = namaEntry.Text;    // Diperbaiki: Tambah '='
            string email = emailEntry.Text;  // Diperbaiki: Tambah '='
            string telpon = telponEntry.Text;
            string alamat = alamatEntry.Text; // Diperbaiki: Tambah '='

            dbHelper.InsertData(nim, nama, email, telpon, alamat);
            LoadData();
        }

        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            string nim = nimEntry.Text; // Diperbaiki: Tambah '='
            dbHelper.DeleteData(nim); // Ensure the NIM parameter is passed correctly
            LoadData();
        }

        private void LoadData()
        {
            DataTable dataTable = dbHelper.GetData(); // Mengambil data dari database
            dataGrid.ItemsSource = dataTable.DefaultView; // Menampilkan data pada dataGrid

            // Serialize the data to JSON and log it
            string jsonData = JsonConvert.SerializeObject(dataTable);
            Console.WriteLine("Serialized Data: " + jsonData);
        }
    }
}
