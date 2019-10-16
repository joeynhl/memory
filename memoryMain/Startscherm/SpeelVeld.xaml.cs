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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Startscherm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class speelveld : Window
    {

        public string naam1 { get; internal set; }
        public string naam2 { get; internal set; }

        public speelveld()
        {
            InitializeComponent();
            setField();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Speler1_naam.Text = "Speler : " + naam1;
            Speler2_naam.Text = "Speler : " + naam2;
        }

        /// <summary>
        /// 2d array for cards (4x4 game)
        /// </summary>
        /// 
        public string[,] cards = new string[2, 4]
             {
                {"../../Image/mario.jpg", "../../Image/mario2.jpg", "../../Image/mario3.jpg", "../../Image/mario4.jpg"},
                { "../../Image/mario5.jpg", "../../Image/mario6.jpg", "../../Image/mario7.jpg", "../../Image/mario8.jpg"}
             };

        /// <summary>
        /// 2d array for double cards
        /// </summary>
        public string[,] multiplecards = new string[4, 4];

        public static void Shuffle<T>(Random random, T[,] cards)
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
            namen naam = new namen();

            //Speler1_naam.Text = naam1;
            //Speler2_naam.Text = naam2;

            var rnd = new Random();
            Shuffle(rnd, multiplecards); //shuffle cards

            for (int row = 0; row < multiplecards.GetLength(0); row++) //loop trough rows
            {
                for (int column = 0; column < multiplecards.GetLength(1); column++) // loop trough columns
                {
                    Rectangle Card = new Rectangle(); // create new card

                    Card.Fill = new ImageBrush(new BitmapImage(new Uri("../../Image/background.jpg", UriKind.Relative))); //set imagebrush 

                    Card.HorizontalAlignment = HorizontalAlignment.Stretch;
                    Card.VerticalAlignment = VerticalAlignment.Stretch;
                    Card.Margin = new Thickness(10);

                    Card.SetValue(Grid.RowProperty, row);// set row property
                    Card.SetValue(Grid.ColumnProperty, column); //set column property
                    Card.Name = "Card"; //set column property

                    Card.SetValue(DataContextProperty, multiplecards[row, column]); // set img url as data context 


                    Card.MouseLeftButtonDown += Rectangle_MouseDown; // set mousedown event on card

                    cardgrid.Children.Add(Card); // add card to grid

                    /*              
                                        Button btn = new Button(); // create new button
                                        btn.Content = multiplecards[row, column]; // fill button content*/

                    /*btn.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                    btn.VerticalContentAlignment = VerticalAlignment.Stretch;
                    btn.Margin = new Thickness(10);

                    btn.SetValue(Grid.RowProperty, row); //set row position
                    btn.SetValue(Grid.ColumnProperty, column); // set col position
                    cardgrid.Children.Add(btn);*/

                }
            }
        }

        public int clickamount = 0;

        public Rectangle card_one;

        public Rectangle card_two;

        public int player = 1;
        public int PlayerOneScore = 0;
        public int PlayerTwoScore = 0;


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

                            if(player == 1)//if player 1 has two equal cards
                            {
                                PlayerOneScore++;//score for player1 +1
                                speler1Score.Text = Convert.ToString(PlayerOneScore);// set score in game
                            }
                            else// if player 2 has equal cards
                            {
                                PlayerTwoScore++; // score for player2 +1
                                speler2Score.Text = Convert.ToString(PlayerTwoScore);// set score in game
                            }

                            clickamount = 0; // set amount clicks to 0;

                            
                        }
                        else
                        { // if the images are not equal
                            MessageBox.Show("Deze kaarten zijn niet gelijk");
                            card_one.Fill = new ImageBrush(new BitmapImage(new Uri("../../Image/background.jpg", UriKind.Relative))); //show general image(backside of the card)
                            card_two.Fill = new ImageBrush(new BitmapImage(new Uri("../../Image/background.jpg", UriKind.Relative))); // show general image(backside of the card)

                            card_one = null;// reset card one
                            card_two = null;// reset card two

                            clickamount = 0; // reset after two clicks
                            if(player == 1)
                            { 
                                player = 2;
                            } else
                            {
                                player = 1;
                            }
                        }
                    }
                }
            }
        }

        private void Menu(object sender, RoutedEventArgs e)
        {
            Ingame_menu Ingame_menu = new Ingame_menu();
            Ingame_menu.naam1 = naam1;
            Ingame_menu.naam2 = naam2;

            this.Hide();
            Ingame_menu.Show();
            this.Close();
        }
    }
}
