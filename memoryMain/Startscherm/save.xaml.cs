using Microsoft.Win32;
using System.IO;
using System.Windows;
using Path = System.IO.Path;
using Startscherm;

namespace save
{
    public partial class SaveFile : Window
    {
        public string naam1 { get; internal set; }
        public string naam2 { get; internal set; }
        //public string Filter { get; private set; }

        public SaveFile()
        {
            InitializeComponent();


        }

        private void btnSaveFile_Click(object sender, RoutedEventArgs e)
        {


            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "save file (*.sav)|*.sav"
            };
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            saveFileDialog.InitialDirectory = path;
            if (saveFileDialog.ShowDialog() == true)
            {
                //txtEditor.Text = naam1;
                //File.WriteAllText(saveFileDialog.FileName, txtEditor.Text);
            }
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            {
                //Filter = "save file (*.sav)|*.sav";
            };
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            openFileDialog.InitialDirectory = path;

            if (openFileDialog.ShowDialog() == true)
            {

            }
        }
    }
}

