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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD:Startscherm/Startscherm/spelen.xaml.cs
            String Speler1 = Textbox1_speler1.Text;
            String Speler2 = Textbox2_speler2.Text;
            namen namen = new namen();

            namen.Speler1 = Speler1;
            namen.Speler2 = Speler2;

            this.Hide();
            namen.Show();
            this.Close();


            //string naam1 = _1eNaam.Text;
            //string naam2 = _2eNaam.Text;
            //namen namen = new namen();

            //namen.naam1 = naam1;
            //namen.naam2 = naam2;

            //this.Hide();
            //namen.Show();
            //this.Close();
=======

>>>>>>> 237ace2e89653de62b7e7cd948f5e5b3150dabc8:memoryMain/Startscherm/Menu.xaml.cs
        }
    }
}
