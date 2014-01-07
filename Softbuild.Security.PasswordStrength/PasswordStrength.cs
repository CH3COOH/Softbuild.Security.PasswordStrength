using System;
using System.Linq;

namespace Softbuild.Security
{
    public class PasswordStrength
    {
        private string password { get; set; }

        private double validComplexity { get; set; }

        public PasswordStrength()
            : this (null)
        {
        }

        public PasswordStrength(string password)
        {
            this.password = password;
        }

        static public PasswordStrengthResult Validate(string password, float minimusComplexity = 0.0f)
        {
            var strength = new PasswordStrength(password);
            if (minimusComplexity > 0.0f)
            {
                strength.validComplexity = minimusComplexity;
            }
            return strength.Validate();
        }

        public PasswordStrengthResult Validate()
        {
            var result = new PasswordStrengthResult();
            if (string.IsNullOrWhiteSpace(password))
            {
                return result;
            }

            result.Complexity += password.ToCharArray().Distinct().Count() / 10.0f;

            var charsetsArray = new[] {
                new {Min = Convert.ToChar(0x0030), Max = Convert.ToChar(0x0039) }, // Numbers
                new {Min = Convert.ToChar(0x0041), Max = Convert.ToChar(0x005A) }, // Uppercase
                new {Min = Convert.ToChar(0x0061), Max = Convert.ToChar(0x007A) }, // Lowercase
                new {Min = Convert.ToChar(0x0021), Max = Convert.ToChar(0x002F) }, // Punctuation
                new {Min = Convert.ToChar(0x003A), Max = Convert.ToChar(0x0040) }, // Punctuation
                new {Min = Convert.ToChar(0x005B), Max = Convert.ToChar(0x0060) }, // Punctuation
                new {Min = Convert.ToChar(0x007B), Max = Convert.ToChar(0x007E) }, // Punctuation
            };
            result.Complexity += charsetsArray.Select(e => AdditionalComplexity(e.Min, e.Max))
                .Sum();

            result.Complexity = (float)Math.Log(Math.Pow(result.Complexity * 100f, password.Length)) / 100.0f;
            result.Complexity = (result.Complexity > 1.0f) ? 1.0f : result.Complexity;
            result.Valid = (result.Complexity > validComplexity);

            return result;
        }

        private float AdditionalComplexity(char min, char max)
        {
            return password.ToCharArray()
                .Where(e => min <= e && e <= max)
                .Select(_ => (max - min) / 10.0f)
                .FirstOrDefault();
        }

    }


}
