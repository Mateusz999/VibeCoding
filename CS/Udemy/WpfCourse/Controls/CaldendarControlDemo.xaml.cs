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
    /// Logika interakcji dla klasy CaldendarControlDemo.xaml
    /// </summary>
    public partial class CaldendarControlDemo : Window
    {
        public CaldendarControlDemo()
        {
            InitializeComponent();
            myTextblock.Text = myCalendar.SelectedDate.ToString();
        }


        private void myCalendar_SelectedDatesChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (myTextblock != null)
                myTextblock.Text = myCalendar.SelectedDate.ToString();
        }
    }
}
