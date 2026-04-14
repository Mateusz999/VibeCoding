using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            int param1, param2;
            
            if(!int.TryParse(parametrOne.Text, out param1) || (!int.TryParse(parametrTwo.Text,out param2)))
            {
                return;
            }

            tbResult.Text = (param1 + param2).ToString(); 
        }

        private void btnPMinus_Click(object sender, RoutedEventArgs e)
        {
            int param1, param2;

            if (!int.TryParse(parametrOne.Text, out param1) || (!int.TryParse(parametrTwo.Text, out param2)))
            {
                return;
            }

            tbResult.Text = (param1 - param2).ToString();
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            int param1, param2;
            int result = 0;

            if (!int.TryParse(parametrOne.Text, out param1) || (!int.TryParse(parametrTwo.Text, out param2)))
            {
                return;
            }

            try
            {
                result = param1 / param2;

            }catch(DivideByZeroException ex)
            {

            }

            tbResult.Text = result.ToString();
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {
            int param1, param2;

            if (!int.TryParse(parametrOne.Text, out param1) || (!int.TryParse(parametrTwo.Text, out param2)))
            {
                return;
            }

            tbResult.Text = (param1 *param2).ToString();
        }
    }
}