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
    /// Interaction logic for spelen.xaml
    /// </summary>
    public partial class spelen : Window
    {
        public string naam1 { get; internal set; }
        public string naam2 { get; internal set; }

        public string score1 { get; internal set; }
        public string score2 { get; internal set; }
        public string ThemeName { get; internal set; }
        public spelen()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string naam1 = Textbox1_speler1.Text;
            string naam2 = Textbox2_speler2.Text;


            speelveld speelveld = new speelveld();

            Speelveld_grootte grootte = new Speelveld_grootte();

            speelveld.naam1 = naam1;
            speelveld.naam2 = naam2;

            //string message = chosenThema;
            //MessageBox.Show(message);

            speelveld.ThemeName = ThemeName;
            speelveld.naam1 = naam1;
            speelveld.naam2 = naam2;

            speelveld.Speler1_naam.Text = "Speler : " + naam1;
            speelveld.Speler2_naam.Text = "Speler : " + naam2;



            this.Hide();
            grootte.Show();
            this.Close();
        }

        public void Textbox1_speler1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Textbox2_speler2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
