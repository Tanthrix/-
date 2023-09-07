using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace Messanger
{
    /// <summary>
    /// Логика взаимодействия для chat_user.xaml
    /// </summary>
    public partial class chat_user : Window
    {
        TCPClient client;
        chat_admin hostWindow;
        public chat_user(IPAddress ip, string nickname)
        {
            InitializeComponent();
            TCPClient socket = new TCPClient(MsgLB, this, ip, nickname, UsersLB);
            client = socket;
            client.Start();

        }

        private void SendBTN_Click(object sender, RoutedEventArgs e)
        {
            client.SendMessage(MsgTB.Text);
            MsgTB.Clear();
        }

        private void ExitBTN_Click(object sender, RoutedEventArgs e)
        {
            client.SendMessage("/Disconnect");
            client.DisconnectServer();
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            client.SendMessage("/Disconnect");
            client.DisconnectServer();
        }
    }
}
