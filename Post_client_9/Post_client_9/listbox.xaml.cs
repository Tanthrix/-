using HtmlRtf;
using ImapX;
using ImapX.Collections;
using System;
using System.Collections.Generic;
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
using static System.Net.Mime.MediaTypeNames;

namespace Post_client_9
{
    /// <summary>
    /// Логика взаимодействия для listbox.xaml
    /// </summary>
    public partial class listbox : Page
    {
        MessageCollection messages { get; set; }
        List<string> themes { get; set; } = new List<string>();
        public listbox(string folders)
        {
            InitializeComponent();
            Background = new ImageBrush(new BitmapImage(new Uri("https://i.pinimg.com/originals/79/7b/2c/797b2cca04907526c98b6e710fd46ae6.jpg")));
            download(folders);
        }
        async Task download(string folder)
        {
            pb.Visibility = Visibility.Visible;
            lb.Visibility = Visibility.Hidden;
            await Task.Run(() =>
            {
                messages = ImappHelper.GetMessagesForFolder(folder);
            });
            if (messages == null)
                return;
            pb.Visibility = Visibility.Hidden;
            lb.Visibility = Visibility.Visible;
            themes.Clear();
            lb.Items.Clear();   
            foreach (Message message in messages)
            {
                if (message.Subject == null)
                    themes.Add("<Без темы>");
                else
                themes.Add(message.Subject.ToString());
            }
            lb.ItemsSource = themes;
        }

        private void lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Mail.Message = messages[lb.SelectedIndex];
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("ChekMail.xaml", UriKind.Relative));
        }
    }
}
