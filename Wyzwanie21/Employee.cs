namespace Wyzwanie21
{
    public class Employee : Person
    {
        
        List<float> grades = new List<float>();

        public Employee(string name, string lastname, int age, char sex) : 
                        base(name, lastname, age, sex)
        { 

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
                if (grade.Length == 1 && grade.ToLower() !="q" )
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
