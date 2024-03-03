using Microsoft.Extensions.Options;

namespace GuessTheNumberConsoleApp.Services.Interfaces
{
    public interface IValidation
    {
        bool IsValidName(string name);
        bool IsValidAnswer(string answer);
        bool IsPositiveAnswer(string answer);
        bool IsNegativeAnswer(string answer);
        bool IsValidHandleAnswer(List<string> options, string answer);
    }
}
