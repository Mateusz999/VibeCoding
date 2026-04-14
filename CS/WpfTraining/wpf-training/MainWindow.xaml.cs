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

namespace wpf_training;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void inputTekstowy_TextChanged(object sender, TextChangedEventArgs e)
    {
        string value = inputTekstowy.Text;
        if(int.TryParse(value, out int wartosc))
        {
            if(wartosc >= 0 && wartosc <= 100)
            {
                podanaWartosc.Text = "Podana wartość spełnia kryteria";

            }else
            {
                podanaWartosc.Text = "Przekroczono zakres";

            }
        } else
        {
            podanaWartosc.Text = $"Błąd {value} nie jest liczba";

        }

        //podanaWartosc.Text = $"Podana wartość: {value}";

    }

    private void GetInput_Click(object sender, RoutedEventArgs e)
    {
        string value = inputTekstowy.Text;

        podanaWartosc.Text = $"Podana wartość: {value}" ;

    }

    private void inputTekstowy_2_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        e.Handled = int.TryParse(e.Text, out _);
    }
}