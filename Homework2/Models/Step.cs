using System.Collections;

namespace Homework2
{
    public class Step
    {
        public int Number { get; set; }
        public string Action { get; set; }
        public string ExpectedResult { get; set; }


        public Step()
        {
        }

        public Step(int stepNumber, string stepAction, string stepExpectedResult)
        {
            this.Number = stepNumber;
            this.Action = stepAction;
            this.ExpectedResult = stepExpectedResult;

        }

        public void Set()
        {
            bool successNumber;
            int stepNumber;
            do
            {
                Console.Write("\nEnter step number: ");
                successNumber = int.TryParse(Console.ReadLine(), out stepNumber);
            } while (!successNumber);
            Number = stepNumber;


            do
            {
                Console.Write("Enter step action: ");
                Action = Console.ReadLine();
            } while (string.IsNullOrEmpty(Action) || string.IsNullOrWhiteSpace(Action));


            do
            {
                Console.Write("Enter step expected result: ");
                ExpectedResult = Console.ReadLine();
            } while (string.IsNullOrEmpty(ExpectedResult) || string.IsNullOrWhiteSpace(ExpectedResult));
        }

        public string Get()
        {
            return string.Concat("\nStep number: ", Number, "\nAction: ", Action, "\nExpected Result:", ExpectedResult, "\n");
        }

        public static string ShowExpectedResult(ArrayList stepList, int i)
        {
            Step foundStep = (Step)stepList[i];
            return foundStep.ExpectedResult;
        }

    }
}
