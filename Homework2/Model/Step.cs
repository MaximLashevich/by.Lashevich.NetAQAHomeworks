using System.Collections;

namespace Homework2
{
    public class Step
    {
        public int Number { get; set; }
        public string Action { get; set; }
        public string ExpectedResult { get; set; }

        public Step(int stepNumber, string stepAction, string stepExpectedResult)
        {
            Number = stepNumber;
            Action = stepAction;
            ExpectedResult = stepExpectedResult;
        }

        public ArrayList FillStepsCollection()
        {
            ArrayList stepsList = new ArrayList();
            int moveOn;
            do
            {
                bool successNumber;
                int stepNumber;
                do
                {
                    Console.Write("Enter step's number: ");
                    successNumber = int.TryParse(Console.ReadLine(), out stepNumber);
                } while (!successNumber);

                string stepAction;
                do
                {
                    Console.Write("Enter step's action: ");
                    stepAction = Console.ReadLine();
                } while (string.IsNullOrEmpty(stepAction) || string.IsNullOrWhiteSpace(stepAction));

                string stepExpectedResult;
                do
                {
                    Console.Write("Enter step's expected result: ");
                    stepExpectedResult = Console.ReadLine();
                } while (string.IsNullOrEmpty(stepExpectedResult) || string.IsNullOrWhiteSpace(stepExpectedResult));

                Step step = new Step(stepNumber, stepAction, stepExpectedResult);

                stepsList.Add(step);

                Console.WriteLine("Step is successfully crested. \nType \"1\" to start entering new step or type \"2\" to stop input");
                moveOn = int.Parse(Console.ReadLine());
            } while (moveOn == 1);
            return stepsList;
        }
        public void ShowSteps(ArrayList stepsList)
        {
            foreach (Step step in stepsList)
            {
                Console.WriteLine($"Step number: {step.Number}\nAction: {step.Action}\nExpected Result: {step.ExpectedResult}");
            }
        }
    }
}
