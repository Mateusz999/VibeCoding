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

namespace Calculator;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        calc.AddHandler(Button.ClickEvent, new RoutedEventHandler(ParentButton_Click));
    }

    private void ParentButton_Click(object sender, RoutedEventArgs e)
    {
        if(e.OriginalSource is Button btn)
        {
            string value = btn.Content.ToString();
            result.Text = value;

            if(value == "=")
            {
                result.Text = "calculated";
            }
        }
    }

    private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
    {

    }
}