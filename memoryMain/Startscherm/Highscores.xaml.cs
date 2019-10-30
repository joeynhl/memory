using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Forms;

namespace Startscherm
{
    /// <summary>
    /// Interaction logic for Highscores.xaml
    /// </summary>
    public partial class Highscores : Window
    {


        ObservableCollection<Score> scores = new ObservableCollection<Score>
        {};
        public Highscores()
        {
            InitializeComponent();
            DataContext = scores;
            ReadFile();

        }

        private void addScore(string Naam1, int Score1, string Naam2, int Score2, int Tijd)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "highscores.txt";
            string score = Naam1 + "," + Score1 + "," + Naam2 + "," + Score2 + "," + Tijd;
            File.WriteAllText(path, score);

        }

        private void ReadFile()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "highscores.txt";
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
                        string[] entries = line.Split(',');
                        scores.Add(new Score { Naam1 = entries[0], Score1 = Int32.Parse(entries[1]), Naam2 = entries[2],Score2 = Int32.Parse(entries[3]),Tijd = Int32.Parse(entries[4]) });
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
            public int Tijd { set; get; }

        }
    }
}
