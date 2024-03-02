using GuessTheNumberConsoleApp.Services.Interfaces;
using System.Text.RegularExpressions;

namespace GuessTheNumberConsoleApp.Services.Models
{
    public class Validation : IValidation
    {
        public bool IsValidName(string name)
        {
            string pattern = @"^[а-яА-ЯёЁ0-9]+$";
            var match = Regex.Match(name, pattern, RegexOptions.IgnoreCase);
            return match.Success;
            
        }
    }
}
