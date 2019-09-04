using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace memoryApp
{
    /// <summary>
    /// Interaction logic for loadingScreenIntro.xaml
    /// </summary>
    public partial class loadingScreenIntro : Window
    {
        public loadingScreenIntro()
        {
            InitializeComponent();
            showOtherScreen();
      
        }
        public async void showOtherScreen()
        {
            MainWindow win2 = new MainWindow();
            await Task.Delay(2000);
            win2.Show();
            this.Close();
        }
    }
}
