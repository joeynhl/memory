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
    /// Interaction logic for thema.xaml
    /// </summary>
    public partial class thema : Window
    {
        public thema()
        {
            InitializeComponent();
        }

        private bool buttonIsClicked = false;

        public string chosenThema = "";




        //keuze is mario kaarten
        private void btnMario(object sender, RoutedEventArgs e)
        {
            buttonIsClicked = true;
            if (buttonIsClicked == true)
            {
               chosenThema = "mario";

                //string message = chosenThema;
                //MessageBox.Show(message);

                spelen spelen = new spelen();
                this.Hide();
                spelen.Show();
                this.Close();
            }


        }
        //keuze is zelda kaarten
        private void btnZelda(object sender, RoutedEventArgs e)
        {
            buttonIsClicked = true;
            if (buttonIsClicked == true)
            {
                chosenThema = "zelda";

                //string message = chosenThema;
                //MessageBox.Show(message);

                spelen spelen = new spelen();
                this.Hide();
                spelen.Show();
                this.Close();
            }
        }
        //keuze is maple kaarten
        private void btnMaple(object sender, RoutedEventArgs e)
        {
            buttonIsClicked = true;
            if (buttonIsClicked == true)
            {
                chosenThema = "maple";

                //string message = chosenThema;
                //MessageBox.Show(message);

                spelen spelen = new spelen();
                this.Hide();
                spelen.Show();
                this.Close();
            }
        }
        //keuze is eigen kaarten
        private void btnEigen(object sender, RoutedEventArgs e)
        {
            buttonIsClicked = true;
            if (buttonIsClicked == true)
            {
                string message = "eigen keuze is geklikt.";
                MessageBox.Show(message);

                spelen spelen = new spelen();
                this.Hide();
                spelen.Show();
                this.Close();
            }
        }
    }
}
