using System;
using System.Text.RegularExpressions;

namespace PersonnelDepartmentApp.Utils
{
    
    /// Клас з методами для валідації введених користувачем даних.
    
    public static class ValidationUtils
    {
        public static bool IsValidPassport(string passportNumber)
        {
            if (string.IsNullOrWhiteSpace(passportNumber))
                return false;

            // Простий приклад: дві літери + 6 цифр
            var pattern = @"^[A-Z]{2}\d{6}$";
            return Regex.IsMatch(passportNumber, pattern);
        }

        public static bool IsPositiveDecimal(string input, out decimal value)
        {
            bool success = decimal.TryParse(input, out value);
            return success && value > 0;
        }

        // Додай інші методи валідації за потребою
    }
}
