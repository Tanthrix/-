using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Messanger
{
    public partial class MainWindow : Window
    {
        private chat_admin chat;
        private string ipPattern = "\\b(?:\\d{1,3}\\.){3}\\d{1,3}\\b";
        private string nicknamePattern = "^[A-Za-z0-9_]+$";
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(NicknameTB.Text, nicknamePattern, RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Incorrect nickname");
                NicknameTB.Text = string.Empty;
            }
            else
            {
                chat = new chat_admin(NicknameTB.Text);
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Validation())
            {
                try
                {
                    new chat_user(IPAddress.Parse(IpTB.Text), NicknameTB.Text).Show();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Chat doesn't exist");
                    IpTB.Text = string.Empty;
                }
            }
        }
        private bool Validation()
        {
            if (!Regex.IsMatch(IpTB.Text, ipPattern, RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Incorrect IP");
                IpTB.Text = string.Empty;
                return false;
            }
            if (!Regex.IsMatch(NicknameTB.Text, nicknamePattern, RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Incorrect nickname");
                NicknameTB.Text = string.Empty;
                return false;
            }
            return true;
        }
    }
}
