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

        /// <summary>
        /// thema die gekozen is
        /// </summary>
        public string chosenThema = "";


        /// <summary>
        /// Maakt knoppen voor elk thema
        /// </summary>
        private void loadButtons()
        {
            string[] directories = Directory.GetDirectories("themas/"); // map met alle thema's


            foreach (string theme in directories) // loop door alle mappen heen
            {
                Button button = new Button(); // nieuwe button

                string themeName = System.IO.Path.GetFileName(theme); // map naam (thema naam)

                button.Content = themeName; // Button tekst is de thema naam
                button.Width = 150; // breedte van de button is 150
                button.Padding = new Thickness(10); // padding is 10
                button.FontSize = 18; // letter grootte is 18
                button.FontWeight = FontWeights.Bold; // Dikgedrukte letters
                button.Margin = new Thickness(0,0,0,5); // margin aan de onderkant van elke knop 
                button.SetValue(DataContextProperty, themeName); // Data context is de themanaam
                ButtonHolder.Children.Add(button); // zet de knoppen in xaml
                button.Click += chooseTheme; // als er op een knop geklikt word voert hij de code in de chooseTheme functie uit

            }
        }
        /// <summary>
        /// Zet de gekozen thema door
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chooseTheme(object sender, RoutedEventArgs e)
        { 
            Button theme = sender as Button; // de geklikte knop

            string ThemeNameFromButton = Convert.ToString(theme.DataContext); // haal het thema uit de datacontext van de knop

            spelen spelen = new spelen();

            spelen.ThemeName = ThemeNameFromButton; // zet het gekozen thema door naar het volgende scherm

            this.Hide();
            spelen.Show();
            this.Close();

        }

        /// <summary>
        /// navigeer terug naar het volgende scherm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thema_opties opties = new Thema_opties();

            this.Hide();
            opties.Show();
            this.Close();
        }
    }
}
