using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Interfaces.UserInterface
{
    public class UserInterface : IUserInterface
    {
        public string GetUserInput()
        {
            return Console.ReadLine()?.ToLower();
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
