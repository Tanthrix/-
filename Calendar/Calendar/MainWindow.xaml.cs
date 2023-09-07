using System;
using function;
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

namespace Calendar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string[] images = new string[]
        {
            "https://avatars.mds.yandex.net/i?id=a39c8b5a70b87bee37660dd088296144_sr-5222188-images-thumbs&n=13",

            "https://avatars.mds.yandex.net/i?id=7d14ee7a29176744b17c965362cfa33a_sr-5179078-images-thumbs&n=13",
            "https://avatars.mds.yandex.net/i?id=03d56927b8b2cc8bb8f03f7369fb14d7_sr-4032982-images-thumbs&n=13",
            "https://avatars.mds.yandex.net/i?id=9ab8a5166861c0255ba5d0bd5270a0d2_sr-4519141-images-thumbs&n=13",
            "https://avatars.mds.yandex.net/i?id=fa0b00520f1c9044e20a1531433131e5_sr-4577918-images-thumbs&n=13",
            "https://avatars.mds.yandex.net/i?id=394347231545bc38aa4bf38ddadebea9-5241728-images-thumbs&n=13",

            "https://avatars.mds.yandex.net/i?id=747e04b0e1dce0eca4739246fe756e68_sr-4841251-images-thumbs&n=13",
            "https://avatars.mds.yandex.net/i?id=a293cd5befbfa995e1453dbd0cbf7e15-5236515-images-thumbs&n=13",
            "https://avatars.mds.yandex.net/i?id=ed787488ef4d8462eae303220cc73062-4787453-images-thumbs&n=13",

            "https://avatars.mds.yandex.net/i?id=4e0dc8473c8b00b02a7e7b1962b36daa_sr-3618094-images-thumbs&n=13",
            "https://avatars.mds.yandex.net/i?id=5f74066d9b6f07747fd04c4a5c017489_sr-4809955-images-thumbs&n=13",
            "https://avatars.mds.yandex.net/i?id=7a2e85e6653536184a16776f09803e45_sr-6003349-images-thumbs&n=13",
            "https://avatars.mds.yandex.net/i?id=dcbd8479250a40a1dfb3d6e1c35a6000-5276687-images-thumbs&n=13"

        };
        public static string[] titles = new string[]
        {
            "Велосидепездист",
            "Теннис",
            "Воллейбольчик",
            "Шахматы",
            "Футбольчик",

            "Шашлык",
            "Бугер",
            "Пицца",

            "С++",
            "Pyrhon",
            "ЖИ ЕС",
            "С#"

        };
        string[] months = new string[] { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
        public static DateTime date = DateTime.Now;
        public MainWindow()
        {
            InitializeComponent();
            if (user.users.Count > 0)
            {
                user.users = user.users.Distinct().ToList();
                Jsonka.Ser("user.json", user.users);
            }
            else
                user.users = Jsonka.Des<List<user>>("user.json") ?? new List<user>();
            update();
        }
        void update()
        {
            month.Text = months[Convert.ToInt32(date.Month) - 1].ToString();
            wrappanel.Children.Clear();
            for (int i = 0; i < DateTime.DaysInMonth(DateTime.Now.Year, date.Month); i++)
            {
                card one = new card();
                one.tb.Text = (i + 1).ToString();
                one.Height = 95;
                one.img.Source = new BitmapImage(new Uri(images[0], UriKind.Absolute));

                foreach (user user in user.users)
                {
                    if (i + 1 == Convert.ToInt32(user.date.Day) && user.date.Month == date.Month && user.date.Year == date.Year)
                    {
                        for (int j = 0; j < images.Length; j++)
                        {
                            if (user.img == images[j])
                            {
                                one.img.Source = new BitmapImage(new Uri(images[j], UriKind.Absolute));
                                one.Background = new SolidColorBrush(Color.FromArgb(54, 95, 138, 0));
                            }
                        }
                    }
                }
                wrappanel.Children.Add(one);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int b = date.Year;
            int a = date.Month;
            if (a + 1 > 12)
            {
                a = 1;
                b++;
            }
            else
                a++;
            date = new DateTime(b, a, date.Day);
            update();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int b = date.Year;
            int a = date.Month;
            if (a - 1 < 1)
            {
                a = 12;
                b--;
            }
            a--;
            date = new DateTime(b, a, date.Day);
            update();
        }

        private void wrappanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Date_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (Date.SelectedDate != null)
            {
                date = Date.SelectedDate.Value;
                update();
            }
        }
    }
    public class user
    {
        public user(DateTime date, string img)
        {
            this.date = date;
            this.img = img;
            is_vib = true;
        }

        public DateTime date { get; set; }
        public string img { get; set; }
        public bool is_vib { get; set; }
        public static List<user> users = new List<user>();
    }
}
