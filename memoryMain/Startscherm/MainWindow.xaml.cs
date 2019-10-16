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
using save;

namespace Startscherm
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

        private void btnExit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void startBtn(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var newWindow = new spelen();
            newWindow.Show();
            this.Close();

        }

        private void hervatten(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var newWindow = new SaveFile();
            newWindow.Show();
            this.Close();



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Highscores_Click(object sender, RoutedEventArgs e)
        {
            var highScores = new Highscores();
            highScores.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void InitialiseerMuziek()
        {
            Sound.Open(new Uri("C:/Sound1.wav"));
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
