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

namespace Calendar
{
    /// <summary>
    /// Логика взаимодействия для card.xaml
    /// </summary>
    public partial class card : UserControl
    {
        public static int image_number;
        public card()
        {
            InitializeComponent();
        }

        private async void hover(object sender, MouseEventArgs e)
        {
            MainWindow.date = new DateTime(MainWindow.date.Year, MainWindow.date.Month,Convert.ToInt32(tb.Text));
            new new_window().Show();
        }
    }
}
