using System.Configuration;
using System.Data;
using System.Windows;

namespace InterviewApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>

public partial class App : Application
{
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        ICalculationService calculationService = new CalculationService();

        var mainWindow = new MainWindow(calculationService);
        MainWindow = mainWindow;
        mainWindow.Show();
    }

}
