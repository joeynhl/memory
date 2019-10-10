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
        public spelen()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            String Speler1 = Textbox1_speler1.Text;
            String Speler2 = Textbox2_speler2.Text;
            namen namen = new namen();

            namen.Speler1 = Speler1;
            namen.Speler2 = Speler2;
=======
            string naam1 = _1eNaam.Text;
            string naam2 = _2eNaam.Text;
            namen namen = new namen();

            namen.naam1 = naam1;
            namen.naam2 = naam2;
>>>>>>> e02bd7a7d91b0a401fa8e9433b54acd053c3e1e3

            this.Hide();
            namen.Show();
            this.Close();
<<<<<<< HEAD


            //string naam1 = _1eNaam.Text;
            //string naam2 = _2eNaam.Text;
            //namen namen = new namen();

            //namen.naam1 = naam1;
            //namen.naam2 = naam2;

            //this.Hide();
            //namen.Show();
            //this.Close();
=======
>>>>>>> e02bd7a7d91b0a401fa8e9433b54acd053c3e1e3
        }

    }
}
