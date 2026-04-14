using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Security.Policy;
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

namespace WpfApp1
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

        private void txtInputValue_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse((txtInputValue.Text + e.Text), out int inputValue)
                || inputValue < 0
                || inputValue > 69
                || txtInputValue.Text.StartsWith("0");
        }

        private void txtInputValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            factorialBtn.IsEnabled = !string.IsNullOrEmpty(txtInputValue.Text);
            txtResult.Text = "";
        }


        private BigInteger factorialCalculations(BigInteger factorialBase)
        {
            return  (factorialBase == 0 || factorialBase == 1)
                    ? 1
                    : factorialBase * factorialCalculations(factorialBase - 1);
        }

        private async void factorialBtn_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            txtResult.Text = "Calculating...";
            factorialBtn.IsEnabled = false;
            await Task.Delay(3000);
            Mouse.OverrideCursor = null;
            txtResult.Text = factorialCalculations(int.Parse(txtInputValue.Text)).ToString();
            factorialBtn.IsEnabled = true;

            // C:\int\interviewResult.txt

            string path = "C:\\int\\interviewResult.txt";
            try
            {
                StreamWriter sw = new StreamWriter(path);

                sw.WriteLine($"Result {txtResult.Text}");

                sw.Close();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Saved data");
            }

            Process.Start(@"notepad.exe",path);


        }

        private void txtInputValue_GotFocus(object sender, RoutedEventArgs e)
        {
            txtInputValue.SelectAll();
        }

        private void txtInputValue_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
          
        }

        private void txtInputValue_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            e.CancelCommand();
        }
    }
}