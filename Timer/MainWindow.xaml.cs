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
                TimerLabel.Content = "TIME UP";
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
    }
}