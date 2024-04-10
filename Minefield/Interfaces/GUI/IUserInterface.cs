using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Interfaces.UserInterface
{
    public interface IUserInterface
    {
        string GetUserInput();
        void DisplayMessage(string message);
    }

}
