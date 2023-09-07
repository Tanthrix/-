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
using System.Windows.Shapes;

namespace Calendar
{
    /// <summary>
    /// Логика взаимодействия для new_window.xaml
    /// </summary>
    public partial class new_window : Window
    {
        int vib = 0;
        public new_window()
        {
            InitializeComponent();
        }

        private void Click_1(object sender, RoutedEventArgs e)
        {
            hidden();
            imgi_add(0, 4);
            vib = 1;

        }
        private void Click_2(object sender, RoutedEventArgs e)
        {
            hidden();
            imgi_add(5, 8);
            vib = 2;
        }
        private void Click_3(object sender, RoutedEventArgs e)
        {
            hidden();
            imgi_add(8, 12);
            vib = 3;
        }
        void hidden()
        {
            bt1.Visibility = Visibility.Hidden;
            bt2.Visibility = Visibility.Hidden;
            bt3.Visibility = Visibility.Hidden;
            lb.Visibility = Visibility.Visible;
            bt_goto_back.Visibility = Visibility.Visible;
        }
        void visible()
        {
            bt1.Visibility = Visibility.Visible;
            bt2.Visibility = Visibility.Visible;
            bt3.Visibility = Visibility.Visible;
            lb.Visibility = Visibility.Hidden;
            bt_goto_back.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            visible();
        }
        void imgi_add(int a, int b)
        {
            lb.Items.Clear();
            for (int i = a; i < b; i++)
            {
                card_2 user = new card_2();
                user.title.Text = MainWindow.titles[i];
                user.image_new.Source = new BitmapImage(new Uri(MainWindow.images[i + 1], UriKind.Absolute));
                user.Height = 120;
                lb.Items.Add(user);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            new MainWindow().Show();
        }

        private void lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (vib == 1)
                user.users.Add(new user(MainWindow.date, MainWindow.images[lb.SelectedIndex + 1]));
            if (vib == 2)
                user.users.Add(new user(MainWindow.date, MainWindow.images[lb.SelectedIndex + 6]));
            if (vib == 3)
                user.users.Add(new user(MainWindow.date, MainWindow.images[lb.SelectedIndex + 9]));
            Hide();
            new MainWindow().Show();
        }
    }
}
