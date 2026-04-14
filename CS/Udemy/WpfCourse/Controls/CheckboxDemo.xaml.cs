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

namespace WpfCourse
{
    /// <summary>
    /// Logika interakcji dla klasy CheckboxDemo.xaml
    /// </summary>
    public partial class CheckboxDemo : Window
    {
        public CheckboxDemo()
        {
            InitializeComponent();
        }


       
        private void cbParentCheckedChanged(object sender, RoutedEventArgs e)
        {
            bool newVal = (cbParent.IsChecked == true);
            cbCheese.IsChecked = newVal;
            cbTuna.IsChecked = newVal;
            cbHam.IsChecked = newVal;
        }


        private void cbTopingsCheckedChanged(object sender, RoutedEventArgs e)
        {
            cbParent.IsChecked = null;
            if ((cbCheese.IsChecked == true) && (cbHam.IsChecked == true) && (cbTuna.IsChecked == true))
            {
                cbParent.IsChecked = true;
            }
            if ((cbCheese.IsChecked == false) && (cbHam.IsChecked == false) && (cbTuna.IsChecked == false))
            {
                cbParent.IsChecked = false;
            }
        }
    }
}
