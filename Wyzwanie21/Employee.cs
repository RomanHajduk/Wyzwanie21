using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Wyzwanie21
{
    public class Employee
    {
        
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        List<float> grades = new List<float>();

        public Employee(string Name, string LastName, int Age)
        {

            this.Name = Name;
            this.LastName = LastName;
            this.Age = Age;

        }

        public void AddGrade(float grade)
        {
        
            if ((grade >= 0) && (grade <= 100))
            {
                this.grades.Add(grade);
            }
            else
            {
                throw new Exception("Invalid data. Grade out of range: range 0-100!!!");     
            }

        }
        public void AddGrade(int grade)
        {
          
            this.AddGrade((float)grade);

        }

        public void AddGrade(long grade)
        {
            
            this.AddGrade((float) grade);
           
        }

        public void AddGrade(char grade)
        {
            
            switch (char.ToUpper(grade))
            {

                case 'A':
                    this.grades.Add(100);
                    break;
                case 'B':
                    this.grades.Add(80);
                    break;
                case 'C':
                    this.grades.Add(60);
                    break;
                case 'D':
                    this.grades.Add(40);
                    break;
                case 'E':
                    this.grades.Add(20);
                    break;
                default:
                    throw new Exception("Wrong letter");
                                
            }

        }

        public void AddGrade(double grade)
        {
            
            if ((grade < float.MaxValue) && (grade > float.MinValue))
            {
                this.AddGrade((float) grade);
            }
            else
            {
                throw new Exception("Variable is out of range type float");    
            }

        }

        public void AddGrade(string grade)
        {
            
            if (float.TryParse(grade, out float result))
            {
                this.AddGrade(result);
            }
            else 
            {
                switch (grade.ToUpper())
                {
                    case "A":
                        this.grades.Add(100);
                        break;
                    case "B":
                        this.grades.Add(80);
                        break;
                    case "C":
                        this.grades.Add(60);
                        break;
                    case "D":
                        this.grades.Add(40);
                        break;
                    case "E":
                        this.grades.Add(20);
                        break;
                    case "Q":
                        break;
                    default:
                        throw new Exception("This string is not float number");
                
                }               
            }

        }

        public float GetSummaryScore()
        { 

            return this.grades.Sum(); 
        
        }

        public Statistics GetStatistics()
        {
            
            // metoda na skróty wykorzystująca możliwości listy
            var statistics = new Statistics();

            statistics.Max = this.grades.Max();
            statistics.Min = this.grades.Min();
            statistics.Average = this.grades.Average();
            switch (statistics.Average)
            {
                case >=80:
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
            statistics.Count = this.grades.Count();
            return statistics;

        }

    }
}
