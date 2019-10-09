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

namespace Naam_Spelers
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public string Speler1 { get; internal set; }
        public string Speler2 { get; internal set; }
        public Window1()
        {
            InitializeComponent();

        }
        public class Windwow1
        {
        }

        private void Speler1_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Speler1_naam.Text = Speler1;
            Speler2_naam.Text = Speler2;

        }
    }
}

