using ImapX;
using ImapX.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Post_client_9
{
    /// <summary>
    /// Логика взаимодействия для Mail.xaml
    /// </summary>
    public partial class Mail : Window
    {
        public static Message Message;
        public static string name;
        public static string theme;
        public Mail()
        {
            InitializeComponent();
            checkMessages("INBOX");
        }
        void checkMessages(string folder)
        {
            frame.Content = new listbox(folder);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            checkMessages((sender as Button).Content.ToString());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            frame.Content = new WriteMail();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Hide();
            new MainWindow();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Hide();
            ImappHelper.Logout();
            MainWindow.save_defaul();
            new MainWindow().Show();
        }
    }
}
