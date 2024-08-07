using Core.Db;
using Core.Enums;
using Core.Models;
using System.Text.RegularExpressions;

namespace Core.Validations
{
    internal static class ModelValidator
    {
        internal static RegisterStatus ValidateUserRegistrationInfo(UserRegistrationInfo userInfo, IDb db)
        {
            if (userInfo.Password != userInfo.ConfirmedPassword)
            {
                return RegisterStatus.PasswordsDontMatch;
            }

            var isValidEmail = Regex.IsMatch(userInfo.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!isValidEmail)
            {
                return RegisterStatus.InvalidEmail;
            }

            var hasValidLength = userInfo.Password.Length >= 8;

            var containsLowerCase = userInfo.Password.Any(char.IsLower);
            var containsUpperCase = userInfo.Password.Any(char.IsUpper);
            var containsSymbol = userInfo.Password.Any(char.IsSymbol);
            var containsNumber = userInfo.Password.Any(char.IsDigit);

            bool[] conditions =
            {
                containsLowerCase,
                containsUpperCase,
                containsSymbol,
                containsNumber,
            };

            int conditionsMet = conditions.Count(condition => condition);

            if (!hasValidLength || conditionsMet < 3)
            {
                return RegisterStatus.WeakPassword;
            }

            if (db.ContainsUser(userInfo.Username))
            {
                return RegisterStatus.UsernameAlreadyTaken;
            }

            return RegisterStatus.Success;
        }
    }
}
