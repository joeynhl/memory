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

        private void hervatten(object sender, RoutedEventArgs e)
        {
            speelveld speelveld = new speelveld();
            Ingame_menu Ingame_menu = new Ingame_menu();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string pathname = openFileDialog.FileName;
                List<string> lines = File.ReadAllLines(pathname).ToList();

                foreach (var line in lines)
                {
                    string[] entries = line.Split(',');

                    speelveld.Speler1_naam.Text = entries[17];
                    speelveld.speler1Score.Text = entries[18];
                    speelveld.Speler2_naam.Text = entries[19];
                    speelveld.speler2Score.Text = entries[20];
                    speelveld.theme = entries[21];
                    speelveld.minutes = Convert.ToInt32(entries[22]);
                    speelveld.seconds = Convert.ToInt32(entries[23]);
                    speelveld.player = Convert.ToInt32(entries[25]);
                    speelveld.naam1 = entries[17];
                    speelveld.naam2 = entries[19];

                    speelveld.PlayerOneScore = Convert.ToInt32(entries[18]);
                    speelveld.PlayerTwoScore = Convert.ToInt32(entries[20]);

                    if (speelveld.player == 1)
                    {
                        speelveld.Beurt.Text = "Beurt:" + entries[17];
                    }
                    else
                    {
                        speelveld.Beurt.Text = "Beurt:" + entries[19];
                    }

                    speelveld.CheckSaveFile = true;

                    int k = 0;

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
            Opties_Startscherm opties_Startscherm = new Opties_Startscherm();
            //Thema_opties opties = new Thema_opties();

            this.Hide();
            opties_Startscherm.Show();
            //this.Close();
        }
    }
}