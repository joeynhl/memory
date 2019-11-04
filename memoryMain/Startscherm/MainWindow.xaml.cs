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

        /// <summary>
        /// sluit het spel af
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        /// <summary>
        /// Navigeert naar 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startBtn(object sender, RoutedEventArgs e)
        {
            Thema_opties opties = new Thema_opties();
            opties.Show();
            //this.Close(); zou hier moeten staan maar omdat er een terug knop is wordt hij niet gesloten en is dit een slechte oplossing voor een probleem
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
                    speelveld.Speler1_naam.Text = entries[17]; //set naam van speler 1 in het speelveld
                    speelveld.speler1Score.Text = entries[18]; //set score van speler 1 in het speelveld
                    speelveld.Speler2_naam.Text = entries[19]; //set naam van speler 2 in het speelveld
                    speelveld.speler2Score.Text = entries[20]; //set score van speler 2 in het speelveld
                    speelveld.theme = entries[21]; // Het thema
                    speelveld.minutes = Convert.ToInt32(entries[22]); // aantal minuten
                    speelveld.seconds = Convert.ToInt32(entries[23]); // aantal seconden
                    speelveld.player = Convert.ToInt32(entries[24]); // speler die aan de beurt is
                    speelveld.naam1 = entries[17]; // naam van speler 1 
                    speelveld.naam2 = entries[19]; // naam van speler 2 

                    speelveld.minutensreset = Convert.ToInt32(entries[25]);
                    speelveld.secondesreset = Convert.ToInt32(entries[26]);

                    speelveld.PlayerOneScore = Convert.ToInt32(entries[18]); // set score voor speler 1
                    speelveld.PlayerTwoScore = Convert.ToInt32(entries[20]); // set score voor speler 2

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

                
                speelveld.Show();
            }
        }


        /// <summary>
        /// Laat highscores zien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Highscores_Click(object sender, RoutedEventArgs e)
        {
            var highScores = new Highscores();
            highScores.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Navigeer naar opties scherm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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