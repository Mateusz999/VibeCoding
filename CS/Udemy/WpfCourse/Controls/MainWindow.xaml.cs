using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCourse
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /*            TextBlock myTb = new TextBlock();
                        myTb.Text = "Hi";
                        myTb.Inlines.Add(" I am !");
                        myTb.Inlines.Add(new Run(" Mateusz.")
                        {
                            Foreground = Brushes.Red,
                            TextDecorations = TextDecorations.Underline,
                            FontWeight = FontWeights.Bold
                        }) ;
                        myTb.TextWrapping = TextWrapping.Wrap;
                        myTb.Foreground = Brushes.BurlyWood;
                        this.Content = myTb;*/
            rbDuda.IsChecked = true;
        }

        private void Label_GotFocus(object sender, RoutedEventArgs e)
        {
            Label lab = (Label)sender;
            lab.BorderBrush = Brushes.Red;
            lab.BorderThickness = new Thickness(3, 3, 3, 3);
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            Label lab = (Label)sender;
            lab.BorderBrush = Brushes.Black;
            lab.BorderThickness = new Thickness(1,1,1,1);


        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
         /*   myLabel.Foreground = Brushes.SteelBlue;
            myLabel.FontWeight = FontWeights.Bold;*/
            myLabel.FontSize++;
        }

        private void myButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            myLabel.FontSize--;

        }

        private void myButton_MouseEnter(object sender, MouseEventArgs e)
        {
            myLabel.Foreground = Brushes.White;
        }

        private void myButton_MouseLeave(object sender, MouseEventArgs e)
        {
            myLabel.Foreground = Brushes.Black;

        }

        private void rbDuda_Checked(object sender, RoutedEventArgs e)
        {
            lbDuda.Background = Brushes.Aquamarine;
        }

        private void rbDuda_Unchecked(object sender, RoutedEventArgs e)
        {
            lbDuda.Background = Brushes.Coral;

        }
    }
}
