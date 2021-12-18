namespace Homework3
{
    public interface IIssue
    {
        Guid Id { get; }

        public DateTimeOffset CreationDate { get; }

        Priority Priority { get; set; }

        string Summary { get; set; }

        string? Precondition { get; set; }

        Status Status { get; set; }

        string Get();
        void Set();
    }
}
