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

namespace memoryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer Sound = new MediaPlayer();
        public MainWindow()
        {
            InitializeComponent();
            InitialiseerMuziek();
        }

        private void ExitApplication_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void InitialiseerMuziek()
        {
            Sound.Open(new Uri("C:/Sound1.wav")) ;
            Sound.Play();
        }

        private void playMuziek_Click(object sender, RoutedEventArgs e)
        {
            Sound.Play();
        }
        private void stopMuziek_Click(object sender, RoutedEventArgs e)
        {
            Sound.Stop();
        }
    }
}
