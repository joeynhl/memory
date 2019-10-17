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
    /// Interaction logic for Ingame_menu.xaml
    /// </summary>
    public partial class Ingame_menu : Window
    {
        public string naam1 { get; internal set; }
        public string naam2 { get; internal set; }

        public string score1 { get; internal set; }
        public string score2 { get; internal set; }

        public Ingame_menu()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Speler1_naam.Text = "Speler : " + naam1;
            Speler2_naam.Text = "Speler : " + naam2;
            speler1Score.Text = score1;
            speler2Score.Text = score2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Speler1_naam_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
