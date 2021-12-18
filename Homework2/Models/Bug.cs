namespace Homework2
{
    [Serializable]
    public class Bug : Issue
    {
        public string TestCaseId { get; set; }

        public int StepNumber { get; set; }

        public string ActualResult { get; set; }

        public string ExpectedResult { get; set; }

        public Bug() : base()
        {
        }

        public Bug(Guid id, DateTimeOffset creationDate, Priority priority, string summary, string? precondition,
            Status status, string testCaseId, int stepNumber, string actualResult, string expectedResult)
            : base(id, creationDate, priority, summary, precondition, status)
        {
            TestCaseId = testCaseId;
            StepNumber = stepNumber;
            ActualResult = actualResult;
            ExpectedResult = expectedResult;
        }

        public override string Get()
        {
            return string.Concat(base.Get(), "\nTest Case Id: ", TestCaseId, "\nStep Number: ", StepNumber, "\nActual Result: ", 
                ActualResult, "\nExpected Result: ", ExpectedResult, "\n");
        }

        public override void Set()
        {
            base.Set();
            do
            {
                Console.Write("Enter Test case Id: ");
                TestCaseId = Console.ReadLine();
            } while (string.IsNullOrEmpty(TestCaseId) || string.IsNullOrWhiteSpace(TestCaseId));

            bool successNumber;
            int stepNumber;
            do
            {
                Console.Write("Enter step number: ");
                successNumber = int.TryParse(Console.ReadLine(), out stepNumber);
            } while (!successNumber);
            StepNumber = stepNumber;

            do
            {
                Console.Write("Enter actual result: ");
                ActualResult = Console.ReadLine();
            } while (string.IsNullOrEmpty(ActualResult) || string.IsNullOrWhiteSpace(ActualResult));

            do
            {
                Console.Write("Enter expected result: ");
                ExpectedResult = Console.ReadLine();
            } while (string.IsNullOrEmpty(ExpectedResult) || string.IsNullOrWhiteSpace(ExpectedResult));
        }
    }
}
