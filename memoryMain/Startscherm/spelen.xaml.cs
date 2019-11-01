using System;
using System.Windows;
using System.Windows.Controls;

namespace Startscherm
{
    /// <summary>
    /// Interaction logic for spelen.xaml
    /// </summary>
    ///

    public partial class spelen : Window
    {
        public string ThemeName { get; internal set; }

        public int minutes = 5;
        public int seconds = 0;

        public spelen()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string naam1 = Textbox1_speler1.Text;
            string naam2 = Textbox2_speler2.Text;
            string chosenTheme = ThemeName;

            speelveld speelveld = new speelveld();

            speelveld.ChoosenTheme = chosenTheme;

            speelveld.naam1 = naam1;
            speelveld.naam2 = naam2;

            speelveld.minutes = minutes;
            speelveld.seconds = seconds;

            speelveld.minutensreset = minutes;
            speelveld.secondesreset = seconds;

            speelveld.Speler1_naam.Text = naam1;
            speelveld.Speler2_naam.Text = naam2;

            this.Hide();
            speelveld.Show();
            //this.Close();
        }

        public void Textbox1_speler1_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Textbox2_speler2_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        /// <summary>
        /// Dit zorgt ervoor dat de ingevoerde minuten worden ingevoerd in de timer.
        /// Hert controleert ook of de input van de gebruiker wel juist is.
        /// Voor verschillende soorten verkeerde inputs doet het programma iets anders.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Minutes_Changed(object sender, TextChangedEventArgs e)
        {
            if (MinutesBox.Text == "")
            {
                MinutesBox.Text = 0.ToString();
                MinutesBox.SelectionStart = MinutesBox.Text.Length;
                MinutesBox.SelectionLength = 0;
            }
            else if (MinutesBox.Text != "0")
            {
                try
                {
                    minutes = Convert.ToInt32(MinutesBox.Text);
                }
                catch (System.FormatException)
                {
                    minutes = 0;
                }
                catch (System.OverflowException)
                {
                    minutes = 2147483647;
                }

                MinutesBox.Text = minutes.ToString();
                MinutesBox.SelectionStart = MinutesBox.Text.Length;
                MinutesBox.SelectionLength = 0;
            }
            else
            {
                minutes = Convert.ToInt32(MinutesBox.Text);
                MinutesBox.SelectionStart = MinutesBox.Text.Length;
                MinutesBox.SelectionLength = 0;
            }
        }

        /// <summary>
        /// Dit zorgt ervoor dat de ingevoerde seconden worden ingevoerd in de timer.
        /// Hert controleert ook of de input van de gebruiker wel juist is.
        /// Voor verschillende soorten verkeerde inputs doet het programma iets anders.
        /// Bij teveel ingevoerde seconden zet die het aantal seconden om in extra minuten.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Seconds_Changed(object sender, TextChangedEventArgs e)
        {
            if (SecondsBox.Text == "")
            {
                SecondsBox.Text = 0.ToString();
                seconds = Convert.ToInt32(SecondsBox.Text);
                SecondsBox.SelectionStart = SecondsBox.Text.Length;
                SecondsBox.SelectionLength = 0;
            }
            else if (SecondsBox.Text != "0")
            {
                SecondsBox.SelectionStart = SecondsBox.Text.Length;
                SecondsBox.SelectionLength = 0;

                try
                {
                    seconds = Convert.ToInt32(SecondsBox.Text);
                }
                catch (System.FormatException)
                {
                    seconds = 0;
                }
                catch (System.OverflowException)
                {
                    seconds = 59;
                }
                if (seconds > 59)
                {
                    int extraminutes = 0;
                    for (extraminutes = 0; seconds > 59; extraminutes++)
                    {
                        seconds -= 60;
                    }
                    minutes += extraminutes;
                    MinutesBox.Text = minutes.ToString();
                    SecondsBox.Text = seconds.ToString();
                    SecondsBox.SelectionStart = SecondsBox.Text.Length;
                    SecondsBox.SelectionLength = 0;
                }
                else
                {
                    SecondsBox.Text = seconds.ToString();
                    SecondsBox.SelectionStart = SecondsBox.Text.Length;
                    SecondsBox.SelectionLength = 0;
                }
            }
            else
            {
                seconds = Convert.ToInt32(SecondsBox.Text);
            }
        }
    }
}