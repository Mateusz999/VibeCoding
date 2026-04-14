using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfCourse.Panels
{
    /// <summary>
    /// Logika interakcji dla klasy CatYears.xaml
    /// </summary>
    public partial class CatYears : Window
    {
        private TextBlock ResultTextBlock;
        private TextBox inputCatAge;

        private System.Windows.Controls.StackPanel horizontal;
        private System.Windows.Controls.StackPanel main;



        public CatYears()
        {
            InitializeComponent();

            Title = "Cat Years Calculator";
            Width = 400;
            Height = 250;

            BitmapImage bitmap = null;
            try
            {
                bitmap = new BitmapImage(new Uri("pack://application:,,,/Images/cat.jpg", UriKind.Absolute));
            }
            catch
            {
                string filePath = Path.Combine(Environment.CurrentDirectory, "..", "..", "Images", "cat.jpg");
                if (File.Exists(filePath))
                {
                    bitmap = new BitmapImage(new Uri(Path.GetFullPath(filePath), UriKind.Absolute));
                }
            }

            if (bitmap != null)
            {
                Background = new ImageBrush(bitmap)
                {
                    Stretch = Stretch.UniformToFill,
                    Opacity = 0.15
                };
            }

            ResultTextBlock = new TextBlock()
            {
                Foreground = Brushes.White,
                Text = "Your cat is",
                FontSize = 18,
                Margin = new Thickness(5)
            };

            inputCatAge = new TextBox()
            {
                Width = 120,
                TextAlignment = TextAlignment.Center,
                FontSize = 16,
                Margin = new Thickness(5, 0, 0, 0)
            };

            inputCatAge.KeyDown += InputCatAge_KeyDown;

            var calculateButton = new Button()
            {
                Content = "Calculate",
                Margin = new Thickness(5)
            };
            calculateButton.Click += CalculateButton_Click;

            var label = new TextBlock()
            {
                Text = "Cat age:",
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 16,
                Margin = new Thickness(0,0,5,0)
            };
            horizontal = new System.Windows.Controls.StackPanel()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(10)
            };
            horizontal.Children.Add(label);
            horizontal.Children.Add(inputCatAge);
            horizontal.Children.Add(calculateButton);

            main = new System.Windows.Controls.StackPanel();
            main.Children.Add(horizontal);
            main.Children.Add(ResultTextBlock);

            Content = main;
        }

        private void InputCatAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CalculateAndShowResult();
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            CalculateAndShowResult();
            TextBlock extra = new TextBlock() { Text = "Calculation of age" };
            main.Children.Add(extra);
        }

        private void CalculateAndShowResult()
        {
            if (!int.TryParse(inputCatAge.Text, out int catAge) || catAge < 0)
            {
                MessageBox.Show("Please enter a valid non-negative integer for cat age.", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string resultHumanAge;

            if (catAge == 0)
            {
                resultHumanAge = "0";
            }
            else if (catAge == 1)
            {
                resultHumanAge = "15";
            }
            else if (catAge == 2)
            {
                resultHumanAge = "24";
            }
            else
            {
                resultHumanAge = (24 + (catAge - 2) * 4).ToString();
            }

            ResultTextBlock.Text = $"Your cat is {resultHumanAge} years old.";
        }
    }
}
