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
    /// Logika interakcji dla klasy DataPickerDemo.xaml
    /// </summary>
    public partial class DataPickerDemo : Window
    {
        public DataPickerDemo()
        {
            InitializeComponent();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if((sender as DatePicker).SelectedDate != null)
            {

            string myDate = (sender as DatePicker).SelectedDate.ToString();
            MessageBox.Show("Date has been changed to " + myDate);
            }
        }
    }
}
