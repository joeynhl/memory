using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for winaarscherm.xaml
    /// </summary>
    public partial class winaarscherm : Window
    {
        public string naam1 { get; internal set; }
        public string naam2 { get; internal set; }
        public string scorenaam1 { get; internal set; }
        public string scorenaam2 { get; internal set; }
        public int score1 { get; internal set; }
        public int score2 { get; internal set; }




       

        public winaarscherm(int score)
        {
            score1 = score;
            score2 = score;
            InitializeComponent();
            
        }
        /// <summary>
        /// window loaded zodat de data wordt geladen waneer het scherm geladen wordt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //als speler 1 wint vul naam in bij winaar + score.
            if (naam1 != null)
            {
                speler1.Text = naam1;//vult naam in
                score11.Text = Convert.ToString(score1);//vult score in 
                scorenaam2 = scorenaam2;//speler 2 naam (verliezer)

            }
            else if (naam2 != null)//als speler 2 wint 
            {
                speler1.Text = naam2;//vult naam in 
                score11.Text = Convert.ToString(score2);//vult score van speler 2 in
                scorenaam1 = scorenaam1;//speler 1 naam (verliezer)
                Console.WriteLine(scorenaam1);
                addScore(naam2, score2, scorenaam1, score1);
                Console.WriteLine("na de addscore writeline: " + naam2 + " " + score2 + " " + scorenaam1 + " " + score1);
            }
            else//gelijkspel 4 punten x 4 punten
            {
                speler1.Text = "gelijkspel";
                score11.Text = "4";
            }

            //addScore(naam1, score1, scorenaam2, score2);
            //Console.WriteLine("na de if elses: " + naam2 + " " + score2 + " " + scorenaam1 + " " + score1);

        }

        private void addScore(string scorenaam1, int score1, string naam2, int score2)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "highscores.txt";
            string score = naam2 + "," + score1 + "," + scorenaam1 + "," + score1;
            File.WriteAllText(path, score);

        }

        private void speler1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void speler2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            this.Hide();
            mainWindow.Show();
            this.Close();
        }
    }
}
