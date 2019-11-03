using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Startscherm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer Sound = new MediaPlayer();
        private Opties_Startscherm opties = new Opties_Startscherm();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnExit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void startBtn(object sender, RoutedEventArgs e)
        {
            Thema_opties opties = new Thema_opties();

            this.Hide();
            opties.Show();
            this.Close();
        }

        /// <summary>
        /// Opent een venster waarmee de gebruiker een sav bestand kan openen waarmee hij vervolgens
        /// het spel kan hervatten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hervatten(object sender, RoutedEventArgs e)
        {
            speelveld speelveld = new speelveld();
            Ingame_menu Ingame_menu = new Ingame_menu();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string pathname = openFileDialog.FileName;//maakt een pad aan voor de file name
                List<string> lines = File.ReadAllLines(pathname).ToList();//lijst maken voor de filename waar alle lijnen gelezen worden

                foreach (var line in lines)
                {
                    string[] entries = line.Split(',');//maakt een nieuwe arr aan die het bestand splits op komma's

                    //plaats de juiste index op de waarde van het speelveld
                    speelveld.Speler1_naam.Text = entries[17];
                    speelveld.speler1Score.Text = entries[18];
                    speelveld.Speler2_naam.Text = entries[19];
                    speelveld.speler2Score.Text = entries[20];
                    speelveld.theme = entries[21];
                    speelveld.minutes = Convert.ToInt32(entries[22]);
                    speelveld.seconds = Convert.ToInt32(entries[23]);
                    speelveld.player = Convert.ToInt32(entries[24]);
                    speelveld.naam1 = entries[17];
                    speelveld.naam2 = entries[19];

                    speelveld.minutensreset = Convert.ToInt32(entries[25]);
                    speelveld.secondesreset = Convert.ToInt32(entries[26]);

                    speelveld.PlayerOneScore = Convert.ToInt32(entries[18]);
                    speelveld.PlayerTwoScore = Convert.ToInt32(entries[20]);

                    //kijkt welke speler aan de beurt is en vult daarna de juiste waarde in
                    if (speelveld.player == 1)
                    {
                        speelveld.Beurt.Text = "Beurt:" + entries[17];
                    }
                    else
                    {
                        speelveld.Beurt.Text = "Beurt:" + entries[19];
                    }
                    //kijkt of er een sav geladen in een geeft deze waarde mee aan het speelveld
                    speelveld.CheckSaveFile = true;

                    int k = 0;
                    //vult 2d arr voor het speelveld voor het hervatten
                    for (int i = 0; i < speelveld.multiplecards.GetLength(0); i++)
                    {
                        for (int j = 0; j < speelveld.multiplecards.GetLength(1); j++)
                        {
                            speelveld.SavedCards[i, j] = entries[k]; // put cards in the 2d array
                            k++;
                        }
                    }
                }

                this.Close();
                speelveld.Show();
            }
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

        private void Opties(object sender, RoutedEventArgs e)
        {
            //opties.Show();
            //Thema_opties opties = new Thema_opties();

            //this.Hide();
            opties.Show();
            //this.Close();
        }
    }
}