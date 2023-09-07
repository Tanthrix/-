using function;
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

namespace Everydayning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int count = 0;
        public static string text = "";
        private static List<User> us = new List<User>();
        private static List<User> uses = new List<User>();
        public static List<string> nazvaniya = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            us = Jsonka.Des<List<User>>("us.json") ?? new List<User>();
            count = Jsonka.Read();
            l.nazvaniya = Jsonka.Des<List<string>>("nazvaniya.json") ?? new List<string>();
            if (l.nazvaniya.Count > 0)
                combobox2.ItemsSource = l.nazvaniya;
            rezult.Content = count.ToString();
            if (us.Count != 0)
            {
                Vib((DateTime)Date.SelectedDate);
                datagrid.ItemsSource = uses;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(textbox3.Text) > 0)
                {
                    us.Add(new User(Date.SelectedDate, textbox1.Text.ToString(), combobox2.SelectedItem.ToString(), Convert.ToInt32(textbox3.Text), true));
                    uses.Add(new User(Date.SelectedDate, textbox1.Text.ToString(), combobox2.SelectedItem.ToString(), Convert.ToInt32(textbox3.Text), true));
                }
                else
                {
                    us.Add(new User(Date.SelectedDate, textbox1.Text.ToString(), combobox2.SelectedItem.ToString(), Convert.ToInt32(textbox3.Text), false));
                    uses.Add(new User(Date.SelectedDate, textbox1.Text.ToString(), combobox2.SelectedItem.ToString(), Convert.ToInt32(textbox3.Text), false));
                }
                count += Convert.ToInt32(textbox3.Text);
                datagrid.ItemsSource = null;
                datagrid.ItemsSource = uses;
                rezult.Content = count.ToString();
                Jsonka.Ser("us.json", us);
                Jsonka.Write(count);
            }
            catch
            {
                MessageBox.Show("Произошла ошибка ввода");
            }
        }

        void Vib(DateTime time)
        {
            uses.Clear();
            foreach (User user in us)
            {
                if (time == user.data)
                    uses.Add(user);
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new new_type().Show();
            Close();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((datagrid.SelectedItem) != null)
            {
                textbox1.Text = ((User)datagrid.SelectedItem).Name.ToString();
                combobox2.SelectedItem = ((User)datagrid.SelectedItem).Type;
                textbox3.Text = ((User)datagrid.SelectedItem).money.ToString();
            }
        }

        private void datka_CalendarClosed(object sender, RoutedEventArgs e)
        {
            datagrid.ItemsSource = null;
            textbox1.Text = null;
            combobox2.SelectedIndex = -1;
            textbox3.Text = null;
            Vib((DateTime)Date.SelectedDate);
            datagrid.ItemsSource = uses;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            count -= Convert.ToInt32(((User)datagrid.SelectedItem).money);
            uses.Remove((User)datagrid.SelectedItem);
            us.Remove((User)datagrid.SelectedItem);
            Jsonka.Ser("us.json", us);
            Jsonka.Write(count);
            datagrid.ItemsSource = null;
            datagrid.ItemsSource = uses;
            rezult.Content = count.ToString();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            int j = 0;
            foreach (User s in us)
            {
                if (s == datagrid.SelectedItem)
                {
                    j = Convert.ToInt32(((User)datagrid.SelectedItem).money);
                    foreach (User w in uses)
                    {
                        if (w == s)
                        {
                            w.Name = textbox1.Text.ToString();
                            w.Type = combobox2.SelectedItem.ToString();
                            w.money = Convert.ToInt32(textbox3.Text);
                            break;
                        }
                    }
                    s.Name = textbox1.Text.ToString();
                    s.Type = combobox2.SelectedItem.ToString();
                    s.money = Convert.ToInt32(textbox3.Text);
                    break;
                }
            }
            count += -(j - Convert.ToInt32(textbox3.Text));
            Jsonka.Ser("us.json", us);
            Jsonka.Write(count);
            datagrid.ItemsSource = null;
            datagrid.ItemsSource = uses;
            rezult.Content = count.ToString();
        }
    }
    class User
    {
        public string Name { get; set; }
        public string Type { get; set; }
        private int Money;
        public int money
        {
            get { return Money; }
            set
            {
                Money = Math.Abs(value);
            }
        }
        public bool isincome { get; set; }
        public DateTime? data;

        public User(DateTime? selectedDate, string text1, string v, int text2, bool isin)
        {
            data = selectedDate;
            Name = text1;
            Type = v;
            money = text2;
            isincome = isin;
        }
    }
    class l
    {
        public static List<string> nazvaniya = new List<string>();
    }
}
