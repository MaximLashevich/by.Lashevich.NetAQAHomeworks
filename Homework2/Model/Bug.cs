namespace Homework2
{
    public class Bug
    {
        private Guid id;
        public Guid Id { get => id; }

        private DateTimeOffset creationDate;
        public DateTimeOffset CreationDate { get => creationDate; }

        public EnumPriority.Priority EnumPriority { get; set; }

        public string Summary { get; set; }

        public string? Precondition { get; set; }

        public EnumStatus.Status EnumStatus { get; set; }

        public Guid TestCaseId { get; set; }

        public int StepNumber { get; set; }

        public string ActualResult { get; set; }

        public string ExpectedResult { get; set; }

        public Bug(Guid id, DateTimeOffset creationDate, EnumPriority.Priority enumPriority, string summary, string? precondition, 
            EnumStatus.Status enumStatus, Guid testCaseId, int stepNumber, string actualResult, string expectedResult) 
        {
            this.id = id;
            this.creationDate = creationDate;
            EnumPriority = enumPriority;
            Summary = summary;
            Precondition = precondition;
            EnumStatus = enumStatus;
            TestCaseId = testCaseId;
            StepNumber = stepNumber;
            ActualResult = actualResult;
            ExpectedResult = expectedResult;
        }

        public static Bug FillBug(TestCase testCase)
        {
            Guid bugId = Guid.NewGuid();

            DateTimeOffset bugCreationDate = DateTimeOffset.Now;

            int successPriority;
            do
            {
                Console.Write("Enter Bug Priority. Type 1 for High, type 2 for Medium or type 3 for Low: ");
                successPriority = int.Parse(Console.ReadLine());
            } while (successPriority != 1 && successPriority != 2 && successPriority != 3);
            EnumPriority.Priority bugEnumPriority = (EnumPriority.Priority)successPriority;

            string bugSummary;
            do
            {
                Console.Write("Enter Bug Summary: ");
                bugSummary = Console.ReadLine();
            } while (string.IsNullOrEmpty(bugSummary) || string.IsNullOrWhiteSpace(bugSummary));

            string bugPrecondition = testCase.Precondition;

            int successStatus;
            do
            {
                Console.Write("Enter Bug Status. Type 1 for New, Type 2 for InProgress, Type 3 for Failed or Type 4 for Done: ");
                successStatus = int.Parse(Console.ReadLine());
            } while (successStatus != 1 && successStatus != 2 && successStatus != 3 && successStatus != 4);
            EnumStatus.Status bugEnumStatus = (EnumStatus.Status)successStatus;

            Guid bugTestCaseId = testCase.Id;

            bool successNumber;
            int stepNumber;
            do
            {
                Console.Write("Enter step's number: ");
                successNumber = int.TryParse(Console.ReadLine(), out stepNumber);
            } while (!successNumber);
            
            string actualResult;
            do
            {
                Console.Write("Enter actual result: ");
                actualResult = Console.ReadLine();
            } while (string.IsNullOrEmpty(actualResult) || string.IsNullOrWhiteSpace(actualResult));
            
            string bugExpectedResult = Step.ShowExpectedResult(testCase.StepsList, stepNumber);
            
            Bug bug = new Bug(bugId, bugCreationDate, bugEnumPriority, bugSummary, bugPrecondition, bugEnumStatus, bugTestCaseId,
                stepNumber, actualResult, bugExpectedResult);
            Console.WriteLine("Bug is successfully created.");
            return bug;
        }

        public static void ShowBug(Bug bug)
        {
            Console.WriteLine($"Bug id: {bug.Id}\nCreation date: {bug.CreationDate}\nPriority: {bug.EnumPriority}\nSummary: {bug.Summary}" +
                $"\nPrecondition: {bug.Precondition}\nStatus: {bug.EnumStatus}\nTest case Id: {bug.TestCaseId}\nStep number: {bug.StepNumber}" +
                $"\nActual Result: {bug.ActualResult}, \nExpected Result: {bug.ExpectedResult}");
        }
    }
}
