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

namespace Navigation
{
    /// <summary>
    /// Logika interakcji dla klasy PostOperationsUC.xaml
    /// </summary>
    public partial class PostOperationsUC : UserControl
    {
        public bool PostLiked { get; set; }
        public PostOperationsUC()
        {
            InitializeComponent();
        }
        public void LikePost()
        {
            Heart.Source = new BitmapImage(new Uri("/Icons/like.png", UriKind.Relative));
            PostLiked = true;
        }

        public void UnlikePost()
        {
            Heart.Source = new BitmapImage(new Uri("/Icons/nolike.png", UriKind.Relative));
            PostLiked = false;
        }


        private void Heart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(!PostLiked)
            {
                LikePost();
            }else
            {
                UnlikePost();
            }
        }
    }
}
