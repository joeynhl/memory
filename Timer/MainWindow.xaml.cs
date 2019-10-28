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
using System.Windows.Threading;

namespace Timer2
{
    /// <summary>
    /// Interactie logica for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Maakt een timer aan en de variabelen voor minuten en seconden
        /// </summary>
        DispatcherTimer dt = new DispatcherTimer();
        private int minutes = 0;
        private int seconds = 0;

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

        /// <summary>
        /// Zorgt ervoor dat de klok start of verder gaat nadat er op de startknop is geklikt.
        /// Zorgt er ook voor dat de stopknop wordt weergegeven ipv de startknop.
        /// Zorgt er ook nog voor dat het tijd-instelmenu verdwijnd.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoClick(object sender, EventArgs e)
        {
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
            GoButton.Height = 0;
            GoButton.Width = 0;
            StopButton.Height = 30;
            StopButton.Width = 50;

            Minuten.Height = 0;
            Minuten.Width = 0;
            Seconden.Height = 0;
            Seconden.Width = 0;
            MinutesBox.Height = 0;
            MinutesBox.Width = 0;
            SecondsBox.Height = 0;
            SecondsBox.Width = 0;
        }

        /// <summary>
        /// Zorgt ervoor dat de timer stopt wanneer er op de stopknop geklikt wordt.
        /// Zorgt er ook voor dat de startknop weer verschijnt en de stopknop verdwijnt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stopclick(object sender, EventArgs e)
        {
            dt.Tick -= dtTicker;
            dt.Stop();
            GoButton.Height = 30;
            GoButton.Width = 50;
            StopButton.Height = 0;
            StopButton.Width = 0;
        }

        /// <summary>
        /// Dit zorgt ervoor dat de ingevoerde minuten worden ingevoerd in de timer.
        /// Hert controleert ook of de input van de gebruiker wel juist is.
        /// Voor verschillende soorten verkeerde inputs doet het programma iets anders.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Minutes_Changed(object sender, TextChangedEventArgs e)
        {
            if (MinutesBox.Text == "")
            {
                MinutesBox.Text = 0.ToString();
                MinutesBox.SelectionStart = MinutesBox.Text.Length;
                MinutesBox.SelectionLength = 0;
            }
            else if (MinutesBox.Text != "0")
            {

                try
                {
                    minutes = Convert.ToInt32(MinutesBox.Text);
                }
                catch (System.FormatException)
                {
                    minutes = 0;
                }
                catch (System.OverflowException)
                {
                    minutes = 2147483647;
                }

                MinutesBox.Text = minutes.ToString();
                MinutesBox.SelectionStart = MinutesBox.Text.Length;
                MinutesBox.SelectionLength = 0;

            }
            else
            {
                minutes = Convert.ToInt32(MinutesBox.Text);
                MinutesBox.SelectionStart = MinutesBox.Text.Length;
                MinutesBox.SelectionLength = 0;
            }
        }

        /// <summary>
        /// Dit zorgt ervoor dat de ingevoerde seconden worden ingevoerd in de timer.
        /// Hert controleert ook of de input van de gebruiker wel juist is.
        /// Voor verschillende soorten verkeerde inputs doet het programma iets anders.
        /// Bij teveel ingevoerde seconden zet die het aantal seconden om in extra minuten.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Seconds_Changed(object sender, TextChangedEventArgs e)
        {
            if (SecondsBox.Text == "")
            {
                SecondsBox.Text = 0.ToString();
                seconds = Convert.ToInt32(SecondsBox.Text);
                SecondsBox.SelectionStart = SecondsBox.Text.Length;
                SecondsBox.SelectionLength = 0;
            }
            else if (SecondsBox.Text != "0")
            {
                SecondsBox.SelectionStart = SecondsBox.Text.Length;
                SecondsBox.SelectionLength = 0;

                try
                {
                    seconds = Convert.ToInt32(SecondsBox.Text);
                }
                catch (System.FormatException)
                {
                    seconds = 0;
                }
                catch (System.OverflowException)
                {
                    seconds = 59;
                }
                if (seconds > 59)
                {
                    int extraminutes = 0;
                    for (extraminutes = 0; seconds > 59; extraminutes++)
                    {
                        seconds -= 60;
                    }
                    minutes += extraminutes;
                    MinutesBox.Text = minutes.ToString();
                    SecondsBox.Text = seconds.ToString();
                    SecondsBox.SelectionStart = SecondsBox.Text.Length;
                    SecondsBox.SelectionLength = 0;

                }
                else
                {
                    SecondsBox.Text = seconds.ToString();
                    SecondsBox.SelectionStart = SecondsBox.Text.Length;
                    SecondsBox.SelectionLength = 0;
                }

            }
            else
            {
                seconds = Convert.ToInt32(SecondsBox.Text);
            }
        }
    }
}
