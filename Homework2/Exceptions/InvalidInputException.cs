using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException() : base("Invalid input. Input number should correspond to options list")
        {
        }

        public void ShowMessage()
        {
            Console.Clear();
            Console.WriteLine(Message);
            Console.ReadKey();
        }       
    }
}
