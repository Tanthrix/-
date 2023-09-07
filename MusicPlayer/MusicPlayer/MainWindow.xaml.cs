using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.WindowsAPICodePack.Dialogs;


namespace MusicPlayer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool repeat_mus = false;
        static bool random_music = false;
        static bool play_on = false;
        static ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
        static string[] images = new string[]
        {
            "https://sun9-34.userapi.com/impg/uJZmCh4tmD4-4Wg_gVD2bhXbggx4vyZ3inaP5Q/db1ZqWYfjBw.jpg?size=320x213&quality=96&crop=99,0,1082,720&sign=d8a45478783db10db9cfcc50dc873998&c_uniq_tag=rAwoZ2xi62I4IMGCxtHgH4n0YWdfUmYdS-ws86G2zro&type=album",
            "https://i.ytimg.com/vi/GMPvNT6QR1g/hqdefault.jpg",
            "https://i.ytimg.com/vi/q22uHBl9qxw/maxresdefault.jpg",
            "https://img3.goodfon.ru/original/1024x768/4/50/daft-punk-music-electronic-2861.jpg",
            "https://i.ytimg.com/vi/sFUtSyHc4JI/hqdefault.jpg"
        };
        static string folder = null;
        static List<Music> music;


        public MainWindow()
        {
            InitializeComponent();
            Background = new ImageBrush(new BitmapImage(new Uri("https://avatars.mds.yandex.net/i?id=9d304292a361255502ca20341ff9ea7b460f61c1-9244694-images-thumbs&n=13", UriKind.Absolute)));
            play.Background = new ImageBrush(new BitmapImage(new Uri("https://avatars.mds.yandex.net/i?id=b00840b1142e53302642290b4f0a081fa1d0bef0-8487401-images-thumbs&n=13", UriKind.Absolute)));
            random.Background = new ImageBrush(new BitmapImage(new Uri("https://avatars.mds.yandex.net/i?id=fa50b32658615499fa29b2de8ebe680066a1a063-8199407-images-thumbs&n=13", UriKind.Absolute)));
            repeat.Background = new ImageBrush(new BitmapImage(new Uri("https://avatars.mds.yandex.net/i?id=6bcc5979c8078d80ce0c303e0e30a0e4cd32b4e8-7952541-images-thumbs&n=13", UriKind.Absolute)));
            up.Background = new ImageBrush(new BitmapImage(new Uri("https://avatars.mds.yandex.net/i?id=4726fa9448ba0b3f0a029bca7e7efa4b9f3f08fa-8438571-images-thumbs&n=13", UriKind.Absolute)));
            down.Background = new ImageBrush(new BitmapImage(new Uri("https://avatars.mds.yandex.net/i?id=e79d1013b5de5d094bb851d70a15b6d98b278e08-8258696-images-thumbs&n=13", UriKind.Absolute)));

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            media.Position = new TimeSpan((int)slider.Value);
        }
        private void find_music_Click(object sender, RoutedEventArgs e)
        {
            if (Mus.Items.Count != 0)
            {
                Dispatcher.Invoke(() =>
                {
                    Mus.Items.Clear();
                    media.Stop();
                    min_mus.Content = null;
                    max_mus.Content = null;
                    slider.Value = 0;
                    imga.Source = null;
                });

            }
            CommonOpenFileDialog dlg = new CommonOpenFileDialog();
            dlg.IsFolderPicker = true;
            dlg.Title = "Выберите файл, где находится музыка";
            CommonFileDialogResult opened = dlg.ShowDialog();
            if (opened != CommonFileDialogResult.Ok)
                return;
            folder = dlg.FileName;
            music = new List<Music>();
            foreach (string file in Directory.GetFiles(folder))
            {
                if (file.EndsWith("mp3"))
                {
                    Music m = new Music();
                    m.path = file;
                    string name = null;
                    for (int i = file.Length - 5; i > -1; i--)
                    {
                        if (file[i] != '\\')
                            name += file[i];
                        else
                            break;
                    }
                    m.name = "";
                    for (int i = name.Length - 1; i > -1; i--)
                    {
                        m.name += name[i];
                    }
                    music.Add(m);
                }
            }
            foreach (Music a in music)
            {
                Mus.Items.Insert(Mus.Items.Count, a.name);
            }
            if (Mus.Items.Count == 0)
                return;
            Mus.SelectedIndex = 0;
            Mus.IsEnabled = true;
            slider.IsEnabled = true;
            play.IsEnabled = true;
            down.IsEnabled = true;
            up.IsEnabled = true;
            repeat.IsEnabled = true;
            random.IsEnabled = true;
        }
        private void Mus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            slider.Value = 0;
            if ((sender as ListBox).SelectedIndex != -1)
            {

                imga.Source = (ImageSource)imageSourceConverter.ConvertFrom(images[new Random().Next(0, images.Length)]);
                Musica.Content = Mus.SelectedItem;
                play_on = true;
                Thread mp = new Thread(Music_play);
                mp.Start();

            }
        }

        void Music_play()
        {
            Dispatcher.Invoke(() =>
            {
                media.Source = new Uri(music[Mus.SelectedIndex].path);
                media.Play();
            });

        }
        void go_slider()
        {
            while (play_on != false)
            {
                Dispatcher.Invoke(new Action(() =>
                {
                    slider.Value = media.Position.Ticks;
                    min_mus.Content = media.Position.ToString("mm\\:ss");
                }));
                Thread.Sleep(1000);
            }
        }
        void up_music()
        {
            if (random_music)
            {
                int b = Mus.SelectedIndex;
                Mus.SelectedIndex = new Random().Next(0, Mus.Items.Count);
                if (Mus.SelectedIndex == b)
                    up_music();
            }
            else
            {
                int b = Mus.SelectedIndex;
                if (Mus.SelectedIndex == Mus.Items.Count - 1)
                {
                    Mus.SelectedIndex = 0;
                }
                else
                {
                    Mus.SelectedIndex++;

                }
                if (repeat_mus)
                    Mus.SelectedIndex = b;
            }
            play_on = true;
            Music_play();
        }
        void down_music()
        {
            if (Mus.SelectedIndex == 0)
                Mus.SelectedIndex = Mus.Items.Count - 1;
            else
                Mus.SelectedIndex--;
            play_on = true;
            Music_play();

        }
        private void media_MediaOpened(object sender, RoutedEventArgs e)
        {
            slider.Maximum = media.NaturalDuration.TimeSpan.Ticks;
            max_mus.Content = media.NaturalDuration.TimeSpan.ToString("mm\\:ss");
            Thread gg = new Thread(go_slider);
            gg.Start();
        }

        private void media_MediaEnded(object sender, RoutedEventArgs e)
        {
            play_on = false;
            up_music();
        }

        private void repeat_Click(object sender, RoutedEventArgs e)
        {
            if (repeat_mus)
            {
                repeat_mus = false;
                repeat.ToolTip = "Включить повтор";
            }
            else
            {
                repeat_mus = true;
                repeat.ToolTip = "Выключить повтор";
            }
        }

        private void up_Click(object sender, RoutedEventArgs e)
        {
            media.Stop();
            up_music();
        }

        private void down_Click(object sender, RoutedEventArgs e)
        {
            down_music();
        }

        private void random_Click(object sender, RoutedEventArgs e)
        {
            if (random_music)
            {
                random_music = false;
                random.ToolTip = "Включить рандом";
            }
            else
            {
                random_music = true;
                random.ToolTip = "Выключить рандом";
            }
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (play_on)
                {
                    play.Background = new ImageBrush(new BitmapImage(new Uri("https://avatars.mds.yandex.net/i?id=4a7ef8430f41c79f11f47f0439d050281ebc7f9e-5233531-images-thumbs&n=13", UriKind.Absolute)));
                    play.ToolTip = "Продолжить";
                    play_on = false;
                    media.Stop();
                }
                else
                {
                    play.Background = new ImageBrush(new BitmapImage(new Uri("https://avatars.mds.yandex.net/i?id=b00840b1142e53302642290b4f0a081fa1d0bef0-8487401-images-thumbs&n=13", UriKind.Absolute)));
                    play.ToolTip = "Пауза";
                    play_on = true;
                    Music_play();
                    media.Position = new TimeSpan((int)slider.Value);
                    Thread gg = new Thread(go_slider);
                    gg.Start();
                }
            });
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                play_on = false;
                e.Cancel = true;
                Hide();
                media.Stop();
                Environment.Exit(0);
            });
        }
    }
    class Music
    {
        public string path;
        public string name;
    }
}
