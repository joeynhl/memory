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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace cards
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Image rotateImage = new Image()
            //{
            //    Stretch = Stretch.Uniform,
            //    Source = new BitmapImage(new Uri("pack://application:,,,/images/goodestboi.jpg")),
            //    RenderTransform = new RotateTransform()
            //};
            //Image opacityImage = new Image()
            //{
            //    Stretch = Stretch.Uniform,
            //    Source = new BitmapImage(new Uri("pack://application:,,,/images/sjekkie.jpg"))
            //};

            //LayoutRoot.Children.Add(rotateImage);
            //LayoutRoot.Children.Add(opacityImage);

            //Grid.SetColumn(opacityImage, 1);

            //Storyboard storyboard = new Storyboard();
            //storyboard.Duration = new Duration(TimeSpan.FromSeconds(3.0));
            //DoubleAnimation rotateAnimation = new DoubleAnimation()
            //{
            //    From = 0,
            //    To = 360,
            //    Duration = storyboard.Duration
            //};
            //DoubleAnimation opacityAnimation = new DoubleAnimation()
            //{
            //    From = 1.0,
            //    To = 0.0,
            //    BeginTime = TimeSpan.FromSeconds(2.0),
            //    Duration = new Duration(TimeSpan.FromSeconds(1.0))
            //};

            //Storyboard.SetTarget(rotateAnimation, rotateImage);
            //Storyboard.SetTargetProperty(rotateAnimation, new PropertyPath("(UIElement.RenderTransform).(RotateTransform.Angle)"));
            //Storyboard.SetTarget(opacityAnimation, opacityImage);
            //Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath("Opacity"));

            //storyboard.Children.Add(rotateAnimation);
            //storyboard.Children.Add(opacityAnimation);

            //Resources.Add("Storyboard", storyboard);

            //Button button = new Button()
            //{
            //    Content = "Begin"
            //};
            //button.Click += button_Click;

            //Grid.SetRow(button, 1);
            //Grid.SetColumnSpan(button, 2);

            //LayoutRoot.Children.Add(button);


        }

        void button_Click(object sender, RoutedEventArgs e)
    {
        
    }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Title = "Clicked";

            var fill = card.Fill as ImageBrush;

            if (fill.ImageSource == (ImageSource)Resources["closedImage"])
            {
                fill.ImageSource = (ImageSource)Resources["openImage"];
            }
            else
            {
                fill.ImageSource = (ImageSource)Resources["closedImage"];

            }

            //((Storyboard)Resources["Storyboard"]).Begin();

        }

        //private void Rectangle_MouseUp(object sender, MouseButtonEventArgs e)
        //{
        //    this.Title = "Clicked";

        //    var fill = card.Fill as ImageBrush;

        //    if (fill.ImageSource == (ImageSource)Resources["openImage"])
        //    {
        //        fill.ImageSource = (ImageSource)Resources["ClosedImage"];
        //    }

        //    //((Storyboard)Resources["Storyboard"]).Begin();

        //}


    }
}
