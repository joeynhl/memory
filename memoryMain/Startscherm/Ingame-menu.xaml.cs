﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Path = System.IO.Path;

namespace Startscherm
{
    /// <summary>
    /// Interaction logic for Ingame_menu.xaml
    /// </summary>
    public partial class Ingame_menu : Window
    {
        /// <summary>
        /// De naam van speler 1 uit het vorige scherm
        /// </summary>
        public string naam1 { get; internal set; }

        /// <summary>
        /// De naam van speler 2 uit het vorige scherm
        /// </summary>
        public string naam2 { get; internal set; }

        /// <summary>
        /// De score van speler 1
        /// </summary>
        public string score1 { get; internal set; }

        /// <summary>
        /// De score van speler 2
        /// </summary>
        public string score2 { get; internal set; }

        public int minutensreset { get; internal set; }
        public int secondesreset { get; internal set; }
        public int minutes { get; internal set; }
        public int seconds { get; internal set; }
        public DispatcherTimer dt { get; internal set; }

        /// <summary>
        /// Alle speel kaarten
        /// </summary>
        public string[,] cards { get; internal set; }

        public string themaNaam { get; internal set; }
        public List<string> checklist { get; internal set; }
        public int player { get; internal set; }

        public Ingame_menu()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Speler1_naam.Text = naam1;
            Speler2_naam.Text = naam2;
            speler1Score.Text = score1;
            speler2Score.Text = score2;

            if (minutes < 0)
            {
                seconds = 0;
                minutes = 0;
            }
            else
            {
                TimerLabel.Content = minutes.ToString() + ":" + seconds.ToString();
                if (seconds < 0)
                {
                    seconds = 59;
                    minutes--;
                }
                if (minutes < 0)
                {
                    seconds = 0;
                    minutes = 0;
                }
                else
                {
                    if (seconds < 10 & seconds > -1)
                    {
                        TimerLabel.Content = minutes.ToString() + ":0" + seconds.ToString();
                    }
                    else
                    {
                        TimerLabel.Content = minutes.ToString() + ":" + seconds.ToString();
                    }
                }
            }
            if (minutes == 0 & seconds == 0)
            {
                //TimerLabel Content = "TIME UP";
                //System.Environment.Exit(1);
            }
        }

        private void Speler1_naam_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }

        /// <summary>
        /// opslaan knop om het spel op te slaan
        /// voeg waardes toe aan de createText om nieuwe waardes op te slaan
        /// om waardes terug te halen kijk in mainwindow naar het hervatten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "save file (*.sav)|*.sav";//filter zo dat er alleen een .sav aangemaakt kan worden
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);//maakt een pad in de debug folder waar het bestand opgeslagen gaat worden
            saveFileDialog.InitialDirectory = path;//opent het pad op de plek van Path
            if (saveFileDialog.ShowDialog() == true)
            {
                string images = ""; //maakt een nieuw string aan

                //vult images met elke image in checklist en voegt een comma tussen elke image
                foreach (string image in checklist)
                {
                    images += image + ",";
                }
                //vult createText arr met alle waardes die gegeven worden
                string[] createText = { images + "," + naam1 + "," + score1 + "," + naam2 + "," + score2 + "," + themaNaam + "," + minutes + "," + seconds + "," + player + "," + minutensreset + "," + secondesreset };

                //vult een save bestand met alle waardes van createText met de naam van het bestand
                File.WriteAllLines(saveFileDialog.FileName, createText);

            }
        }

        private void Frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
        }

        /// <summary>
        /// Reset het spel. 
        /// Hij zet alleen de namen van de spelers, thema en de ingestelde tijd door naar het nieuwe speelveld.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Resetten(object sender, RoutedEventArgs e)
        {
            speelveld speelveld = new speelveld();
            speelveld.naam1 = naam1;
            speelveld.naam2 = naam2;

            speelveld.Speler1_naam.Text = naam1;
            speelveld.Speler2_naam.Text = naam2;
            speelveld.ChoosenTheme = themaNaam;

            speelveld.minutes = minutensreset;
            speelveld.seconds = secondesreset;

            speelveld.secondesreset = secondesreset;
            speelveld.minutensreset = minutensreset;

            this.Hide();
            speelveld.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Zorgt voor de kloklogica en het correct weergeven van de tijd. Het programma
        /// loopt elke seconde door deze code.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtTicker(object sender, EventArgs e)
        {
            if (minutes < 0)
            {
                seconds = 0;
                minutes = 0;
            }
            else
            {
                TimerLabel.Content = minutes.ToString() + ":" + seconds.ToString();
                seconds--;
                if (seconds < 0)
                {
                    seconds = 59;
                    minutes--;
                }
                if (minutes < 0)
                {
                    seconds = 0;
                    minutes = 0;
                }
                else
                {
                    if (seconds < 10 & seconds > -1)
                    {
                        TimerLabel.Content = minutes.ToString() + ":0" + seconds.ToString();
                    }
                    else
                    {
                        TimerLabel.Content = minutes.ToString() + ":" + seconds.ToString();
                    }
                }
            }
            if (minutes == 0 & seconds == 0)
            {
                //TimerLabel.Content = "TIME UP";
                //System.Environment.Exit(1);
            }
        }

        /// <summary>
        /// Hervat het gepauzeerde spel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hervatten(object sender, RoutedEventArgs e)
        {
            if (seconds < 10 & seconds > -1)
            {
                TimerLabel.Content = minutes.ToString() + ":0" + seconds.ToString();
            }
            else
            {
                TimerLabel.Content = minutes.ToString() + ":" + seconds.ToString();
            }
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();

            this.Hide();

            this.Close();
        }

        /// <summary>
        /// sluit het spel af
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Afsluiten(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}