using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Methods
{
    public static class CommonMethods
    {
        public static bool IsPasswordComplex(string password)
        {
            // Check if password is at least 8 characters long
            if (password.Length < 8)
            {
                return false;
            }

            // Check if password contains at least one uppercase letter
            if (!password.Any(char.IsUpper))
            {
                return false;
            }

            // Check if password contains at least one lowercase letter
            if (!password.Any(char.IsLower))
            {
                return false;
            }

            // Check if password contains at least one digit
            if (!password.Any(char.IsDigit))
            {
                return false;
            }

            // Check if password contains at least one special character
            if (!password.Any(c => !char.IsLetterOrDigit(c)))
            {
                return false;
            }

            // Password meets all criteria for complexity
            return true;
        }

        public static bool IsValidEmail(string email)
        {
            // Check if the email is null or empty
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            try
            {
                // Use .NET's built-in MailAddress class to validate the email format
                var mailAddress = new System.Net.Mail.MailAddress(email);
                return mailAddress.Address == email;
            }
            catch (FormatException)
            {
                // The email format is invalid
                return false;
            }
        }

        public static bool IsValidBirthDate(DateTime birthDate)
        {
            // Check if the birth date is not in the future
            if (birthDate > DateTime.Now)
            {
                return false;
            }

            // Check if the age is within a reasonable range (e.g., between 18 and 120 years old)
            int minAge = 18;
            int maxAge = 120;
            DateTime minDate = DateTime.Now.AddYears(-maxAge);
            DateTime maxDate = DateTime.Now.AddYears(-minAge);

            return (birthDate >= minDate && birthDate <= maxDate);
        }
    }
}
