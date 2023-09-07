using function;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
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
        public static List<string> naz = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            if (!File.Exists("them.txt"))
                File.WriteAllText("them.txt", "");
            if (!File.Exists("language.txt"))
                File.WriteAllText("language.txt", "");
            set_them_and_language(File.ReadAllText("them.txt"), File.ReadAllText("language.txt"));
            us = Jsonka.Des<List<User>>("us.json") ?? new List<User>();
            count = Jsonka.Read();
            Use.naz = Jsonka.Des<List<string>>("naz.json") ?? new List<string>();
            if (Use.naz.Count > 0)
                cb2.ItemsSource = Use.naz;
            cena.Content = count.ToString();
            if (us.Count != 0)
            {
                Vib((DateTime)datka.SelectedDate);
                dg.ItemsSource = uses;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(tb3.Text) > 0)
                {
                    us.Add(new User(datka.SelectedDate, tb1.Text.ToString(), cb2.SelectedItem.ToString(), Convert.ToInt32(tb3.Text), true));
                    uses.Add(new User(datka.SelectedDate, tb1.Text.ToString(), cb2.SelectedItem.ToString(), Convert.ToInt32(tb3.Text), true));
                }
                else
                {
                    us.Add(new User(datka.SelectedDate, tb1.Text.ToString(), cb2.SelectedItem.ToString(), Convert.ToInt32(tb3.Text), false));
                    uses.Add(new User(datka.SelectedDate, tb1.Text.ToString(), cb2.SelectedItem.ToString(), Convert.ToInt32(tb3.Text), false));
                }
                count += Convert.ToInt32(tb3.Text);
                dg.ItemsSource = null;
                dg.ItemsSource = uses;
                cena.Content = count.ToString();
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
            new dialog().Show();
            Close();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((dg.SelectedItem) != null)
            {
                tb1.Text = ((User)dg.SelectedItem).Name.ToString();
                cb2.SelectedItem = ((User)dg.SelectedItem).Type;
                tb3.Text = ((User)dg.SelectedItem).money.ToString();
            }
        }

        private void datka_CalendarClosed(object sender, RoutedEventArgs e)
        {
            dg.ItemsSource = null;
            tb1.Text = null;
            cb2.SelectedIndex = -1;
            tb3.Text = null;
            Vib((DateTime)datka.SelectedDate);
            dg.ItemsSource = uses;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            count -= Convert.ToInt32(((User)dg.SelectedItem).money);
            uses.Remove((User)dg.SelectedItem);
            us.Remove((User)dg.SelectedItem);
            Jsonka.Ser("us.json", us);
            Jsonka.Write(count);
            dg.ItemsSource = null;
            dg.ItemsSource = uses;
            cena.Content = count.ToString();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            int j = 0;
            foreach (User s in us)
            {
                if (s == dg.SelectedItem)
                {
                    j = Convert.ToInt32(((User)dg.SelectedItem).money);
                    foreach (User w in uses)
                    {
                        if (w == s)
                        {
                            w.Name = tb1.Text.ToString();
                            w.Type = cb2.SelectedItem.ToString();
                            w.money = Convert.ToInt32(tb3.Text);
                            break;
                        }
                    }
                    s.Name = tb1.Text.ToString();
                    s.Type = cb2.SelectedItem.ToString();
                    s.money = Convert.ToInt32(tb3.Text);
                    break;
                }
            }
            count += -(j - Convert.ToInt32(tb3.Text));
            Jsonka.Ser("us.json", us);
            Jsonka.Write(count);
            dg.ItemsSource = null;
            dg.ItemsSource = uses;
            cena.Content = count.ToString();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("them.txt", "default");
            set_them_and_language(File.ReadAllText("them.txt"), File.ReadAllText("language.txt"));
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("them.txt", "light");
            set_them_and_language(File.ReadAllText("them.txt"), File.ReadAllText("language.txt"));
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("them.txt", "dark");
            set_them_and_language(File.ReadAllText("them.txt"), File.ReadAllText("language.txt"));
        }
        void set_them_and_language(string them, string lang)
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            if (them == "" || lang == "")
            {
                Application.Current.Resources.MergedDictionaries.Insert(0, new ResourceDictionary { Source = new Uri("pack://application:,,,/language;component/eng.xaml") });
                File.WriteAllText("language.txt", "eng");
                File.WriteAllText("them.txt", "default");
                return;
            }
            List<string> title = new List<string>()
                            {
                                "Сбросить темы",
                                "Поставить светлую тему",
                                "Поставить темную тему",
                                "Поставить русский язык",
                                "Поставить английский язык",
                                "Set a deafault thems",
                                "Set the light them",
                                "Set the dark them",
                                "Set russian language",
                                "Set english language"
                            };
            if (lang == "eng")
                for (int i = title.Count / 2; i < title.Count; i++)
                    (cm.Items[i - 5] as MenuItem).Header = title[i];
            if (lang == "ru")
                for (int i = 0; i < title.Count / 2; i++)
                    (cm.Items[i] as MenuItem).Header = title[i];
            if (them == "dark")
                Application.Current.Resources.MergedDictionaries.Insert(0, new ResourceDictionary { Source = new Uri("pack://application:,,,/themes;component/dark.xaml") });
            if (them == "light")
                Application.Current.Resources.MergedDictionaries.Insert(0, new ResourceDictionary { Source = new Uri("pack://application:,,,/themes;component/light.xaml") });
            if (them != "default")
                Application.Current.Resources.MergedDictionaries.Insert(1, new ResourceDictionary { Source = new Uri($"pack://application:,,,/language;component/{lang}.xaml") });
            else
                Application.Current.Resources.MergedDictionaries.Insert(0, new ResourceDictionary { Source = new Uri($"pack://application:,,,/language;component/{lang}.xaml") });
        }

        private void Set_language_ru(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("language.txt", "ru");
            set_them_and_language(File.ReadAllText("them.txt"), File.ReadAllText("language.txt"));
        }

        private void Set_language_eng(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("language.txt", "eng");
            set_them_and_language(File.ReadAllText("them.txt"), File.ReadAllText("language.txt"));
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
    class Use
    {
        public static List<string> naz = new List<string>();
    }
}
