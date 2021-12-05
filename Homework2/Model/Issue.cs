namespace Homework2
{
    public abstract class Issue
    {
        private Guid id;
        public Guid Id { get => id; }

        private DateTimeOffset creationDate;
        public DateTimeOffset CreationDate { get => creationDate; }

        public EnumPriority.Priority EnumPriority { get; set; }
        public string Summary { get; set; }
        public string? Precondition { get; set; }
        public EnumStatus.Status EnumStatus { get; set; }

        public Issue(Guid id, DateTimeOffset creationDate, EnumPriority.Priority enumPriority, string summary, string? precondition, EnumStatus.Status enumStatus)
        {
            this.id = id;
            this.creationDate = creationDate;
            this.EnumPriority = enumPriority;
            this.Summary = summary;
            this.Precondition = precondition;
            this.EnumStatus = enumStatus;
        }
    }
}
