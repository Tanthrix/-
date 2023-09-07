using ImapX;
using ImapX.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Post_client_9
{
    internal class LoggedUser
    {
        public string Email { get; set; }
        public string Pass { get; set; }
        public string SmtpHost { get; set; }
    }
    internal class ImappHelper
    {
        private static ImapClient client { get; set; }
        private static LoggedUser loggedUser { get; set; } = new LoggedUser(); public static void Initialize(string host)
        {
            client = new ImapClient(host, true);
            if (!client.Connect())
            {
                MessageBox.Show("Оишбка подключения");
            }
            else
            {
                loggedUser.SmtpHost = host.Replace("imap", "smtp");
            }
        }
        public static bool Login(string u, string p)
        {
            loggedUser.Email = u;
            loggedUser.Pass = p;
            return client.Login(u, p);
        }
        public static void Logout()
        {
            if (client.IsAuthenticated)
            {
                client.Logout();
                client.Dispose();
            }
        }
        public static CommonFolderCollection GetFolders()
        {
            client.Folders.Inbox.StartIdling();
            client.Folders.Inbox.OnNewMessagesArrived += Inbox_OnNewMessagesArrived;
            return client.Folders;
        }
        private static void Inbox_OnNewMessagesArrived(object sender, IdleEventArgs e)
        {
            MessageBox.Show($"Пришло новое сообщение в папку {e.Folder.Name}.");
        }
        public static MessageCollection GetMessagesForFolder(string name)
        {
            MessageCollection msg = new MessageCollection(client, client.Folders.Trash);
            try
            {
                client.Folders[name].Messages.Download(); // Start the download process;
                return client.Folders[name].Messages;
            }
            catch (Exception e)
            {
                return msg;
            }
        }
        public static LoggedUser GetCredentials()
        {
            return loggedUser;
        }
    }
}
