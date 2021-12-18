namespace Homework3
{
    [Serializable]
    public abstract class Issue : IIssue
    {
        public Guid Id { get; private set; }

        public DateTimeOffset CreationDate { get; private set; }

        public Priority Priority { get; set; }
        public string Summary { get; set; }
        public string? Precondition { get; set; }
        public Status Status { get; set; }

        public Issue()
        {
        }

        public Issue(Guid id, DateTimeOffset creationDate, Priority priority, string summary, string? precondition, Status status)
        {
            Id = id;
            CreationDate = creationDate;
            Priority = priority;
            Summary = summary;
            Precondition = precondition;
            Status = status;
        }

        public virtual string Get() 
        {
            return string.Concat($"\nId: {Id}", "\nCreation Date: ", CreationDate, "\nPriority: ", Priority, "\nSummary: ", Summary, "\nPrecondition: ", Precondition, "\nStatus: ", Status);
        }

        public virtual void Set() 
        {
            Id = Guid.NewGuid();

            CreationDate = DateTimeOffset.Now;

            Status = (Status)0;

            int successPriority;
            do
            {
                Console.Write("\nEnter Issue Priority. Type 1 for High, type 2 for Medium or type 3 for Low: ");
                successPriority = int.Parse(Console.ReadLine());
            } while (successPriority != 1 && successPriority != 2 && successPriority != 3);
            Priority = (Priority)successPriority - 1;

                      
                        
        }       
        
    }
}
