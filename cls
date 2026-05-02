[33mcommit 622729cb1f28801c5ddd373eada0254f2faef967[m[33m ([m[1;36mHEAD -> [m[1;32mmain[m[33m, [m[1;31morigin/main[m[33m)[m
Author: Mateusz <mateuszbiernat070899@gmail.com>
Date:   Mon Apr 27 21:52:37 2026 +0200

    feat: add user controls

[1mdiff --git a/CS/Udemy/WindowsStoreClone/WindowsStoreClone/MainWindow.xaml b/CS/Udemy/WindowsStoreClone/WindowsStoreClone/MainWindow.xaml[m
[1mindex 96cf75d..d044c1e 100644[m
[1m--- a/CS/Udemy/WindowsStoreClone/WindowsStoreClone/MainWindow.xaml[m
[1m+++ b/CS/Udemy/WindowsStoreClone/WindowsStoreClone/MainWindow.xaml[m
[36m@@ -6,7 +6,7 @@[m
         xmlns:local="clr-namespace:WindowsStoreClone"[m
         xmlns:uc="clr-namespace:WindowsStoreClone.UserControls"[m
         mc:Ignorable="d"[m
[31m-        Title="MainWindow"[m
[32m+[m[32m        Title="Windows Store Clone by Mateusz Biernat"[m
         Name="MainWindowMetro"[m
         Height="800" Width="1350">[m
     <Grid>[m
[1mdiff --git a/CS/Udemy/WindowsStoreClone/WindowsStoreClone/MainWindow.xaml.cs b/CS/Udemy/WindowsStoreClone/WindowsStoreClone/MainWindow.xaml.cs[m
[1mindex 4e9e6d4..2d656f9 100644[m
[1m--- a/CS/Udemy/WindowsStoreClone/WindowsStoreClone/MainWindow.xaml.cs[m
[1m+++ b/CS/Udemy/WindowsStoreClone/WindowsStoreClone/MainWindow.xaml.cs[m
[36m@@ -13,6 +13,7 @@[m [musing System.Windows.Media.Imaging;[m
 using System.Windows.Navigation;[m
 using System.Windows.Shapes;[m
 using WindowsStoreClone.Pages;[m
[32m+[m[32musing WindowsStoreClone.UserControls;[m
 [m
 namespace WindowsStoreClone[m
 {[m
[36m@@ -26,12 +27,29 @@[m [mnamespace WindowsStoreClone[m
         {[m
             InitializeComponent();[m
             MainWindowContentPage = new Main();[m
[32m+[m[32m            MainWindowContentPage.AppClicked += MainWindowContentPage_AppClicked;[m
[32m+[m
         }[m
[32m+[m[32m        private void MainWindowContentPage_AppClicked(AnApp sender, RoutedEventArgs e)[m
[32m+[m[32m        {[m
[32m+[m[32m            AppDetails myAppDetails = new AppDetails(sender);[m
[32m+[m[32m            myAppDetails.BackButtonClicked += MyAppDetails_BackButtonClicked;[m
[32m+[m[32m            MainWindowFrame.Content = myAppDetails;[m
[32m+[m[32m            myAppDetails.AppClicked += MainWindowContentPage_AppClicked;[m
[32m+[m[32m            MainWindowFrame.Content = myAppDetails;[m
 [m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        private void MyAppDetails_BackButtonClicked(object sender, RoutedEventArgs e)[m
[32m+[m[32m        {[m
[32m+[m[32m            if(MainWindowFrame.NavigationService.CanGoBack)[m
[32m+[m[32m            {[m
[32m+[m[32m                MainWindowFrame.NavigationService.GoBack();[m
[32m+[m[32m            }[m
[32m+[m[32m        }[m
         private void MainWindowFrame_Loaded(object sender, RoutedEventArgs e)[m
         {[m
[31m-            AppDetails myAppDetails = new AppDetails();[m
[31m-            MainWindowFrame.Content = myAppDetails;[m
[32m+[m[32m            MainWindowFrame.Content = MainWindowContentPage;[m
         }[m
     }[m
 }[m
[1mdiff --git a/CS/Udemy/WindowsStoreClone/WindowsStoreClone/Pages/AppDetails.xaml b/CS/Udemy/WindowsStoreClone/WindowsStoreClone/Pages/AppDetails.xaml[m
[1mindex 852dbd7..955b083 100644[m
[1m--- a/CS/Udemy/WindowsStoreClone/WindowsStoreClone/Pages/AppDetails.xaml[m
[1m+++ b/CS/Udemy/WindowsStoreClone/WindowsStoreClone/Pages/AppDetails.xaml[m
[36m@@ -5,6 +5,7 @@[m
       xmlns:d="http://schemas.microsoft.com/expression/blend/2008" [m
       xmlns:local="clr-namespace:WindowsStoreClone.Pages"[m
       xmlns:uc="clr-namespace:WindowsStoreClone.UserControls"[m
[32m+[m[32m      xmlns:ucappdet="clr-namespace:WindowsStoreClone.UserControls.AppDetailsTabContent"[m
       mc:Ignorable="d" [m
       d:DesignHeight="450" d:DesignWidth="800"[m
       Title="AppDetails">[m
[36m@@ -36,10 +37,18 @@[m
                     Grid.Column="1"[m
                     HorizontalAlignment="Stretch"[m
                     >[m
[31m-                    <TabItem Header="Overwiew" />[m
[31m-                    <TabItem Header="System Requirements" />[m
[31m-                    <TabItem Header="Reviews" />[m
[31m-                    <TabItem Header="Overwiew" />[m
[32m+[m[32m                    <TabItem Header="Overwiew">[m
[32m+[m[32m                        <ucappdet:Overview  x:Name="OverviewTabUC"/>[m
[32m+[m[32m                    </TabItem>[m
[32m+[m[32m                    <TabItem Header="System Requirements" >[m
[32m+[m[32m                        <ucappdet:SystemRequirements x:Name="SystemRequirementsUC" />[m
[32m+[m[32m                    </TabItem>[m
[32m+[m[32m                    <TabItem Header="Reviews" >[m
[32m+[m[32m                        <ucappdet:Reviews x:Name="ReviewsUC" />[m
[32m+[m[32m                    </TabItem>[m
[32m+[m[32m                    <TabItem Header="Related" >[m
[32m+[m[32m                        <ucappdet:Related x:Name="RelatedUC" />[m
[32m+[m[32m                    </TabItem>[m
                 </TabControl>[m
             </Grid>[m
         </StackPanel>[m
[1mdiff --git a/CS/Udemy/WindowsStoreClone/WindowsStoreClone/Pages/AppDetails.xaml.cs b/CS/Udemy/WindowsStoreClone/WindowsStoreClone/Pages/AppDetails.xaml.cs[m
[1mindex 195f42a..8631a28 100644[m
[1m--- a/CS/Udemy/WindowsStoreClone/WindowsStoreClone/Pages/AppDetails.xaml.cs[m
[1m+++ b/CS/Udemy/WindowsStoreClone/WindowsStoreClone/Pages/AppDetails.xaml.cs[m
[36m@@ -7,12 +7,12 @@[m [musing System.Windows;[m
 using System.Windows.Controls;[m
 using System.Windows.Data;[m
 using System.Windows.Documents;[m
[31m-using System.Windows.Input;[m
 using System.Windows.Media;[m
 using System.Windows.Media.Imaging;[m
 using System.Windows.Navigation;[m
 using System.Windows.Shapes;[m
[31m-[m
[32m+[m[32musing WindowsStoreClone.UserControls.AppDetailsTabContent;[m
[32m+[m[32musing WindowsStoreClone.UserControls;[m
 namespace WindowsStoreClone.Pages[m
 {[m
     /// <summary>[m
[36m@@ -20,9 +20,32 @@[m [mnamespace WindowsStoreClone.Pages[m
     /// </summary>[m
     public partial class AppDetails : Page[m
     {[m
[31m-        public AppDetails()[m
[32m+[m[32m        public delegate void OnBackButtonClicked(object sender, RoutedEventArgs e);[m
[32m+[m[32m        public event OnBackButtonClicked BackButtonClicked;[m
[32m+[m
[32m+[m[32m        public delegate void OnAppDetailsAnotherAppClicked(AnApp sender, RoutedEventArgs e);[m
[32m+[m[32m        public event OnAppDetailsAnotherAppClicked AppClicked;[m
[32m+[m
[32m+[m
[32m+[m[32m        public AppDetails(AnApp anApp)[m
         {[m
             InitializeComponent();[m
[32m+[m[32m            AppDetailsAndBackground.AppNameLabel.Content = anApp.AppName;[m
[32m+[m[32m            AppDetailsAndBackground.AppImage.Source = anApp.AppImageSource;[m
[32m+[m[32m            AppDetailsAndBackground.BackButtonClicked += AppDetailsAndBackground_BackButtonClicked;[m
[32m+[m
[32m+[m[32m            OverviewTabUC.AppClicked += OverviewTabUC_AnAppClicked;[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        public void AppDetailsAndBackground_BackButtonClicked(object sender, RoutedEventArgs e)[m
[32m+[m[32m        {[m
[32m+[m[32m            BackButtonClicked(sender, e);[m
[32m+[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        private void OverviewTabUC_AnAppClicked(AnApp sender, RoutedEventArgs e)[m
[32m+[m[32m        {[m
[32m+[m[32m            AppClicked(sender, e);[m
         }[m
     }[m
 }[m
[1mdiff --git a/CS/Udemy/WindowsStoreClone/WindowsStoreClone/Pages/Main.xaml.cs b/CS/Udemy/WindowsStoreClone/WindowsStoreClone/Pages/Main.xaml.cs[m
[1mindex bc36fbb..de939c3 100644[m
[1m--- a/CS/Udemy/WindowsStoreClone/WindowsStoreClone/Pages/Main.xaml.cs[m
[1m+++ b/CS/Udemy/WindowsStoreClone/WindowsStoreClone/Pages/Main.xaml.cs[m
[36m@@ -15,6 +15,7 @@[m [musing System.Windows.Media.Imaging;[m
 using System.Windows.Navigation;[m
 using System.Windows.Shapes;[m
 us