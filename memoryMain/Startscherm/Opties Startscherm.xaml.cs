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


        /// <summary>
        /// De functie die er voor zorgt dat de muziek begint met afspelen
        /// </summary>
        public void InitialiseerMuziek()
        {
            Sound.Open(new Uri(path));
            Sound.Play();
            // begin ook elke seconde te kijken of het liedje al voorbij is
            checkCurrentPos();
        }


        /// <summary>
        /// De click handler die er voor zorgt dat de muziek weer speelt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playMuziek_Click(object sender, RoutedEventArgs e)
        {
            // speelt de muziek af
            Sound.Play();
        }

        /// <summary>
        /// De click handler die er voor zorgt dat de muziek stopt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopMuziek_Click()
        {
            // stop de muziek
            Sound.Stop();
        }


        /// <summary>
        /// De functie die er voor zorgt dat er weer teruggegaan kan worden naar de mainwindow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Terug(object sender, RoutedEventArgs e)
        {
           // Keer terug naar de main window
            this.Hide();
           // main.Show();
           // this.Close();

        }


        /// <summary>
        /// De functie die elke seconde bekijkt of het liedje al is afgelopen en of het hij opnieuw afgespeeld moet worden
        /// </summary>
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



        /// <summary>
        /// De handler voor de slider die het volume aanpast
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
