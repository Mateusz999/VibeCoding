using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;

namespace CalculatorAppTest
{

    public class CalculatorAppPage
    {
        private readonly Window _window;

        public CalculatorAppPage(Window window)
        {
            _window = window;
        }

        public TextBox Param1 =>
            _window.FindFirstDescendant(cf => cf.ByAutomationId("parametrOneTest")).AsTextBox();

        public TextBox Param2 =>
            _window.FindFirstDescendant(cf => cf.ByAutomationId("parametrTwoTest")).AsTextBox();

        public Button BtnPlus =>
            _window.FindFirstDescendant(cf => cf.ByAutomationId("btnPlusTest")).AsButton();

        public Button BtnMinus =>
            _window.FindFirstDescendant(cf => cf.ByAutomationId("btnMinusTest")).AsButton();

        public Button BtnDivide =>
            _window.FindFirstDescendant(cf => cf.ByAutomationId("btnDivideTest")).AsButton();

        public Button BtnMultiply =>
            _window.FindFirstDescendant(cf => cf.ByAutomationId("btnMultiplyTest")).AsButton();

        public Label Result =>
            _window.FindFirstDescendant(cf => cf.ByAutomationId("tbResultTest")).AsLabel();

        public void EnterValues(int a, int b)
        {
            Param1.Text = a.ToString();
            Param2.Text = b.ToString();
        }

        public string GetResult()
        {
            return int.Parse(Result.Text).ToString();
        }
    }



    public class UnitTest1
    {
        [Theory]
        [InlineData(5,5,10)]
        [InlineData(5,1,6)]
        [InlineData(5,15,20)]
        [InlineData(15,5,20)]
        [InlineData(5,5,10)]
        [InlineData(-5,5,0)]
        [InlineData(5,5,10)]
        public void addition_test_automation(int a, int b, int except)
        {
            Application app = FlaUI.Core.Application.Launch(@"C:\Users\mateu\Desktop\VibeCoding\CS\FLAUI\CalculatorApp\bin\Debug\net9.0-windows\CalculatorApp.exe");

            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                CalculatorAppPage calc = new(window);

                calc.EnterValues(a, b);
                calc.BtnPlus.Invoke();
                Thread.Sleep(200);
                Assert.Equal(except.ToString(),calc.GetResult());

            }
            app.Close();
        }

        [Theory]
        [InlineData(5,0,0)]
        [InlineData(5,1,5)]
        [InlineData(5,2,2)]
        [InlineData(5,3,1)]
        public void divide_test_automation(int a, int b, int except)
        {
            Application app = FlaUI.Core.Application.Launch(@"C:\Users\mateu\Desktop\VibeCoding\CS\FLAUI\CalculatorApp\bin\Debug\net9.0-windows\CalculatorApp.exe");

            using ( var automation = new UIA3Automation())
            {
                Window window = app.GetMainWindow(automation);
                CalculatorAppPage calc = new(window);

                calc.EnterValues(a, b);
                calc.BtnDivide.Invoke();
                Thread.Sleep(200);
                Assert.Equal(except.ToString(), calc.GetResult());

            }
            app.Close();

        }

    }
}
