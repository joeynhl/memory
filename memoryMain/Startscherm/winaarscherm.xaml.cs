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

        string winnaarNaam;
        int winnaarScore;
        string verliezerNaam;
        int verliezerScore;




        public winaarscherm(string naamWinnaar, int scoreWinnaar, string naamVerliezer, int scoreVerliezer)
        {
            winnaarNaam = naamWinnaar;
            winnaarScore = scoreWinnaar;
            verliezerNaam = naamVerliezer;
            verliezerScore = scoreVerliezer;
            InitializeComponent();
            
        }
        /// <summary>
        /// window loaded zodat de data wordt geladen waneer het scherm geladen wordt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(winnaarNaam == null || verliezerNaam == null)
            {
                return;
            }
            //als speler 1 wint vul naam in bij winaar + score.
            if (winnaarScore != verliezerScore)
            {
                speler1.Text = winnaarNaam;//vult naam in
                score11.Text = Convert.ToString(winnaarScore);//vult score in 
                scorenaam2 = verliezerNaam;//speler 2 naam (verliezer)

                // Voeg score toe
                addScore(winnaarNaam, winnaarScore, verliezerNaam, verliezerScore);
                Console.WriteLine("na de if elses: " + winnaarNaam + " " + winnaarScore + " " + verliezerNaam + " " + verliezerScore);
            } else
            {
                
                mylab1.Content = "Gelijkspel";
                speler1.Text = verliezerNaam + " & " + winnaarNaam;
                score11.Text = "4";
            }
        }

        private void addScore(string naam1, int score1, string naam2, int score2)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "highscores.txt";
            string score = naam1 + "," + score1 + "," + naam2 + "," + score2 + "\r\n";
            File.AppendAllText(path, score);

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
