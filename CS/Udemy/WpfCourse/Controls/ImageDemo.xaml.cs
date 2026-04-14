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
    /// Logika interakcji dla klasy ImageDemo.xaml
    /// </summary>
    public partial class ImageDemo : Window
    {
        public ImageDemo()
        {
            InitializeComponent();
        }
        private bool state = true;

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {

            string uriRelativePath = (state) ? "/WpfCourse;component/Images/homer_ship_2006.jpg" : "/WpfCourse;component/Images/homer_2006.png";
            myImage.Source = new BitmapImage(
                new Uri(uriRelativePath, UriKind.Relative)
);

            state = !state;
        }
    }
}
