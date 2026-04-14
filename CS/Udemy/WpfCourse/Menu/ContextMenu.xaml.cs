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

namespace WpfCourse.Menu
{
    /// <summary>
    /// Logika interakcji dla klasy ContextMenu.xaml
    /// </summary>
    public partial class ContextMenu : Window
    {
        public ContextMenu()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
        }

        private void miItalic_Click(object sender, RoutedEventArgs e)
        {

        }

        private void miBold_Checked(object sender, RoutedEventArgs e)
        {
            mytb.FontWeight = FontWeights.Bold;

        }

        private void miBold_Unchecked(object sender, RoutedEventArgs e)
        {
            mytb.FontWeight = FontWeights.Normal;

        }

        private void miItalic_Checked(object sender, RoutedEventArgs e)
        {
            mytb.FontStyle = FontStyles.Italic;

        }

        private void miItalic_Unchecked(object sender, RoutedEventArgs e)
        {
            mytb.FontStyle = FontStyles.Normal;

        }

       

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Dont click me anymore";
        }
    }
}
