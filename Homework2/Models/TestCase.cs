using System.Collections;
using System.Text;

namespace Homework2
{
    public class TestCase : Issue
    {
        public List<Step> StepList { get; set; }

        public TestCase() : base()
        {
            this.StepList = new List<Step>();
        }

        public TestCase(Guid id, DateTimeOffset creationDate, Priority priority, string summary, string? precondition, Status status, ArrayList stepList)
            : base(id, creationDate, priority, summary, precondition, status)
        {
            this.StepList = new List<Step>();
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

            int moveOn;
            do
            {
                Step step = new Step();
                step.Set();
                StepList.Add(step);
                Console.WriteLine("\nStep is successfully created. \nType 1 to start entering new step or type 2 to stop input");
                moveOn = int.Parse(Console.ReadLine());
            } while (moveOn == 1);
        }
    }
}
