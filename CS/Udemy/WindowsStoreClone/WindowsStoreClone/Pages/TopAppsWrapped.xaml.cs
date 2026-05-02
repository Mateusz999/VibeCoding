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
using WindowsStoreClone.UserControls;

namespace WindowsStoreClone.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy TopAppsWrapped.xaml
    /// </summary>
    public partial class TopAppsWrapped : Page
    {
        public delegate void OnAnAppClicked(AnApp sender, RoutedEventArgs e);
        public event OnAnAppClicked AnAppClicked;

        public delegate void OnBackButtonClicked(object sender, RoutedEventArgs e);
        public event OnBackButtonClicked BackButtonClicked;
        public TopAppsWrapped()
        {
            InitializeComponent();
            for(int i = 0; i < 20; i++)
            {
                AnApp app = new AnApp();
                app.AppClicked += app_AppCliked;
                TopAppsWrappedPageMainWrapPanel.Children.Add(app);
            }
        }

        private void app_AppCliked(AnApp app,RoutedEventArgs e )
        {
            AnAppClicked(app,e);
        }

        private void BackButtn_Click(object sender, RoutedEventArgs e)
        {
            BackButtonClicked(sender, e);
        }

        private void TopAppsWrappedPageMainSV_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if(e.VerticalChange > 0)
            {
                int adjustment = 400;
                if(e.VerticalOffset + e.ViewportHeight + adjustment >= e.ExtentHeight)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        AnApp app = new AnApp();
                        app.AppClicked += app_AppCliked;
                        TopAppsWrappedPageMainWrapPanel.Children.Add(app);
                    }
                }
            }
        }

    }
}
