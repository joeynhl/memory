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

namespace Startscherm
{
    /// <summary>
    /// Interaction logic for Opties_Startscherm.xaml
    /// </summary>
    /// 

    public partial class Opties_Startscherm : Window
    {

        MediaPlayer Sound = new MediaPlayer();
        string path = AppDomain.CurrentDomain.BaseDirectory + "/muziek/Sound1.wav";


        public Opties_Startscherm()
        {
            InitializeComponent();
            // Initialiseer de muziek wanneer dit scherm voor het eerst geopend word
            InitialiseerMuziek();
        }

        public void InitialiseerMuziek()
        {
            Sound.Open(new Uri(path));
            Sound.Play();
            // begin ook elke seconde te kijken of het liedje al voorbij is
            checkCurrentPos();
        }

        private void playMuziek_Click(object sender, RoutedEventArgs e)
        {
            // speelt de muziek af
            Sound.Play();
        }
        private void stopMuziek_Click(object sender, RoutedEventArgs e)
        {
            // stop de muziek
            Sound.Stop();
        }

        private void Terug(object sender, RoutedEventArgs e)
        {
           // Keer terug naar de main window
            this.Hide();
           // main.Show();
           // this.Close();

        }

        public async void checkCurrentPos()
        {
            await Task.Delay(1000);
            Duration len = Sound.NaturalDuration;
            TimeSpan pos = Sound.Position;

            // Zodra de positie van de player verder is dan het liedje speel dan opnieuw af
            if ( pos >= len) {
                Sound.Open(new Uri(path));
                Sound.Play();
            }
            checkCurrentPos();
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // slider value vanuit de xaml
            double value = slider.Value;
            Sound.Volume = value;
        }

        private void Media_Ended(object sender, EventArgs e)
        {
            Sound.Open(new Uri(path));
            Sound.Play();
        }


    }
}
