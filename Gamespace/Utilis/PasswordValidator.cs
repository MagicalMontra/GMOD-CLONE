using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Gamespace.Utilis
{
    public static class PasswordValidator
    {
        public enum PasswordScore
        {
            Blank = 0,
            VeryWeak = 1,
            Weak = 2,
            Medium = 3,
            Strong = 4,
            VeryStrong = 5
        }
        public static float Validate(PasswordScore targetScore)
        {
            var score = (float)(int)targetScore;
            var max = (float)Enum.GetValues(typeof(PasswordScore)).Cast<int>().Max();
            return score / max;
        }
        public static float Value(string password)
        {
            var score = 1;
            var max = (float)Enum.GetValues(typeof(PasswordScore)).Cast<int>().Max();

            if (password.Length < 1)
                return 0;

            if (password.Length >= 8)
                score++;
            if (Regex.IsMatch(password, @"[0-9]+(\.[0-9][0-9]?)?", RegexOptions.ECMAScript))
                score++;
            if (Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z]).+$", RegexOptions.ECMAScript))
                score++;
            if (Regex.IsMatch(password, @"[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]", RegexOptions.ECMAScript))
                score++;

            return score / max;
        }
    }
}