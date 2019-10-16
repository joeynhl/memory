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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void OnLoad(object sender, RoutedEventArgs e)
        {
            dt.Tick += dtTicker;
        }

        DispatcherTimer dt = new DispatcherTimer();
        private int minutes = 5;
        private int seconds = 0;

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
            //https://www.youtube.com/watch?v=QkT8fgoFz3g

        }
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
        private void Stopclick(object sender, EventArgs e)
        {
            dt.Tick -= dtTicker;
            dt.Stop();
            GoButton.Height = 30;
            GoButton.Width = 50;
            StopButton.Height = 0;
            StopButton.Width = 0;
        }

        private void Minutes_Changed(object sender, TextChangedEventArgs e)
        {
            //MinutesBox.Text = minutes.ToString();
            if (MinutesBox.Text == "")
            {
                MinutesBox.Text =  0.ToString();
                MinutesBox.SelectionStart = MinutesBox.Text.Length;
                MinutesBox.SelectionLength = 0;
            }
            else if (MinutesBox.Text != "0")
            {
                minutes = Convert.ToInt32(MinutesBox.Text);
                MinutesBox.Text = minutes.ToString();
                MinutesBox.SelectionStart = MinutesBox.Text.Length;
                MinutesBox.SelectionLength = 0;
            }
            else {
                minutes = Convert.ToInt32(MinutesBox.Text);
                MinutesBox.SelectionStart = MinutesBox.Text.Length;
                MinutesBox.SelectionLength = 0;
            }
        }

        private void Seconds_Changed(object sender, TextChangedEventArgs e)
        {
            //SecondsBox.Text = seconds.ToString();
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
                seconds = Convert.ToInt32(SecondsBox.Text);
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
                else {
                SecondsBox.Text = seconds.ToString();
                SecondsBox.SelectionStart = SecondsBox.Text.Length;
                SecondsBox.SelectionLength = 0;
                }

            }
            else
            {
                seconds = Convert.ToInt32(SecondsBox.Text);
            }
            
                //seconds = 59;
                //SecondsBox.Text = seconds.ToString();
        }
    }
}
