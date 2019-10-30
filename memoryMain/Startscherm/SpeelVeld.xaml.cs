﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Path = System.IO.Path;
using save;
using System.Windows.Threading;

namespace Startscherm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class speelveld : Window
    {

        public string naam1 { get; internal set; }
        public string naam2 { get; internal set; }
        public string ChoosenTheme { get; internal set; }

        public string ThemeName { get; internal set; }

        public string score1 { get; internal set; }
        public string score2 { get; internal set; }
        public int minutes { get; internal set; }
        public int seconds { get; internal set; }
        DispatcherTimer dt = new DispatcherTimer();

        public speelveld()
        {
            InitializeComponent();
            

        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateGrid();
            getCardImages();
            setField();

            if (seconds < 10 & seconds > -1)
            {
                TimerLabel.Content = minutes.ToString() + ":0" + seconds.ToString();
            }
            else
            {
                TimerLabel.Content = minutes.ToString() + ":" + seconds.ToString();
            }
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();

            Beurt.Text = naam1 + " is aan de beurt!";
        }

        /// <summary>
        /// Number of rows in the grid
        /// </summary>
        private int NumRows = 4;
        /// <summary>
        /// number of collumns in the grid
        /// </summary>
        private int NumCols = 4;

        /// <summary>
        /// generate the grid
        /// </summary>
        private void CreateGrid()
        {
            
            for (int i = 0; i < NumRows; i++)
            {
                cardgrid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < NumCols; i++)
            {
                cardgrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }



        /// <summary>
        /// The theme (directory path + directory)
        /// </summary>
        private static string theme;
        /// <summary>
        /// get directory path and set theme
        /// </summary>
        public void SetTheme()
        {
            string[] directories = Directory.GetDirectories("../../themas/");


            foreach (string directory in directories)
            {
                if (Path.GetFileName(directory) == ChoosenTheme)
                {
                    theme = directory;
                }


            }
        }
        /// <summary>
        /// Get all images from the theme (directory) 
        /// put the files in a list
        /// loop trough the 2d array and add the list items
        /// </summary>
        private void getCardImages()
        {
            SetTheme(); // set theme 

            string[] files = Directory.GetFiles(theme); // get files(images) from directory (theme)

            List<string> FileList = new List<string>(); // create new list for all files(images)

            foreach (string File in files)// loop trough the files
            {
                FileList.Add(File); // add the files to the list
            }

            int count = 0; // count how many itterations

            cardgrid.Background = new ImageBrush(new BitmapImage(new Uri(FileList[0], UriKind.Relative))); // set the Grid background
            //loop trough 2d array and set values
            for (int i = 0; i < cards.GetLength(0); i++) 
            {
                for (int j = 0; j < cards.GetLength(1); j++)
                {
                    count++;
                    cards[i, j] = FileList[count]; // put cards in the 2d array
                }
            }
        }



        /// <summary>
        /// 2d array for cards (4x4 game)
        /// </summary>        
        private string[,] cards = new string[2, 4];

        /// <summary>
        /// 2d array for double cards ( all cards with copies)
        /// </summary>
        private string[,] multiplecards = new string[4, 4];

        private static void Shuffle<T>(Random random, T[,] cards)
        {
            int lengthRow = cards.GetLength(1);

            for (int i = cards.Length - 1; i > 0; i--)
            {
                int i0 = i / lengthRow;
                int i1 = i % lengthRow;

                int j = random.Next(i + 1);
                int j0 = j / lengthRow;
                int j1 = j % lengthRow;

                T temp = cards[i0, i1];
                cards[i0, i1] = cards[j0, j1];
                cards[j0, j1] = temp;
            }
        }

        /// <summary>
        ///  fill the field with the cards
        /// </summary>
        private void fillCards()
        {
            for (int i = 0; i < 2; i++) //loop twice trough array
            {
                for (int row = 0; row < cards.GetLength(0); row++)// loop trough rows
                {
                    for (int column = 0; column < cards.GetLength(1); column++)// loop trough columns
                    {
                        if (i == 1)//if its the second loop row plus 2
                        {
                            multiplecards[row + 2, column] = cards[row, column];
                        }
                        else
                        {
                            multiplecards[row, column] = cards[row, column];
                        }
                    }
                }
            }
        }

        private void setField()
        {
            fillCards(); // get the duplicate cards array filled

            var rnd = new Random();
            Shuffle(rnd, multiplecards); //shuffle cards

            for (int row = 0; row < multiplecards.GetLength(0); row++) //loop trough rows
            {
                for (int column = 0; column < multiplecards.GetLength(1); column++) // loop trough columns
                {
                    Rectangle Card = new Rectangle(); // create new card

                    Card.Fill = new ImageBrush(new BitmapImage(new Uri("../../cardbackground/background.jpg", UriKind.Relative))); //set imagebrush 
/*
                    Card.HorizontalAlignment = HorizontalAlignment.Stretch;
                    Card.VerticalAlignment = VerticalAlignment.Stretch;*/
                    Card.Margin = new Thickness(10);

                    Card.SetValue(Grid.RowProperty, row);// set row property
                    Card.SetValue(Grid.ColumnProperty, column); //set column property
                    Card.Name = "Card"; //set column property

                    Card.SetValue(DataContextProperty, multiplecards[row, column]); // set img url as data context 


                    Card.MouseLeftButtonDown += Rectangle_MouseDown; // set mousedown event on card

                    cardgrid.Children.Add(Card); // add card to grid

                }
            }
        }

        /// <summary>
        /// integer for counting when a card is clicked (resets after second click)
        /// </summary>
        private int clickamount = 0;

        /// <summary>
        /// The first card that is clicked in a turn
        /// resets every turn
        /// </summary>
        private Rectangle card_one;

        /// <summary>
        /// The second card that is clicked in a turn
        /// resets every turn
        /// </summary>
        private Rectangle card_two;

        /// <summary>
        /// integer for checking whos turn it is (player1 or player2
        /// </summary>
        private int player = 1; // integer for player 1 or 2

        /// <summary>
        /// score for player 1
        /// </summary>
        private int PlayerOneScore = 0;

        /// <summary>
        /// score for player two
        /// </summary>
        private int PlayerTwoScore = 0;


        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var Card = e.Source as FrameworkElement;

            if (Card != null)
            {
                var context = Convert.ToString(Card.DataContext); // convert dataContext to string (DataContext is the cardimage)

                Rectangle cards = sender as Rectangle; // get clicked card

                if (cards != card_one) // if same card is not clicked twice
                {

                    cards.Fill = new ImageBrush(new BitmapImage(new Uri(context, UriKind.Relative))); // show the card image

                    if (clickamount == 0)
                    { // if the first card is clicked
                        card_one = cards; // set first card

                        clickamount++; // set clickamount to 1 (for the second click)

                    }
                    else if (clickamount == 1)// if the second card is clicked
                    {
                        card_two = cards; // set second card

                        if (card_one.DataContext == card_two.DataContext)// if the the images are the same
                        {
                            MessageBox.Show("Deze kaarten zijn gelijk");

                            card_one.Visibility = Visibility.Hidden; // hide first card
                            card_two.Visibility = Visibility.Hidden; // hide second card

                            card_one = null; // reset card one
                            card_two = null; // reset card two

                            if (player == 1)//if player 1 has two equal cards
                            {
                                PlayerOneScore++;//score for player1 +1
                                speler1Score.Text = Convert.ToString(PlayerOneScore);// set score in game
                                Beurt.Text = naam1 + " is aan de beurt!";
                            }
                            else// if player 2 has equal cards
                            {
                                PlayerTwoScore++; // score for player2 +1
                                speler2Score.Text = Convert.ToString(PlayerTwoScore);// set score in game
                                Beurt.Text = naam2 + " is aan de beurt!";
                            }

                            clickamount = 0; // set amount clicks to 0;



                        }
                        else
                        { // if the images are not equal
                            MessageBox.Show("Deze kaarten zijn niet gelijk");
                            card_one.Fill = new ImageBrush(new BitmapImage(new Uri("../../cardbackground/background.jpg", UriKind.Relative))); //show general image(backside of the card)
                            card_two.Fill = new ImageBrush(new BitmapImage(new Uri("../../cardbackground/background.jpg", UriKind.Relative))); // show general image(backside of the card)

                            card_one = null;// reset card one
                            card_two = null;// reset card two

                            clickamount = 0; // reset after two clicks
                            if (player == 1)
                            {
                                player = 2;
                                Beurt.Text = naam2 + " is aan de beurt!";
                            }
                            else
                            {
                                player = 1;
                                Beurt.Text = naam1 + " is aan de beurt!";
                            }
                        }

                        if (PlayerOneScore+PlayerTwoScore == 3)
                        {
                            if (PlayerOneScore > PlayerTwoScore)
                            {
                                //MessageBox.Show("Player 1 is winaar");

                                winaarscherm winaarscherm = new winaarscherm();
                                winaarscherm.naam1 = naam1;
                                winaarscherm.naam1 = Speler1_naam.Text;

                                this.Hide();
                                winaarscherm.Show();
                                this.Close();
                            } 
                            if (PlayerTwoScore > PlayerOneScore)
                            {
                                //MessageBox.Show("Player 2 is winaar");

                                winaarscherm winaarscherm = new winaarscherm();
                                winaarscherm.naam2 = naam2;
                                winaarscherm.naam2 = Speler1_naam.Text;

                                this.Hide();
                                winaarscherm.Show();
                                this.Close();

                            }





                          
                        }
                    }
                }
            }
        }


       

        /// <summary>
        /// Zorgt voor de kloklogica en het correct weergeven van de tijd. Het programma
        /// loopt elke seconde door deze code.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtTicker(object sender, EventArgs e)
        {
            if (minutes < 0)
            {
                seconds = 0;
                minutes = 0;
            }
            else
            {
                TimerLabel.Content = minutes.ToString() + ":" + seconds.ToString();
                seconds--;
                if (seconds < 0)
                {
                    seconds = 59;
                    minutes--;
                }
                if (minutes < 0)
                {
                    seconds = 0;
                    minutes = 0;
                }
                else
                {
                    if (seconds < 10 & seconds > -1)
                    {
                        TimerLabel.Content = minutes.ToString() + ":0" + seconds.ToString();
                    }
                    else
                    {
                        TimerLabel.Content = minutes.ToString() + ":" + seconds.ToString();
                    }
                }
            }
            if (minutes == 0 & seconds == 0)
            {
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!╭━━╮╭━━━┳╮╱╱╭━━━┳━╮╱╭┳━━━┳━━━┳━━╮╱╭┳╮╭━╮
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!┃╭╮┃┃╭━━┫┃╱╱┃╭━╮┃┃╰╮┃┃╭━╮┃╭━╮┣┫┣╯╱┃┃┃┃╭╯
                //Moet eigenlijk naar het winnaarsscherm   ┃╰╯╰┫╰━━┫┃╱╱┃┃╱┃┃╭╮╰╯┃┃╱╰┫╰━╯┃┃┃╱╱┃┃╰╯╯
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!┃╭━╮┃╭━━┫┃╱╭┫╰━╯┃┃╰╮┃┃┃╭━┫╭╮╭╯┃┃╭╮┃┃╭╮┃
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!┃╰━╯┃╰━━┫╰━╯┃╭━╮┃┃╱┃┃┃╰┻━┃┃┃╰┳┫┣┫╰╯┃┃┃╰╮
                //                                         ╰━━━┻━━━┻━━━┻╯╱╰┻╯╱╰━┻━━━┻╯╰━┻━━┻━━┻╯╰━╯
                System.Environment.Exit(1);
            }
        }



        public void Menu(object sender, RoutedEventArgs e)
        {
            string naam1 = Speler1_naam.Text; 
            string naam2 = Speler2_naam.Text; 

            string score1 = speler1Score.Text;
            string score2 = speler2Score.Text;

            Ingame_menu Ingame_menu = new Ingame_menu(); //Object van maken
            Ingame_menu.naam1 = naam1;
            Ingame_menu.naam2 = naam2;

            Ingame_menu.score1 = score1;
            Ingame_menu.score2 = score2;

            Ingame_menu.minutes = minutes;
            Ingame_menu.seconds = seconds;
            Ingame_menu.dt = dt;

            dt.Stop();

            this.Hide();
            Ingame_menu.Show();

        }
    }
}
