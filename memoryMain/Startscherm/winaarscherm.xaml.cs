using System;
using System.Collections.Generic;
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

            }
            else//als speler 2 wint 
            {
                speler1.Text = naam2;//vult naam in 
                score11.Text = Convert.ToString(score2);//vult score van speler 2 in
            }
            
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
