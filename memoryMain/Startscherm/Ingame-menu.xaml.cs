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
using Microsoft.Win32;
using Path = System.IO.Path;
using save;
using System.IO;

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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            MainWindow mainWindow = new MainWindow();

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "save file (*.sav)|*.sav";
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            saveFileDialog.InitialDirectory = path;
            if (saveFileDialog.ShowDialog() == true)
            {

                this.naam1 = naam1;
                this.naam2 = naam2;
                this.score1 = score1;
                this.score2 = score2;
                
                


                string[] createText = { naam1 + "," + score1 + "," + naam2 + "," + score2 };
                

                File.WriteAllLines(saveFileDialog.FileName, createText);

                this.Close();
                mainWindow.Show();
            }

        }

        private void Frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
        private void Resetten(object sender, RoutedEventArgs e)
        {
            speelveld speelveld = new speelveld();
            speelveld.naam1 = naam1;
            speelveld.naam2 = naam2;

            this.Hide();
            speelveld.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Hervatten(object sender, RoutedEventArgs e)
        {

        }
    }
}
