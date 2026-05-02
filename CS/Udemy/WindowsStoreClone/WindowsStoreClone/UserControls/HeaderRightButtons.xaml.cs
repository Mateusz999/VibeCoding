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

namespace WindowsStoreClone.UserControls
{
    /// <summary>
    /// Logika interakcji dla klasy HeaderRightButtons.xaml
    /// </summary>
    /// 

   
    public partial class HeaderRightButtons : UserControl
    {
        public delegate void OnDownloadButtonClick(object sender, RoutedEventArgs e);
        public event OnDownloadButtonClick HeaderRightButtonDownloadButtonClick;
        public HeaderRightButtons()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Visibility = Visibility.Collapsed;
            SearchTextBox.Visibility = Visibility.Visible;
        }

        public void MouseDown_OutsideOfHeaderRightButtons(object sender, RoutedEventArgs e)
        {
            if(!SearchTextBox.IsMouseOver)
            {
                searchButton.Visibility = Visibility.Visible;
                SearchTextBox.Visibility = Visibility.Collapsed;
            }
        }
        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            HeaderRightButtonDownloadButtonClick(sender, e);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            HeaderRightButtonDownloadButtonClick(sender,e);
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
