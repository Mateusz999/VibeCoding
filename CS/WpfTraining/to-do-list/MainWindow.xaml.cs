using System.Collections.ObjectModel;
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

namespace to_do_list;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public string SomeProperty { get; set; }


    public ObservableCollection<String> Tasks { get; set; }  = new ObservableCollection<string>();
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
    }

    private void addButton_Click(object sender, RoutedEventArgs e)
    {

        string task = taskInput.Text.Trim();
        if(!string.IsNullOrEmpty(task))
        {   
            Tasks.Add(task);
            taskInput.Clear();
        }
        else
        {
            MessageBox.Show("Nie podano zadania!",
                            "Błąd",
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning);
        }
    }
    private void removeButton_Click(object sender, RoutedEventArgs e)
    {
        if(taskList.SelectedItem != null)
        {
            if(taskList.SelectedItems.Count > 1)
            {
                var toRemove = taskList.SelectedItems.Cast<string>().ToList();
                foreach (var item in toRemove)
                {
                    Tasks.Remove(item);
                }
            }
            else
            {
               Tasks.Remove(taskList.SelectedItem.ToString());
            }
        }
        else
        {
            MessageBox.Show("Nie zaznaczono zadania!",
                         "Błąd",
                         MessageBoxButton.OK,
                         MessageBoxImage.Warning);
        }
    }



    private void taskInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        e.Handled = int.TryParse(e.Text, out _);
    }
}