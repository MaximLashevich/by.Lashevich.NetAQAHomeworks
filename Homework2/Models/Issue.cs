namespace Homework2
{
    public abstract class Issue : IIssue
    {
        private Guid id;
        public Guid Id { get => id; }

        private DateTimeOffset creationDate;
        public DateTimeOffset CreationDate { get => creationDate; }

        public Priority Priority { get; set; }
        public string Summary { get; set; }
        public string? Precondition { get; set; }
        public Status Status { get; set; }

        public Issue()
        {
        }

        public Issue(Guid id, DateTimeOffset creationDate, Priority priority, string summary, string? precondition, Status status)
        {
            this.id = id;
            this.creationDate = creationDate;
            this.Priority = priority;
            this.Summary = summary;
            this.Precondition = precondition;
            this.Status = status;
        }

        public virtual string Get() 
        {
            return string.Concat($"\nId: {Id}", "\nCreation Date: ", CreationDate, "\nPriority: ", Priority, "\nSummary: ", Summary, "\nPrecondition: ", Precondition, "\nStatus: ", Status);
        }

        public virtual void Set() 
        {
            id = Guid.NewGuid();

            creationDate = DateTimeOffset.Now;


            int successPriority;
            do
            {
                Console.Write("\nEnter Issue Priority. Type 1 for High, type 2 for Medium or type 3 for Low: ");
                successPriority = int.Parse(Console.ReadLine());
            } while (successPriority != 1 && successPriority != 2 && successPriority != 3);
            Priority = (Priority)successPriority - 1;

            
            do
            {
                Console.Write("Enter Issue Summary: ");
                Summary = Console.ReadLine();
            } while (string.IsNullOrEmpty(Summary) || string.IsNullOrWhiteSpace(Summary));


            Console.Write("Enter Issue Precondition if there is any: ");
            Precondition = Console.ReadLine();


            int successStatus;
            do
            {
                Console.Write("Enter Issue Status. Type 1 for New, Type 2 for InProgress, Type 3 for Failed or Type 4 for Done: ");
                successStatus = int.Parse(Console.ReadLine());
            } while (successStatus != 1 && successStatus != 2 && successStatus != 3 && successStatus != 4);
            Status = (Status)successStatus - 1;
        }       
        
    }
}
