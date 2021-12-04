namespace Homework2
{
    // класс еще в работе
    public class TestCase
    {
        private Guid id = Guid.NewGuid();
        public Guid Id { get => id; }

        private DateTimeOffset creationDate = DateTimeOffset.Now;
        public DateTimeOffset CreationDate { get => creationDate; }

        public EnumPriority EnumPriority { get; set; }
        public string Summary { get; set; }
        public string Precondition { get; set; }
        public EnumStatus EnumStatus { get; set; }

        //коллекция Step

        public void FillTestCase() { }
        public void ShowTestCase() { }
    }
}
