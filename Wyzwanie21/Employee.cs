namespace Wyzwanie21
{
    public class Employee
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        List<int> Scores = new List<int>();

        public Employee(string Name, string LastName, int Age)
        {
            this.Name = Name;
            this.LastName = LastName;
            this.Age = Age;
        }

        public int Result
        {
            get
            {
                return this.Scores.Sum();
            }
        }
        public void AddScore(int Score)
        {
            this.Scores.Add(Score);
        }
    }
}
