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

namespace InterviewApp;

public partial class MainWindow : Window
{
    private ICalculationService _calculationService;

    public MainWindow(ICalculationService calculationService)
    {
        InitializeComponent();
        _calculationService = calculationService;

    }

    private void txtInputValue_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
       /* if (txtInputValue.SelectionLength == txtInputValue.Text.Length  
            && txtInputValue.SelectionLength > 0)
        {
            txtInputValue.Text = "";
        }*/

        e.Handled = !int.TryParse(txtInputValue.Text + e.Text, out int value)
             || value < 0 
             || value >= 70
             || txtInputValue.Text.StartsWith("0");

    }

    private void txtInputValue_TextChanged(object sender, TextChangedEventArgs e)
    {
        btnFactorial.IsEnabled = !string.IsNullOrWhiteSpace(txtInputValue.Text);
        txtResult.Text = "";
    }



    private async void btnFactorial_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            btnFactorial.IsEnabled = false;

            if (!BigInteger.TryParse(txtInputValue.Text, out var n))
            {
                txtResult.Text = "Incorrect value.";
                return;
            }
            txtResult.Text = "Calculating...";
            Mouse.OverrideCursor = Cursors.Wait;

            await Task.Delay(3000);
            Mouse.OverrideCursor = null;
            var result = await Task.Run(() =>
                _calculationService.iterationalCalculations(n)
            );



            txtResult.Text = result.ToString();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            btnFactorial.IsEnabled = true;
        }
    }


    private void txtInputValue_GotFocus(object sender, RoutedEventArgs e)
    {
        if (Keyboard.FocusedElement == txtInputValue && Keyboard.IsKeyDown(Key.Tab))
        {
            txtInputValue.SelectAll();
        }
    }

    private void txtInputValue_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        var textBox = (TextBox)sender;
        if (!textBox.IsKeyboardFocusWithin)
        {
            e.Handled = true;
            textBox.Focus();
        }
    }


    // handled true if you gonna paste by means of Ctrl + V 
    private void txtInputValue_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if ((Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.V))
        {
            e.Handled = true;
        }
    }


    // cancel if you mouseclick then try paste 
    private void txtInputValue_Pasting(object sender, DataObjectPastingEventArgs e)
    {
        e.CancelCommand();
    }

}

