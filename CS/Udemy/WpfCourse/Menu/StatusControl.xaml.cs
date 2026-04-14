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
    /// Logika interakcji dla klasy StatusControl.xaml
    /// </summary>
    public partial class StatusControl : Window
    {
        public StatusControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (myPb.Value == 100) mySb.Content = "Done";
            else mySb.Content = "Loading...";
                myPb.Value += 10;
        }
    }
}
