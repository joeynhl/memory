using System;
using System.Windows;
using System.Windows.Controls;

namespace Naam_Spelers
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   
                String Speler1 = Textbox1_speler1.Text;
                String Speler2 = Textbox2_speler2.Text;
                Window1 Window1 = new Window1();

                Window1.Speler1 = Speler1;
                Window1.Speler2 = Speler2;

            this.Hide();
            Window1.Show();
            this.Close();

        }
    }
}
