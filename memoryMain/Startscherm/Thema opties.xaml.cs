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
    /// Interaction logic for Thema_opties.xaml
    /// </summary>
    public partial class Thema_opties : Window
    {
        public Thema_opties()
        {
            InitializeComponent();
        }

        private void Themamaken(object sender, RoutedEventArgs e)
        {
            this.Hide();
            thema_maken thema_maken = new thema_maken();
            thema_maken.Show();
            this.Close();
        }

        private void Themakiezen(object sender, RoutedEventArgs e)
        {
            this.Hide();
            thema thema = new thema();
            thema.Show();
            this.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();

        }
    }
}
