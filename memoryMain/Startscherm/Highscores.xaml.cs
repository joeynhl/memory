using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace Startscherm
{
    /// <summary>
    /// Interaction logic for Highscores.xaml
    /// </summary>
    public partial class Highscores : Window
    {
        private ObservableCollection<Score> scores = new ObservableCollection<Score>
        { };


        public Highscores()
        {
            InitializeComponent();
            DataContext = scores;
            ReadFile();
        }


        /// <summary>
        /// De functie die de namen en scores opslaat naar een bestand
        /// </summary>
        /// <param name="Naam1"></param>
        /// <param name="Score1"></param>
        /// <param name="Naam2"></param>
        /// <param name="Score2"></param>
        private void addScore(string Naam1, int Score1, string Naam2, int Score2)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "highscores.txt";
            // creeer string vanuit de params die in ons document past
            string score = Naam1 + "," + Score1 + "," + Naam2 + "," + Score2;
            // schrijf string naar document
            File.WriteAllText(path, score);
        }

        /// <summary>
        /// Leest het bestand uit die hij vervolgens verwerkt om te tonen op de applicatie
        /// </summary>
        private void ReadFile()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "highscores.txt";

            // als het bestand niet bestaat maak hem dan altijd eerst aan
            if (!File.Exists(path))
            {
                TextWriter tw = new StreamWriter(path);
                tw.Close();
            }
            try
            {
                List<string> lines = File.ReadAllLines(path).ToList();
                foreach (var line in lines)
                {
                    // strip elke lijn op de comma om daar een waarde uit te halen
                    string[] entries = line.Split(',');
                    scores.Add(new Score { Naam1 = entries[0], Score1 = Int32.Parse(entries[1]), Naam2 = entries[2], Score2 = Int32.Parse(entries[3]) });
                }
            }
            catch (Exception e)
            {
                return;
            }
        }


        public class Score
        {
            public string Naam1 { set; get; }
            public int Score1 { set; get; }
            public string Naam2 { set; get; }
            public int Score2 { set; get; }
        }
    }
}