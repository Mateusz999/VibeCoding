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

namespace WpfCourse.Panels
{
    /// <summary>
    /// Logika interakcji dla klasy StackPanelDemo.xaml
    /// </summary>
    public partial class StackPanelDemo : Window
    {
        public StackPanelDemo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) // right
        {
            double left = Canvas.GetLeft(shape);
            Canvas.SetLeft(shape, left + 10);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // left
        {
            double left = Canvas.GetLeft(shape);
            Canvas.SetLeft(shape, left - 10);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) // up
        {
            double top = Canvas.GetTop(shape);
            Canvas.SetTop(shape, top - 10);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) // down
        {
            double top = Canvas.GetTop(shape);
            Canvas.SetTop(shape, top + 10);
        }

    }
}
