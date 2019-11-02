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

        /// <summary>
        /// list for all files ( images )
        /// </summary>
        private List<string> FileList = new List<string>();

        /// <summary>
        /// open a file dialog so you can select images for the theme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFiles_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); // new file dialog
            openFileDialog.Multiselect = true; // you can select multiple files ( images )
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*"; // you can select files with this file extensions
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // open the file dialog in my documents
            if (openFileDialog.ShowDialog() == true) // if file dialog is open
            {
                foreach (string filename in openFileDialog.FileNames)
                {
                    themeImages.Items.Add(filename); // add file to dockpanel 
                    FileList.Add(filename); // add file to file list

                }
            }
        }
        /// <summary>
        /// If the button is clicked create a directory 
        /// put the files in the directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImagesToFolder(object sender, RoutedEventArgs e)
        {
            if (FileList.Count < 9) // if you need more images
            {
                MessageBox.Show("Voeg meer afbeeldingen toe"); // show error
            }
            else 
            {
                string ThemeDirectoryName = "themas/"; // directory with all themes

            string targetPath = ThemeDirectoryName + themaNaam.Text; // directory for this theme

            if (Directory.Exists(targetPath)) // if directory name already exist 
            {
                MessageBox.Show("Dit thema bestaat al kies een andere naam"); // show error 
            }
            else
            {
                Directory.CreateDirectory(targetPath); // create the directory ( theme )

                foreach (string file in FileList) // foreach image 
                {

                    File.Copy(file, Path.Combine(targetPath, Path.GetFileName(file))); // copy the images to theme directory
                }
                
                    this.Hide();
                    var newWindow = new thema();
                    newWindow.Show();
                    this.Close();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thema_opties opties = new Thema_opties();

            this.Hide();
            opties.Show();
            this.Close();
        }
    }
}
