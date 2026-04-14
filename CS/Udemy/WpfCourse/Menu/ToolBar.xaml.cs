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
    /// Logika interakcji dla klasy ToolBar.xaml
    /// </summary>
    public partial class ToolBar : Window
    {
        public ToolBar()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myTextBox.Text = string.Empty;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            ComboBox comboBox = sender as ComboBox;
            ComboBoxItem cbItem = comboBox.SelectedItem as ComboBoxItem;
            string newFontSize = (string) cbItem.Content;

            int temp;
            if(Int32.TryParse(newFontSize, out temp))
            {
                if (myTextBox != null)
                {
                    myTextBox.FontSize = temp;
                }

            }
        }
    }
}
