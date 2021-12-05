using System.Collections;

namespace Homework2
{
    public class TestCase : Issue
    {
        public ArrayList StepsList { get; set; }

        public TestCase(Guid id, DateTimeOffset creationDate, EnumPriority.Priority enumPriority, string summary, string? precondition, EnumStatus.Status enumStatus, ArrayList stepsList)
            : base(id, creationDate, enumPriority, summary, precondition, enumStatus)
        {
            this.StepsList = stepsList;
        }

        public static TestCase FillTestCase()
        {
            Guid testCaseId = Guid.NewGuid();

            DateTimeOffset testCaseCreationDate = DateTimeOffset.Now;


            int successPriority;
            do
            {
                Console.Write("Enter Test case Priority. Type 1 for High, type 2 for Medium or type 3 for Low: ");
                successPriority = int.Parse(Console.ReadLine());
            } while (successPriority != 1 && successPriority != 2 && successPriority != 3);
            EnumPriority.Priority testCaseEnumPriority = (EnumPriority.Priority)successPriority;

            string testCaseSummary;
            do
            {
                Console.Write("Enter Test case Summary: ");
                testCaseSummary = Console.ReadLine();
            } while (string.IsNullOrEmpty(testCaseSummary) || string.IsNullOrWhiteSpace(testCaseSummary));

            Console.Write("Enter Test case Precondition if there is any: ");
            string testCasePrecondition = Console.ReadLine();

            int successStatus;
            do
            {
                Console.Write("Enter Test case Status. Type 1 for New, Type 2 for InProgress, Type 3 for Failed or Type 4 for Done: ");
                successStatus = int.Parse(Console.ReadLine());
            } while (successStatus != 1 && successStatus != 2 && successStatus != 3 && successStatus != 4);
            EnumStatus.Status testCaseEnumStatus = (EnumStatus.Status)successStatus;

            TestCase testCase = new TestCase(testCaseId, testCaseCreationDate, testCaseEnumPriority, testCaseSummary,
                testCasePrecondition, testCaseEnumStatus, Step.FillStepsCollection());
            Console.WriteLine("Test case is successfully created.");
            return testCase;
        }
        public static void ShowTestCase(TestCase testCase)
        {
            Console.WriteLine($"Test case id: {testCase.Id}\nCreation date: {testCase.CreationDate}\nPriority: {testCase.EnumPriority}\nSummary: {testCase.Summary}\nPrecondition: {testCase.Precondition}\nStatus: {testCase.EnumStatus}");
            Console.WriteLine("Steps for the above Test case:");
            Step.ShowSteps(Step.FillStepsCollection());
        }
    }
}
