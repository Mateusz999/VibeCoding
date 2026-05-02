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
using WindowsStoreClone.Pages;
using WindowsStoreClone.UserControls;

namespace WindowsStoreClone
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Main MainWindowContentPage;
        private TopAppsWrapped MyTopAppsWrapped;
        public MainWindow()
        {
            InitializeComponent();
            MainWindowContentPage = new Main();
            MainWindowContentPage.AppClicked += MainWindowContentPage_AppClicked;
            MainWindowContentPage.TopAppButtonClicked += MainWindowContentPage_TopAppButtonClicked;

            MyTopAppsWrapped = new TopAppsWrapped();
            MyTopAppsWrapped.AnAppClicked += MainWindowContentPage_AppClicked;

            MyTopAppsWrapped.BackButtonClicked += MyTopApp_BackButtonClicked;

        }
        
        private void MainWindowContentPage_TopAppButtonClicked(object sender, RoutedEventArgs e)
        {
            MainWindowFrame.Content = MyTopAppsWrapped;
        }
        private void MainWindowContentPage_AppClicked(AnApp sender, RoutedEventArgs e)
        {
            AppDetails myAppDetails = new AppDetails(sender);
            myAppDetails.BackButtonClicked += MyAppDetails_BackButtonClicked;
            MainWindowFrame.Content = myAppDetails;
            myAppDetails.AppClicked += MainWindowContentPage_AppClicked;
            MainWindowFrame.Content = myAppDetails;

        }

        private void MyTopApp_BackButtonClicked(object sender, RoutedEventArgs e)
        {
            if (MainWindowFrame.NavigationService.CanGoBack)
            {
                MainWindowFrame.NavigationService.GoBack();
            }
        }

        private void MyAppDetails_BackButtonClicked(object sender, RoutedEventArgs e)
        {
            if(MainWindowFrame.NavigationService.CanGoBack)
            {
                MainWindowFrame.NavigationService.GoBack();
            }
        }
        private void MainWindowFrame_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindowFrame.Content = MainWindowContentPage;
        }
    }
}
