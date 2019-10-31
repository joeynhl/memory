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
using Microsoft.Win32;
using Path = System.IO.Path;
using save;
using System.IO;
using System.Windows.Threading;

namespace Startscherm
{
    /// <summary>
    /// Interaction logic for Ingame_menu.xaml
    /// </summary>
    public partial class Ingame_menu : Window
    {
        speelveld speelveld = new speelveld();
        public string naam1 { get; internal set; }
        public string naam2 { get; internal set; }

        public string score1 { get; internal set; }
        public string score2 { get; internal set; }
        public int minutes { get; internal set;  }
        public int seconds { get; internal set; }
        public DispatcherTimer dt { get; internal set; }
        public string[,] cards { get; internal set; }
        public string themaNaam { get; internal set; }
        public List<string> checklist { get; internal set; }

        public Ingame_menu()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {  

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            speelveld speelveld = new speelveld();


                Speler1_naam.Text =  naam1;
                Speler2_naam.Text = naam2;
                speler1Score.Text = score1;
                speler2Score.Text = score2;

            if (minutes < 0)
            {
                seconds = 0;
                minutes = 0;
            }
            else
            {
                TimerLabel.Content = minutes.ToString() + ":" + seconds.ToString();
                if (seconds < 0)
                {
                    seconds = 59;
                    minutes--;
                }
                if (minutes < 0)
                {
                    seconds = 0;
                    minutes = 0;
                }
                else
                {
                    if (seconds < 10 & seconds > -1)
                    {
                        TimerLabel.Content = minutes.ToString() + ":0" + seconds.ToString();
                    }
                    else
                    {
                        TimerLabel.Content = minutes.ToString() + ":" + seconds.ToString();
                    }
                }
            }
            if (minutes == 0 & seconds == 0)
            {
                //TimerLabel Content = "TIME UP";
                //System.Environment.Exit(1);
            }
        }

        private void Speler1_naam_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            MainWindow mainWindow = new MainWindow();

            SaveFileDialog saveFileDialog = new SaveFileDialog();


           

            saveFileDialog.Filter = "save file (*.sav)|*.sav";
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            saveFileDialog.InitialDirectory = path;
            if (saveFileDialog.ShowDialog() == true)
            {

                this.naam1 = naam1;
                this.naam2 = naam2;
                this.score1 = score1;
                this.score2 = score2;
                this.themaNaam = themaNaam;
                this.minutes = minutes;
                this.seconds = seconds;
                this.dt = dt;

                string images = "";

                foreach(string image in checklist)
                {
                    images += image + ",";

                }

                string[] createText = { images + "," + naam1 + "," + score1 + "," + naam2 + "," + score2 + "," + themaNaam + "," + minutes + "," + seconds + "," + dt };
                

                File.WriteAllLines(saveFileDialog.FileName, createText);

                this.Close();
                mainWindow.Show();
            }

        }

        private void Frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
        private void Resetten(object sender, RoutedEventArgs e)
        {
            speelveld speelveld = new speelveld();
            speelveld.naam1 = naam1;
            speelveld.naam2 = naam2;

            speelveld.Speler1_naam.Text = naam1;
            speelveld.Speler2_naam.Text = naam2;

            this.Hide();
            speelveld.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Zorgt voor de kloklogica en het correct weergeven van de tijd. Het programma
        /// loopt elke seconde door deze code.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtTicker(object sender, EventArgs e)
        {
            if (minutes < 0)
            {
                seconds = 0;
                minutes = 0;
            }
            else
            {
                TimerLabel.Content = minutes.ToString() + ":" + seconds.ToString();
                seconds--;
                if (seconds < 0)
                {
                    seconds = 59;
                    minutes--;
                }
                if (minutes < 0)
                {
                    seconds = 0;
                    minutes = 0;
                }
                else
                {
                    if (seconds < 10 & seconds > -1)
                    {
                        TimerLabel.Content = minutes.ToString() + ":0" + seconds.ToString();
                    }
                    else
                    {
                        TimerLabel.Content = minutes.ToString() + ":" + seconds.ToString();
                    }
                }
            }
            if (minutes == 0 & seconds == 0)
            {
                //TimerLabel.Content = "TIME UP";
                System.Environment.Exit(1);
            }
        }

        private void Hervatten(object sender, RoutedEventArgs e)
        {
            speelveld.Speler1_naam.Text = naam1;
            speelveld.Speler2_naam.Text = naam2;
            speelveld.speler1Score.Text = score1;
            speelveld.speler2Score.Text = score2;
            speelveld.minutes = minutes;
            speelveld.seconds = seconds;


            if (seconds < 10 & seconds > -1)
            {
                TimerLabel.Content = minutes.ToString() + ":0" + seconds.ToString();
            }
            else
            {
                TimerLabel.Content = minutes.ToString() + ":" + seconds.ToString();
            }
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();

            this.Hide();
            speelveld.Show();
            this.Close();

        }

        private void Afsluiten(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
