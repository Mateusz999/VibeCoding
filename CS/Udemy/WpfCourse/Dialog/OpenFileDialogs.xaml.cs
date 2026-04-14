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
using Microsoft.Win32;
using System.IO;
namespace WpfCourse.Dialog
{
    /// <summary>
    /// Logika interakcji dla klasy OpenFileDialog.xaml
    /// </summary>
    public partial class OpenFileDialogs : Window
    {
        public OpenFileDialogs()
        {
            InitializeComponent();
        }

        private void openFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            //openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            openFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if(openFile.ShowDialog() == true)
            {
                myTextBox.Text = File.ReadAllText(openFile.FileName);
            }
        }

        private void saveFileButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";


           if (saveFile.ShowDialog() == true)
            {
                File.WriteAllText(saveFile.FileName, myTextBox.Text);
            }
        }
    }
}
