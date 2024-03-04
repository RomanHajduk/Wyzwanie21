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
            this.grades.Add(grade);
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
            statistics.Count = this.grades.Count();
            return statistics;
        }

        public Statistics GetStatisticsVersion2()
        {

            //metody własne
            var statistics = new Statistics();
            statistics.Max = this.grades[0];
            statistics.Min = this.grades[0];
            statistics.Count = 0;
            foreach (var grade in this.grades) 
            {
                if (statistics.Max < grade)
                {
                    statistics.Max = grade;
                } 

                if (statistics.Min > grade)
                {  
                    statistics.Min = grade;
                }
                statistics.Count++;
                statistics.Average += grade;
            }
            statistics.Average /= this.grades.Count;

            return statistics;
        }


    }
}
