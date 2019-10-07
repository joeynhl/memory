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

namespace Speelveld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            setField();
        }
        /// <summary>
        /// 2d array for cards (4x4 game)
        /// </summary>
       public string[,] cards = new string[2, 4]
            {
                {"1", "2", "3", "4"},
                { "5", "6", "7", "8"}
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
                        if(i == 1)//if its the second loop row plus 2
                        {
                            multiplecards[row+2, column] = cards[row, column];
                        } else {
                            multiplecards[row, column] = cards[row, column];
                        }
                    }
                }
            }
        }

        private void setField()
        {
            fillCards(); // get the multiple cards array filled

            var rnd = new Random();
            Shuffle(rnd, multiplecards); //shuffle cards

            for (int row = 0; row < multiplecards.GetLength(0); row++) //loop trough rows
            {
                for (int column = 0; column < multiplecards.GetLength(1); column++) // loop trough columns
                {
                    Button btn = new Button(); // create new button
                    btn.Content = multiplecards[row, column]; // fill button content
                    
                    btn.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                    btn.VerticalContentAlignment = VerticalAlignment.Stretch;
                    btn.Margin = new Thickness(10);

                    btn.SetValue(Grid.RowProperty, row); //set row position
                    btn.SetValue(Grid.ColumnProperty, column); // set col position
                    cardgrid.Children.Add(btn);

                }
            }
        }
    }
}
