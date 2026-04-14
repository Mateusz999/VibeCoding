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
    /// Logika interakcji dla klasy ValueUC.xaml
    /// </summary>
    public partial class ValueUC : UserControl
    {
        public delegate void OnMinTresHoldReached(object sender, RoutedEventArgs e);
        public event OnMinTresHoldReached MinThresholdReached;

        public delegate void OnMaxTresHoldReached(object sender, RoutedEventArgs e);
        public event OnMaxTresHoldReached MaxThresholdReached;
        public ValueUC()
        {
            InitializeComponent();
        }

        private void PlusButtonClick(object sender, RoutedEventArgs e)
        {
            ValueLabel.Text = (Int32.Parse(ValueLabel.Text) + 10).ToString();

        }

        private void MinusButtonClick(object sender, RoutedEventArgs e)
        {
            ValueLabel.Text = (Int32.Parse(ValueLabel.Text) -10).ToString() ;
        }

        private void ValueLabel_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Int32.Parse((sender as TextBox).Text ) < 0)
            {
                (sender as TextBox).Text = "0";
                MinThresholdReached(sender, e);
            }

            if (Int32.Parse((sender as TextBox).Text) > 100)
            {
                (sender as TextBox).Text = "100";
                MaxThresholdReached(sender, e);
            }
        }
    }
}
