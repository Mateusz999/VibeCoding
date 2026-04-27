using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WindowsStoreClone.UserControls.AppDetailsTabContent;
using WindowsStoreClone.UserControls;
namespace WindowsStoreClone.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy AppDetails.xaml
    /// </summary>
    public partial class AppDetails : Page
    {
        public delegate void OnBackButtonClicked(object sender, RoutedEventArgs e);
        public event OnBackButtonClicked BackButtonClicked;

        public delegate void OnAppDetailsAnotherAppClicked(AnApp sender, RoutedEventArgs e);
        public event OnAppDetailsAnotherAppClicked AppClicked;


        public AppDetails(AnApp anApp)
        {
            InitializeComponent();
            AppDetailsAndBackground.AppNameLabel.Content = anApp.AppName;
            AppDetailsAndBackground.AppImage.Source = anApp.AppImageSource;
            AppDetailsAndBackground.BackButtonClicked += AppDetailsAndBackground_BackButtonClicked;

            OverviewTabUC.AppClicked += OverviewTabUC_AnAppClicked;
        }

        public void AppDetailsAndBackground_BackButtonClicked(object sender, RoutedEventArgs e)
        {
            BackButtonClicked(sender, e);

        }

        private void OverviewTabUC_AnAppClicked(AnApp sender, RoutedEventArgs e)
        {
            AppClicked(sender, e);
        }
    }
}
