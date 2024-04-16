using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;

namespace ФитнесЦентр;

public partial class Окно_админа : Window
{
    private List<Client> _clients;
    private string _connString="server=10.10.1.24; database=Center; login=user_01; password=user01pro;";
    string fullTable = "SELECT * FROM client";
    private MySqlConnection conn;
    public Окно_админа()
    {
        InitializeComponent();
        ShowCenterTable(fullTable);
    }

    public void ShowCenterTable(string fullTable)
    {
        _clients = new List<Client>();
        conn = new MySqlConnection(_connString);
        conn.Open();
        MySqlCommand command = new MySqlCommand(fullTable, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentYch = new Client()
            {
                ID = reader.GetInt32("ID"),
                Фамилия = reader.GetString("Фамилия"),
                Имя= reader.GetString("Имя"),
                Номер_телефона = reader.GetInt32("Номер_телефона"),
                Дата_рождения = reader.GetString("Дата_рождения"),
                Пол = reader.GetString("Пол"),
                Скидка = reader.GetString("Скидка"),
            };
            _clients.Add(currentYch);
        }
        conn.Close();
        DataGrid.ItemsSource = _clients;
    }

    public void Remove(object? sender, RoutedEventArgs routedEventArgs)
    {
        try
        {
            Client srv = DataGrid.SelectedItem as Client;
            if (srv == null)
            {
                return;
            }
            conn = new MySqlConnection(_connString);
            conn.Open();
            string sql = "DELETE FROM client WHERE ID = " + srv.ID;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            _clients.Remove(srv);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        ShowCenterTable(fullTable);
    }
}
