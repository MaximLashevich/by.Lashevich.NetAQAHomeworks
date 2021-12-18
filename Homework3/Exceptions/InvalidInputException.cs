namespace Homework3
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException() : base("Invalid input!")
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
