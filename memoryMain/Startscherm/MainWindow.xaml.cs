﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using save;

namespace Startscherm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer Sound = new MediaPlayer();
        Opties_Startscherm opties = new Opties_Startscherm();



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
            this.Hide();
            Speelveld_grootte grote = new Speelveld_grootte();
            grote.Show();
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

                int count = 0;
                
                foreach (var line in lines)
                {
                    string[] entries = line.Split(',');

                    speelveld.Speler1_naam.Text = entries[0];
                    speelveld.speler1Score.Text = entries[1];
                    speelveld.Speler2_naam.Text = entries[2];
                    speelveld.speler2Score.Text = entries[3];
                    speelveld.theme = entries[4];


                   
                    for (int i = 0; i < speelveld.multiplecards.GetLength(0); i++)
                    {
                        for (int j = 0; j < speelveld.multiplecards.GetLength(1); j++)
                        {
                            count++;
                            speelveld.multiplecards[i, j] = entries[count]; // put cards in the 2d array
                        }
                    }



                    //for (var i = 0; i < lines.Count; i++)
                    //{
                    //    speelveld.multiplecards = entries[];
                    //}


                    //foreach(string image in entries[4])
                    //{
                    //    speelveld.cardgrid = entries[4];
                    //}

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

  

        private void playMuziek_Click(object sender, RoutedEventArgs e)
        {
            Sound.Play();
        }
        private void stopMuziek_Click(object sender, RoutedEventArgs e)
        {
            Sound.Stop();
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double value = slider.Value;
            Sound.Volume = value;
        }

        private void Opties(object sender, RoutedEventArgs e)
        {
            opties.Show();

        }
    }
}
