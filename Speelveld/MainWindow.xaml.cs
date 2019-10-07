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

        private void setField()
        {
            string[,] cards = new string[2, 4]
            {
                {"1", "2", "3", "4"},
                { "5", "6", "7", "8"}
            };
            var rnd = new Random();

            Shuffle(rnd, cards);


            for (int row = 0; row < cards.GetLength(0); row++)
            {
                for (int column = 0; column < cards.GetLength(1); column++)
                {


                    Button btn = new Button();
                    btn.Content = cards[row, column];
                    cardgrid.Children.Add(btn);
                    btn.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                    btn.VerticalContentAlignment = VerticalAlignment.Stretch;
                    btn.Margin = new Thickness(10);

                    btn.SetValue(Grid.RowProperty, row);
                    btn.SetValue(Grid.ColumnProperty, column);

                    /* Grid.Row = "0" Grid.Column = "0"*/
                }
            }
            

        }

    }
}
