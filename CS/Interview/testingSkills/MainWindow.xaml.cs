using System.Numerics;
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

namespace testingSkills
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
     
        private async void btnFactorial_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(txtInput.Text, out int factor);

            Mouse.OverrideCursor = Cursors.Wait;
            txtResult.Text = "calculating ... ";

            var result = await Task.Run(async () =>
            {
               return  factorialByIterations(factor);
            });

            await Task.Delay(3000);

            Mouse.OverrideCursor = null;
            txtResult.Text = result.ToString();
        }

        private void txtInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(txtInput.Text + e.Text, out int val)
                || val < 0 || val > 69 || txtInput.Text.StartsWith("0");
        }



        private BigInteger factorialByIterations(BigInteger factorialBase)
        {
            BigInteger baseNum = 1;
            if (factorialBase == 0 || factorialBase == 1) return 1;
            for (int i = 2; i <= factorialBase; i++)
            {
                baseNum *= i;
            }

            return baseNum;
        }

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnFactorial.IsEnabled = !string.IsNullOrEmpty(txtInput.Text);
            txtResult.Text = "";
        }

        private void txtInput_GotFocus(object sender, RoutedEventArgs e)
        {
            if(Keyboard.FocusedElement == txtInput 
                && Keyboard.IsKeyDown(Key.Tab))
            {
                txtInput.SelectAll();
            }
        }

       
        private void txtInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (!textBox.IsKeyboardFocusWithin)
            {
                e.Handled = true;
                textBox.Focus();
            }
        }

        private void txtInput_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if((Keyboard.Modifiers == ModifierKeys.Control) && e.Key == Key.V)
            {
                e.Handled = true;
            }
        }

        private void txtInput_Pasting(object sender, DataObjectPastingEventArgs e)
        {
             e.CancelCommand();
        }
    }
}