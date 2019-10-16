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
            string naam1 = Textbox1_speler1.Text;
            string naam2 = Textbox2_speler2.Text;
            //namen namen = new namen();
            ////speelveld speelveld = new speelveld();

            //namen.naam1 = naam1;
            //namen.naam2 = naam2;

            //this.Hide();
            //speelveld.Show();
            //this.Close();

            speelveld speelveld = new speelveld();
            speelveld.naam1 = naam1;
            speelveld.naam2 = naam2;

            this.Hide();
            speelveld.Show();
            this.Close();
        }

    }
}
