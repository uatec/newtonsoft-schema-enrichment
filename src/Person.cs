namespace ConsoleApplication
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public static implicit operator Person(string text)
        {
            return new Person
            {
                Name = text,
                Age = -1
            };
        }
    }
}
