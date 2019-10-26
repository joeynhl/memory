using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace Startscherm
{
    /// <summary>
    /// Interaction logic for thema_maken.xaml
    /// </summary>
    public partial class thema_maken : Window
    {
        public thema_maken()
        {
            InitializeComponent();
        }



        public List<string> FileList = new List<string>();

        private void btnOpenFiles_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                {
                    themeImages.Items.Add(filename);
                    FileList.Add(filename);
                    
                }
            }
        }
        private void ImagesToFolder(object sender, RoutedEventArgs e)
        {
            string targetPath = "../../themas/test";
            
            foreach(string file in FileList)
            {
                System.IO.File.Copy(file, System.IO.Path.Combine(targetPath, System.IO.Path.GetFileName(file)));

            }
            this.Hide();
            var newWindow = new thema();
            newWindow.Show();
            this.Close();

        }


    }
}
