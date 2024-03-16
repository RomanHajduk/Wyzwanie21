namespace Wyzwanie21
{
    public abstract class EmployeeBase : IEmployee
    {
        public delegate void GradeAddedToEmployeeDelegate(object sender, EventArgs args);
        public abstract event GradeAddedToEmployeeDelegate GradeAddedToEmployee;
        public string Name { get; private set; }

        public string Lastname { get; private set; }

        public int Age { get; private set; }

        public char Sex { get; private set; }

        public EmployeeBase(string name, string lastname, int age, char sex)
        {
            this.Name = name;   
            this.Lastname = lastname;
            this.Age = age;
            this.Sex = sex;
        }

        public abstract void AddGrade(float grade);
        public abstract void AddGrade(int grade);
        public abstract void AddGrade(double grade);
        public abstract void AddGrade(char grade);
        public abstract void AddGrade(string grade);
        public abstract Statistics GetStatistics();
        
    }
}
