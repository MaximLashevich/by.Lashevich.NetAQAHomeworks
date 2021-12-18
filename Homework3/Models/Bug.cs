using System.Linq;

namespace Homework3
{
    [Serializable]
    public class Bug : Issue
    {
        public Guid? TestCaseId { get; set; }

        public int? StepNumber { get; set; }

        public string ActualResult { get; set; }

        public string ExpectedResult { get; set; }

        public Bug() : base()
        {
        }

        public Bug(Guid id, DateTimeOffset creationDate, Priority priority, string summary, string? precondition,
            Status status, Guid testCaseId, int stepNumber, string actualResult, string expectedResult)
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
                Console.Write("Enter Issue Summary: ");
                Summary = Console.ReadLine();
            } while (string.IsNullOrEmpty(Summary) || string.IsNullOrWhiteSpace(Summary));

            Console.Write("Enter Issue Precondition if there is any: ");
            Precondition = Console.ReadLine();

            Console.Write("Enter Test case Id if there is any: ");
            TestCaseId = Guid.Parse(Console.ReadLine());
            
            Console.Write("Enter step number if there is any: ");
            StepNumber = int.Parse(Console.ReadLine());
            
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

        public void SetFromFailedTestCase(TestCase testCase, Step step, string precondition)
        {
            base.Set();

            TestCaseId = testCase.Id;

            StepNumber = step.Number;

            ExpectedResult = step.ExpectedResult;

            Summary = step.ExpectedResult + "DOES NOT WORK";

            Precondition = testCase.Precondition + precondition;

            do
            {
                Console.Write("Enter actual result: ");
                ActualResult = Console.ReadLine();
            } while (string.IsNullOrEmpty(ActualResult) || string.IsNullOrWhiteSpace(ActualResult));
                        
        }
    }
}
