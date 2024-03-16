namespace Wyzwanie21
{
    public class EmployeeInFile : EmployeeBase
    {

        
        string fileName;

        public override event GradeAddedToEmployeeDelegate GradeAddedToEmployee;

        public EmployeeInFile(string name, string lastname, int age, char sex) : base(name, lastname, age, sex)
        {
            
            fileName = $"{name}{lastname}.txt";
        }

        public string GetFileGradeEmployee()
        { 
            return fileName;
        
        }
        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <=100)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.Write(grade);
                    writer.Write(" ");
                }
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
            this.AddGrade((float) grade);
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
                if (grade.Length == 1)
                {
                    this.AddGrade(char.Parse(grade));
                }
                else
                {
                    throw new Exception("This string is not float number");
                }
            }
        }

        public override Statistics GetStatistics()
        {
            Statistics stats = new Statistics();

            if (File.Exists(fileName)) 
            {
                using (var reader = File.OpenText(fileName))
                {
                    List<string> sGrades = reader.ReadLine().Split(" ").ToList();
                    sGrades.RemoveAt(sGrades.Count - 1);
                    List<float> grades = new List<float>();
                    foreach (var item in sGrades)
                    {
                         grades.Add(float.Parse(item));
                    }
                    var count = 0;
                    float average = 0;
                    stats.Min = grades[0];
                    stats.Max = grades[0];
                    foreach (var grade in grades)
                    {
                        if (grade < stats.Min)
                        { 
                            stats.Min = grade;
                        }
                        if (grade > stats.Max)
                        {
                            stats.Max = grade;
                        }
                        count++;
                        average += grade;
                    }
                    stats.Average = average/count;
                    switch (stats.Average)
                    {
                        case >= 80:
                            stats.AverageLetter = 'A';
                            break;
                        case >= 60:
                            stats.AverageLetter = 'B';
                            break;
                        case >= 40:
                            stats.AverageLetter = 'C';
                            break;
                        case >= 20:
                            stats.AverageLetter = 'D';
                            break;
                        default:
                            stats.AverageLetter = 'E';
                            break;
                    }
                    stats.Count = count;
                }
                return stats;
            }
            else
            {
                return stats;
            }
        }
    }
}
