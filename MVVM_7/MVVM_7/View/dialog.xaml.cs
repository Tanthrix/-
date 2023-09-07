using MVVM_7.VewModel;
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

namespace MVVM_7.View
{
    /// <summary>
    /// Логика взаимодействия для dialog.xaml
    /// </summary>
    public partial class dialog : Window
    {
        public dialog()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
        private void CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void Hide(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }   
    }
}
