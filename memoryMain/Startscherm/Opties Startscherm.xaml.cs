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
    /// Interaction logic for Opties_Startscherm.xaml
    /// </summary>
    /// 

    public partial class Opties_Startscherm : Window
    {

            MediaPlayer Sound = new MediaPlayer();

        public Opties_Startscherm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Terug(object sender, RoutedEventArgs e)
        {
            //MainWindow main = new MainWindow();
            this.Hide();
            //main.Show();
            this.Close();
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double value = slider.Value;
            Sound.Volume = value;
        }
    }
}
