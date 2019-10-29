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

namespace Startscherm
{
    /// <summary>
    /// Interaction logic for Highscores.xaml
    /// </summary>
    public partial class Highscores : Window
    {

        ObservableCollection<Score> scores = new ObservableCollection<Score>
        {
            new Score{Naam1 = "Erik", Naam2 = "Rienk", Resultaat = 500},
            new Score{Naam1 = "Kevin", Naam2 = "Joey", Resultaat = 1000},
            new Score{Naam1 = "Joey", Naam2 = "Rienk", Resultaat = 7000},

        };
        public Highscores()
        {
            InitializeComponent();
            DataContext = scores;
            ReadFile();

        }

        private void ReadFile()
        {

            string path = @"C:\Users\KHD\Desktop\highscores.txt";
          
                List<string> lines = File.ReadAllLines(path).ToList();

                foreach (var line in lines)
                {
                    string[] entries = line.Split(',');
                scores.Add(new Score { Naam1 = entries[0], Naam2 = entries[1], Resultaat = Int32.Parse(entries[2]) });
     
                }
        }

        private void AddItemClick(object sender, RoutedEventArgs e)
        {
            scores.Add(new Score{ Naam1 = "Erik", Naam2 = "Rienk", Resultaat = 500});
        }

        public class Score
        {
            public string Naam1 { set; get; }
            public string Naam2 { set; get; }
            public int Resultaat { set; get; }


        }
    }
}
