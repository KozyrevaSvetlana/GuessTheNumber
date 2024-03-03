using GuessTheNumberConsoleApp.Services.Interfaces;
using System.Text.RegularExpressions;

namespace GuessTheNumberConsoleApp.Services.Models
{
    public class Validation : IValidation
    {
        private static readonly List<string> positiveAnswers = new List<string>()
        {
        "да", "д","конечно","еще бы","давай","y","yes","хочу"
        };
        private static readonly List<string> negativeAnswers = new List<string>()
        {
        "нет", "не","н","ноу","неа","не хочу","no"
        };
        public bool IsValidName(string name)
        {
            string pattern = @"^[а-яА-ЯёЁ0-9]+$";
            var match = Regex.Match(name, pattern, RegexOptions.IgnoreCase);
            return match.Success;
        }

        public bool IsValidAnswer(string answer)
        {
            return positiveAnswers.Contains(answer) || negativeAnswers.Contains(answer);
        }

        public bool IsPositiveAnswer(string answer)
        {
            return positiveAnswers.Contains(answer) || negativeAnswers.Contains(answer);
        }

        public bool IsNegativeAnswer(string answer)
        {
            return negativeAnswers.Contains(answer);
        }

        public bool IsValidHandleAnswer(List<string> options, string answer)
        {
            if (!options.Any())
                throw new ArgumentNullException(nameof(options));
            return options.Contains(answer);
        }
    }
}
