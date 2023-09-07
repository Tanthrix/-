using MVVM_7.VewModel.Helpers;
using MVVM_7.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Collections.ObjectModel;
using MVVM_7.View;
using System.Windows.Controls;
using System.Windows;
using System.Security.RightsManagement;

namespace MVVM_7.VewModel
{
    internal class MainViewModel : BindingHelper
    {
        #region Свойства
        private string new_type;
        public string New_type
        {
            get { return new_type; }
            set
            {
                new_type = value;
                OnPropertyChanged();
            }
        }
        private int index;
        public int Index
        {
            get { return index; }
            set
            {
                index = value;
                OnPropertyChanged();
            }
        }
        private int selected_index;
        public int Selected_index
        {
            get { return selected_index; }
            set
            {
                selected_index = value;
                OnPropertyChanged();
            }
        }
        private string name_record;
        public string Name_record
        {
            get { return name_record; }
            set
            {
                name_record = value;
                OnPropertyChanged();
            }
        }
        private string text_summ;
        public string Text_summ
        {
            get { return text_summ; }
            set
            {
                text_summ = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<User> users;
        public ObservableCollection<User> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<User> us;
        public ObservableCollection<User> Us
        {
            get { return us; }
            set
            {
                us = value; OnPropertyChanged();
            }
        }
        private DateTime dt;
        public DateTime Dt
        {
            get { return dt; }
            set
            {
                dt = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<string> naz;
        public ObservableCollection<string> Naz
        {
            get { return naz; }
            set { naz = value; OnPropertyChanged(); }
        }
        private string count;
        public string Count
        {
            get { return count; }
            set
            {
                count = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Команды
        public BindableCommand Vib_Data { get; set; }
        public BindableCommand write { get; set; }
        public BindableCommand Add_type { get; set; }
        public BindableCommand Close { get; set; }
        public BindableCommand Next { get; set; }
        public BindableCommand Add_record { get; set; }
        public BindableCommand Update_record { get; set; }
        public BindableCommand Set { get; set; }
        public BindableCommand Delete_record { get; set; }
        #endregion
        public MainViewModel()
        {
            Dt = DateTime.Now;
            Vib_Data = new BindableCommand(_ => VibData());
            Add_type = new BindableCommand(_ => add_type());
            Close = new BindableCommand(_ => exit());
            write = new BindableCommand(_ => Write());
            Next = new BindableCommand(_ => Continue());
            Set = new BindableCommand(_ => set());
            Update_record = new BindableCommand(_ => update_record());
            Delete_record = new BindableCommand(_ => delete_record());
            Us = Jsonka.Des<ObservableCollection<User>>("us.json") ?? new ObservableCollection<User>();
            Users = new ObservableCollection<User>();
            Naz = Jsonka.Des<ObservableCollection<string>>("naz.json") ?? new ObservableCollection<string>();
            repeat_write();
            Selected_index = -1;
            Index = -1;
            VibData();
        }
        void delete_record()
        {
            foreach (var user in Us)
            {
                if (user.Name == Name_record)
                {
                    Us.Remove(user);
                    VibData();
                    repeat_write();
                    Jsonka.Ser("us.json", Us);
                    break;
                }
            }
        }
        void set()
        {
            if (Index != -1)
            {
                Name_record = Us[Index].Name;
                for (int i = 0; i < Naz.Count; i++)
                {
                    if (Us[i] == Us[Index])
                    {
                        Selected_index = i; break;
                    }
                }
                Text_summ = us[Index].money.ToString();
            }
        }
        void repeat_write()
        {
            int a = 0;
            foreach (var b in Us)
            {
                if (b.isincome)
                    a += b.money;
                else
                    a -= b.money;
            }
            Count = a.ToString();
        }
        void update_record()
        {
            if (Index > -1)
            {
                string tmp = Users[Index].Name;
                bool go = true;
                if (Selected_index != -1 && Text_summ != null && Text_summ != "" && Name_record != null && Name_record != "")
                {
                    foreach (var b in Us)
                    {
                        if (b.Name == Name_record)
                        {
                            go = false;
                            break;
                        }
                    }
                    if (go)
                    {
                        if (Users.Count > 0)
                        {
                            foreach (var a in Us)
                            {
                                if (a.Name == tmp)
                                {
                                    try
                                    {
                                        a.Name = Name_record;
                                        a.money = Convert.ToInt32(Text_summ);
                                        a.Type = Naz[Selected_index];
                                        if (Text_summ[0] == '-')
                                            a.isincome = false;
                                        else
                                            a.isincome = true;
                                        repeat_write();
                                        Jsonka.Ser("us.json", Us);
                                        VibData();
                                        break;
                                    }
                                    catch { }
                                }
                            }
                        }
                    }
                }
            }
        }
        void exit()
        {
            Environment.Exit(0);
        }
        void add_type()
        {
            dialog s = new dialog();
            s.Show();
        }
        void Continue()
        {
            if (new_type != null && new_type != "")
            {
                bool go = true;
                foreach (var tmp in Naz)
                {
                    if (tmp == new_type)
                    {
                        go = false;
                        break;
                    }
                }
                if (go)
                    Naz.Add(new_type);
                Jsonka.Ser("naz.json", Naz);
            }
            MainWindow a = new MainWindow();
            a.Show();
        }
        void Write()
        {
            bool go = true;
            foreach (var item in Users)
            {
                if (item.Name == Name_record)
                {
                    go = false;
                    break;
                }
            }
            if (go)
            {
                if (Selected_index != -1 && Text_summ != null && Text_summ != "" && Name_record != null && Name_record != "")
                {
                    try
                    {
                        if (Convert.ToInt32(Text_summ) > 0)
                        {
                            Users.Add(new User(Dt, Name_record, Naz[Selected_index], Convert.ToInt32(Text_summ), true));
                            Us.Add(new User(Dt, Name_record, Naz[Selected_index], Convert.ToInt32(Text_summ), true));
                        }
                        else
                        {
                            Users.Add(new User(Dt, Name_record, Naz[Selected_index], Convert.ToInt32(Text_summ), false));
                            Us.Add(new User(Dt, Name_record, Naz[Selected_index], Convert.ToInt32(Text_summ), false));
                        }
                        Jsonka.Ser("us.json", Us);
                        repeat_write();
                    }
                    catch { }
                }
            }
        }
        void VibData()
        {
            if (dt.Date != null)
            {
                Vib(dt.Date);
            }
        }
        void Vib(DateTime time)
        {
            if (Us.Count > 0)
            {
                Users.Clear();
                foreach (User user in Us)
                {
                    if (time.Date == user.data.Value.Date)
                        Users.Add(user);
                }
            }
        }
        /*private void Button_Click(object sender, RoutedEventArgs e)
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
    }*/
    }
}
