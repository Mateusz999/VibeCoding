using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace to_do_list
{
    public class WithoutNumbersInInput : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string text = value?.ToString() ?? "";

            if (text.Any(char.IsDigit))
            {
                return new ValidationResult(false, "Nie wolno wpisywać cyfr");
            }

            return ValidationResult.ValidResult;
        }
    }
}
