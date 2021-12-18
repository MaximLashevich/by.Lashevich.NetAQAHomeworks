namespace Homework3
{
    [Serializable]
    public class Step
    {
        public int Number { get; set; }
        public string Action { get; set; }
        public string ExpectedResult { get; set; }


        public Step()
        {
        }

        public Step(string stepAction, string stepExpectedResult)
        {
            Action = stepAction;
            ExpectedResult = stepExpectedResult;

        }

        public void Set()
        {
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
        
    }
}
