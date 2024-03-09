namespace Wyzwanie21
{
    public class Supervisor : Person, IEmployee
    {
        List<float> supervisorGrades = new List<float>();
        public Supervisor(string name, string lastname, int age, char sex) : base(name, lastname, age, sex)
        {
        }

        public void AddGrade(float grade)
        {
            if ((grade >= 0) && (grade <= 100))
            {
                this.supervisorGrades.Add(grade);
            }
            else
            {
                throw new Exception("Invalid data. Grade out of range: range 0-100!!!");
            }
        }

        public void AddGrade(string grade)
        {
            switch (grade)
            {
                case "6":
                    this.AddGrade(100);
                    break;
                case "-6":
                case "6-":
                    this.AddGrade(95);
                    break;
                case "+5":
                case "5+":
                    this.AddGrade(85);
                    break;
                case "5":
                    this.AddGrade(80);
                    break;
                case "-5":
                case "5-":
                    this.AddGrade(75);
                    break;
                case "+4":
                case "4+":
                    this.AddGrade(65);
                    break;
                case "4":
                    this.AddGrade(60);
                    break;
                case "-4":
                case "4-":
                    this.AddGrade(55);
                    break;
                case "+3":
                case "3+":
                    this.AddGrade(45);
                    break;
                case "3":
                    this.AddGrade(40);
                    break;
                case "-3":
                case "3-":
                    this.AddGrade(35);
                    break;
                case "+2":
                case "2+":
                    this.AddGrade(25);
                    break;
                case "2":
                    this.AddGrade(20);
                    break;
                case "1":
                    this.AddGrade(0);
                    break;
                default:
                    if (grade.ToLower() == "q")
                    {
                        break;
                    }
                    else
                    {
                        throw new Exception("Nie ma takiej oceny!!!");
                    }
                    
            }
        }

        public Statistics GetStatistics()
        {
            // metoda na skróty wykorzystująca możliwości listy
            var statistics = new Statistics();

            statistics.Max = this.supervisorGrades.Max();
            statistics.Min = this.supervisorGrades.Min();
            statistics.Average = this.supervisorGrades.Average();
            switch (statistics.Average)
            {
                case >= 80:
                    statistics.AverageLetter = 'A';
                    break;
                case >= 60:
                    statistics.AverageLetter = 'B';
                    break;
                case >= 40:
                    statistics.AverageLetter = 'C';
                    break;
                case >= 20:
                    statistics.AverageLetter = 'D';
                    break;
                default:
                    statistics.AverageLetter = 'E';
                    break;
            }
            statistics.Count = this.supervisorGrades.Count();
            return statistics;
        }
    }
}
