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


       

        public winaarscherm()
        {
            InitializeComponent();
            
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(naam1);
            //MessageBox.Show(naam2);
            speler1.Text = naam1;
            speler1.Text = naam2;
        }

        private void speler1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void speler2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
