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
    /// Interaction logic for namen.xaml
    /// </summary>
    public partial class namen : Window
    {
        public string naam1 { get; internal set; }
        public string naam2 { get; internal set; }

        public namen()
        {
            InitializeComponent();
            setNames();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public void setNames()
        {

            speelveld speelveld = new speelveld();

            speler1Naam.Text = naam1;
            speler2Naam.Text = naam2;
            speelveld.Speler1_naam.Text = "Speler : " + naam1;
            speelveld.Speler2_naam.Text = "Speler : " + naam2;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            speler1Naam.Text = naam1;
            speler2Naam.Text = naam2;
        }
    }
}
