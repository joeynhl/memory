using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for thema.xaml
    /// </summary>
    public partial class thema : Window
    {
        public thema()
        {
            InitializeComponent();

            loadButtons();
        }

        private bool buttonIsClicked = false;

        public string chosenThema = "";


        private void loadButtons()
        {
            string[] directories = Directory.GetDirectories("../../themas/");


            foreach (string theme in directories)
            {
                Button button = new Button();

                string themeName = System.IO.Path.GetFileName(theme);

                button.Content = themeName;
                button.Width = 150;
                button.Padding = new Thickness(10);
                button.FontSize = 18;
                button.FontWeight = FontWeights.Bold;
                button.Margin = new Thickness(0,0,0,5);
                button.SetValue(DataContextProperty, themeName);
                ButtonHolder.Children.Add(button);
                button.Click += chooseTheme;

            }
        }




        private void chooseTheme(object sender, RoutedEventArgs e)
        {
            Button theme = sender as Button;

            /* speelveld speelveld = new speelveld();

             speelveld.ThemeName = Convert.ToString(theme.DataContext);*/


            speelveld spelen = new speelveld();

            spelen.ThemeName = Convert.ToString(theme.DataContext); 
            this.Hide();
            spelen.Show();
            this.Close();

        }



        //keuze is mario kaarten
        private void btnMario(object sender, RoutedEventArgs e)
        {
            buttonIsClicked = true;
            if (buttonIsClicked == true)
            {
               chosenThema = "mario";

                //string message = chosenThema;
                //MessageBox.Show(message);

                speelveld spelen = new speelveld();
                this.Hide();
                spelen.Show();
                this.Close();
            }
        }
    }
}
