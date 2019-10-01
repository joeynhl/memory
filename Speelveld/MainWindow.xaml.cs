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

        
        private void setField()
        {
            string[,] cards = new string[4, 4]
            {
                {"1", "2", "3", "4"},
                { "5", "6", "7", "8"},
                { "9", "10", "11", "12"},
                { "13", "14", "15", "16" }
            };

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
