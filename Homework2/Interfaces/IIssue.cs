namespace Homework2
{
    public interface IIssue
    {
        Guid Id { get; }

        public DateTimeOffset CreationDate { get; }

        Priority Priority { get; set; }

        Status Status { get; set; }

        string Get();
        void Set();
    }
}
