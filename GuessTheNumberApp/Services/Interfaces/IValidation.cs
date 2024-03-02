using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberConsoleApp.Services.Interfaces
{
    public interface IValidation
    {
        bool IsValidName(string name);
    }
}
