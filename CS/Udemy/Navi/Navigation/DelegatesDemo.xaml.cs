using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
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

namespace Navigation
{
    /// <summary>
    /// Logika interakcji dla klasy DelegatesDemo.xaml
    /// </summary>
    public partial class DelegatesDemo : Window
    {
        private SpeechSynthesizer synthesizer;
        public DelegatesDemo()
        {
            InitializeComponent();
            ValueController.MinThresholdReached += ValueController_MinThresHoldReached;
            ValueController.MaxThresholdReached += ValueController_MaxTresHoldReached;
            synthesizer = new SpeechSynthesizer();
            synthesizer.Volume = 50;
            synthesizer.Rate = 0;



        }

       
        private void ValueController_MinThresHoldReached(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show("Minimum Value Reached!");
            synthesizer.SpeakAsync("OSIĄGNIĘTO WARTOŚĆ MINIMALNĄ");
        }

        private void ValueController_MaxTresHoldReached(object sender, RoutedEventArgs e)
        {
          //  MessageBox.Show("Maximum Value Reached! ");
            synthesizer.SpeakAsync("OSIĄGNIĘTO WARTOŚĆ MAKSYMALNĄ");

        }
    }
}
