namespace ConsoleApp28
{
    internal class Person
    {
        public Person()
        {
        }

        public string FirstName { get; set; }
        public int Age { get; internal set; }
        public int Roll { get; internal set; }
        public override string ToString()
        {
            return this.FirstName + "," + this.Age + "," + this.Roll;
        }
    }
}