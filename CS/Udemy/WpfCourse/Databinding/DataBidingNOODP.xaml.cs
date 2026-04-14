using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfCourse.Databinding
{
    /// <summary>
    /// Logika interakcji dla klasy DataBidingNOODP.xaml
    /// </summary>
    public partial class DataBidingNOODP : Window
    {
        public ObservableCollection<int> AvailableNumbers { get; set; }
        public DataBidingNOODP()
        {
            AvailableNumbers = new ObservableCollection<int>();
            int counter = 0;
            for(int i = 0;i < 10; i++)
            {
                AvailableNumbers.Add(counter++);
            }
            InitializeComponent();

            //    this.DataContext = this;
        }

        private void AddNumber(object sender, RoutedEventArgs e)
        {
            AvailableNumbers.Add(AvailableNumbers.Count+ 1);
        }

        private void DeleteNumber(object sender, RoutedEventArgs e)
        {
           if(AvailableNumbers.Count > 0)  AvailableNumbers.RemoveAt(0);

        }
    }
}
