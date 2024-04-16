using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ФитнесЦентр;

public partial class Меню : Window
{
    public Меню()
    {
        InitializeComponent();
    }

    public void OpenAutorization()
    {
        Авторизация а = new Авторизация();
        а.Show();
        this.Close();
    }

    public void OpenWindow()
    {
        Главная_форма г = new Главная_форма();
        г.Show();
        this.Close();
    }
    public void Exit()
    {
        this.Close();
    }
}