using Microsoft.Win32;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using WindowsStoreClone.UserControls;

namespace WindowsStoreClone.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public delegate void OnAppClicked(AnApp sender, RoutedEventArgs e);
        public event OnAppClicked AppClicked;

        public Main()
        {
            InitializeComponent();
            DealstAppsViewer.AppClicked += AnAppClicked;

            ProductitivyAppsL1.AppClicked += AnAppClicked;
            ProductitivyAppsL2.AppClicked += AnAppClicked;

            EntertainmentAppsViewer.AppClicked += AnAppClicked;
            TopFreeGamesViewer.AppClicked += AnAppClicked;
            TopFreeAppsViewer.AppClicked += AnAppClicked;
            DealstAppsViewer.AppClicked += AnAppClicked;

            FeaturedAppsViewer.AppClicked+= AnAppClicked;
            MostPopulatAppsViewer.AppClicked += AnAppClicked;

        }

        private void MainScrollViewer_Loaded(object sender, RoutedEventArgs e)
        {
            UIElement element = (UIElement)sender;
            doubleAnimationHandler(element);
        }

        private void GamingTab_Loaded(object sender, RoutedEventArgs e)
            {
                UIElement element = (UIElement)sender;
                doubleAnimationHandler(element);
            }

        private void doubleAnimationHandler(UIElement el)
        {
            el.Opacity = 0;
            DoubleAnimation animation = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, 300))
            };
            el.BeginAnimation(UIElement.OpacityProperty, animation);

        }


        private void AnAppClicked(AnApp sender, RoutedEventArgs e)
        {
            AppClicked(sender, e);
        }


    }
}
