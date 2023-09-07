using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Post_client_9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (Properties.Settings.Default.Login != "")
            {
                log_in(Properties.Settings.Default.Login, Properties.Settings.Default.Password, Properties.Settings.Default.Host);
            }
            Background = new ImageBrush(new BitmapImage(new Uri("https://images.hdqwalls.com/download/anime-scenery-field-4k-9j-2560x1700.jpg")));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cb.SelectedItem != null && login.Text != "" && password.Password != "")
            {
                save_defaul(login.Text, password.Password, (cb.SelectedItem as ComboBoxItem).Tag.ToString());
                log_in(login.Text, password.Password, (cb.SelectedItem as ComboBoxItem).Tag.ToString());
            }
        }
        public static void save_defaul(string login = "", string password = "", string tag = "")
        {
            Properties.Settings.Default.Login = login;
            Properties.Settings.Default.Password = password;
            Properties.Settings.Default.Host = tag;
            Properties.Settings.Default.Save();
        }
        void log_in(string login, string password, string tag)
        {
            ImappHelper.Initialize(tag);
            try
            {
                if (ImappHelper.Login(login, password))
                {
                    Hide();
                    new Mail().Show();
                }
                else MessageBox.Show("Ошибка входа!");
            }
            catch { }
        }
    }
}
