using System.Collections;
using System.Text;

namespace Homework3
{
    [Serializable]
    public class TestCase : Issue
    {
        public List<Step> StepList { get; set; }

        public TestCase() : base()
        {
            StepList = new List<Step>();
        }

        public TestCase(Guid id, DateTimeOffset creationDate, Priority priority, string summary, string? precondition, Status status, ArrayList stepList)
            : base(id, creationDate, priority, summary, precondition, status)
        {
            StepList = new List<Step>();
        }

        public override string Get()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Concat(base.Get(), "\nStep List: "));
            foreach (Step step in StepList) { sb.Append(step.Get()); }
            return sb.ToString();
        }

        public override void Set()
        {
            base.Set();

            Console.Write("Enter Issue Precondition if there is any: ");
            Precondition = Console.ReadLine();

            do
            {
                Console.Write("Enter Issue Summary: ");
                Summary = Console.ReadLine();
            } while (string.IsNullOrEmpty(Summary) || string.IsNullOrWhiteSpace(Summary));

            int i = 0;
            int moveOn;
            do
            {
                Step step = new Step();
                step.Set();
                step.Number = ++i;
                StepList.Add(step);

                Console.WriteLine("\nStep is successfully created. \nType 1 to start entering new step or type 2 to stop input");
                moveOn = int.Parse(Console.ReadLine());
            } while (moveOn == 1);
        }
    }
}
