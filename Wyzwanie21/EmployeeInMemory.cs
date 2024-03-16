namespace Wyzwanie21
{
    public class EmployeeInMemory : EmployeeBase
    {
        List<float> grades = new List<float>();

        public override event GradeAddedToEmployeeDelegate GradeAddedToEmployee;

        public EmployeeInMemory(string name, string lastname, int age, char sex) : base(name, lastname, age, sex)
        {
        }

        public override void AddGrade(float grade)
        {
            if ((grade >= 0) && (grade <= 100))
            {
                this.grades.Add(grade);
                if (GradeAddedToEmployee != null) 
                { 
                    GradeAddedToEmployee(this, EventArgs.Empty);
                }
            }
            else
            {
                throw new Exception("Invalid data. Grade out of range: range 0-100!!!");
            }
        }

        public override void AddGrade(int grade)
        {
            this.AddGrade((float)grade);
        }

        public override void AddGrade(double grade)
        {
            if ((grade < float.MaxValue) && (grade > float.MinValue))
            {
                this.AddGrade((float)grade);
            }
            else
            {
                throw new Exception("Variable is out of range type float");
            }
        }

        public override void AddGrade(char grade)
        {
            switch (char.ToUpper(grade))
            {

                case 'A':
                    this.AddGrade(100f);
                    break;
                case 'B':
                    this.AddGrade(80f);
                    break;
                case 'C':
                    this.AddGrade(60f);
                    break;
                case 'D':
                    this.AddGrade(40f);
                    break;
                case 'E':
                    this.AddGrade(20f);
                    break;
                default:
                    throw new Exception("Wrong letter");

            }
        }

        public override void AddGrade(string grade)
        {
            if (float.TryParse(grade, out float result))
            {
                this.AddGrade(result);
            }
            else
            {
                if (grade.Length == 1 && grade.ToLower() != "q")
                {
                    this.AddGrade(char.Parse(grade));
                }
                else
                {
                    if (grade.ToLower() == "q")
                    {

                    }
                    else
                    {
                        throw new Exception("This string is not float number");
                    }
                }
            }
        }

        public float GetSummaryScore()
        {
            var summary = 0f;
            foreach (var grade in grades)
            {
                summary += grade;
            }
            return summary;
        
        }
        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var grade in grades) 
            { 
                statistics.AddGrade(grade);
            }
            return statistics;
        }
    }
}
