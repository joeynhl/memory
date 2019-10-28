using Microsoft.Win32;
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
using Path = System.IO.Path;

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



        private List<string> FileList = new List<string>();

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
            string ThemeDirectoryName = "../../themas/";

            string targetPath = ThemeDirectoryName + themaNaam.Text;

            if (Directory.Exists(targetPath))
            {
                MessageBox.Show("Dit thema bestaat al kies een andere naam");
            }
            else
            {
                Directory.CreateDirectory(targetPath);

                foreach (string file in FileList)
                {
                    File.Copy(file, Path.Combine(targetPath, Path.GetFileName(file)));

                }
                this.Hide();
                var newWindow = new thema();
                newWindow.Show();
                this.Close();
            }
        }


    }
}
