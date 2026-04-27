using MiscUtil;
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

namespace WindowsStoreClone.UserControls.AppDetailsTabContent
{
    /// <summary>
    /// Logika interakcji dla klasy AReview.xaml
    /// </summary>
    public partial class AReview : UserControl
    {
        List<string> Names;

        public AReview()
        {
            InitializeComponent();
            Names = new List<string>() { "Matt", "Aiden", "Martin", "Nurul", "Tonny", "Chazayo","Mike", "Zoe","Arthur","Jackob" };

            string revierName = Names[StaticRandom.Next(Names.Count)];

            ReviewerNameLabel.Content = revierName;
            AvatarLabel.Content = revierName[0];
            NumOfStarsLabel.Content = GetRandomNumOfStars();
            ReviewTitle.Content = GetReviewTitleBasedOnStars(NumOfStarsLabel.Content.ToString());
            AvatarColor.Background = GetRandomBrush();
        }

        private string GetRandomNumOfStars()
        {
            string content = "";
            for (int i = 0;i<StaticRandom.Next(1,6);i++)
            {
                content += "★";
            }
            return content;
        }

        private static Random _random = new Random();

        private Brush GetRandomBrush()
        {
            byte r = (byte)_random.Next(0, 256);
            byte g = (byte)_random.Next(0, 256);
            byte b = (byte)_random.Next(0, 256);

            return new SolidColorBrush(Color.FromRgb(r, g, b));
        }
        private string GetReviewTitleBasedOnStars(string inStars)
        {
            string retStr = string.Empty;
            if (inStars.Length >= 4) retStr = "This app is really awesome.";
            else if (inStars.Length == 3) retStr = "This app is all right";
            else retStr = "This app is poor";

            return retStr;
        }
    }
}
