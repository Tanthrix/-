using HtmlRtf;
using ImapX;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    /// Логика взаимодействия для ChekMail.xaml
    /// </summary>
    public partial class ChekMail : Page
    {
        public ChekMail()
        {
            InitializeComponent();
            Background = new ImageBrush(new BitmapImage(new Uri("https://avatars.mds.yandex.net/i?id=ae35ea0641ca1a74013973d51bb713266c15457d-10022975-images-thumbs&n=13")));
            text_2.Text = Mail.Message.From.DisplayName;
            if (Mail.Message.To[0].Address.ToString().Length > 0)
                text_1.Text = Mail.Message.To[0].Address.ToString();
            string them = string.Empty;
            if (Mail.Message.Subject == null)
                text_3.Text = "<Без темы>";
            else
            {
                foreach (var s in Mail.Message.Subject)
                {
                    them += s;
                    if (them.Count() == 47)
                    {
                        them += "...";
                        break;
                    }
                }
                text_3.Text = them;
            }
            try
            {
                string a = Mail.Message.Body.Html;
                HtmlRtfConverter.ToRtf(a);
                var text = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                FileStream fs = new FileStream("msg.rtf", FileMode.Open);
                text.Load(fs, DataFormats.Rtf);
                fs.Close();
                File.Delete("msg.rtf");
            }
            catch { }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Mail.name = text_1.Text;
            Mail.theme = text_3.Text;
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("WriteMail.xaml", UriKind.Relative));
        }
    }
}
