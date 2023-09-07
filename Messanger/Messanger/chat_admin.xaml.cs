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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Messanger
{
    /// <summary>
    /// Логика взаимодействия для chat_admin.xaml
    /// </summary>
    public partial class chat_admin : Window
    {
        TCPServer server;
        TCPClient adminClient;

        public chat_admin(string nickname)
        {
            InitializeComponent();
            server = new TCPServer(UsersLB, LogsLB, this);
            if (!server.Start())
                Environment.Exit(0);
            this.Show();
            adminClient = new TCPClient(MsgLB, this, IPAddress.Parse("127.0.0.1"), nickname, UsersLB);
            adminClient.Start();
        }

        private void SendBTN_Click(object sender, RoutedEventArgs e)
        {
            adminClient.SendMessage(MsgTB.Text);
            MsgTB.Clear();
        }

        private void ExitBTN_Click(object sender, RoutedEventArgs e)
        {
            adminClient.SendMessage("/Disconnect");
            adminClient.DisconnectServer();
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            adminClient.SendMessage("/Disconnect");
            adminClient.DisconnectServer();
        }
    }
}
