using function;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Everydayning
{
    /// <summary>
    /// Логика взаимодействия для new_type.xaml
    /// </summary>
    public partial class new_type : Window
    {
        public new_type()
        {
            InitializeComponent();
            textbox.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textbox.Text == "")
            {
                MessageBox.Show("Поле не заполнено");
                return;
            }
            if (l.nazvaniya.Contains(textbox.Text.ToString()))
            {
                MessageBox.Show("Такой тип уже есть");
                return;
            }
            l.nazvaniya.Add(textbox.Text);
            Jsonka.Ser("nazvaniya.json", l.nazvaniya);
            Hide();
            new MainWindow().Show();
        }
    }
}
