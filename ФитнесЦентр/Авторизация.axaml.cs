using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ФитнесЦентр;а

public partial class Авторизация : Window
{
    public Авторизация()
    {
        InitializeComponent();
    }

    public void OpenAdminVersion()
    {
        if (Phone.Text= "999" && Password.text = "admin")
        {
            Окно_админа p = new Окно_админа();
            p.Show();
            this.Hide();
        }
    }
}