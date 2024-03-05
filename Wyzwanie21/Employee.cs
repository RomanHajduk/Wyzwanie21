using System.Diagnostics;

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
        
            if ((grade > 0) && (grade < 100))
            {
                this.grades.Add(grade);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid data. Grade out of range: range 0-100!!!");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
        public void AddGrade(int grade)
        {
            //a jednak napisałem pomimo komentarza poniżej 
            this.AddGrade((float)grade);

        }

        public void AddGrade(long grade)
        {
            
            //w tym wypadku wystarczy tylko rzutowanie na float zakres typu float jest większy niż zakres typu long
            //nie robię tej metody dla typu int, bo ogólnie nie ma sensu tworzyć tej metody zarówno dla longa jak i inta, gdyż 
            //zakres dla pojedynczej oceny wynosi od 0 do 100 - tu wystarczy typ byte. By sprawdzić czy to działa należy wyrzucić warunek ocena nie większa niż 100
            //i wtedy można napisać dwie metody dla typu int i typu long. Bo chodzi wyłącznie o zakres maksymalnej liczby dla danego typu 
            this.AddGrade((float) grade);
           
        }


        // tutaj warunek, aby zmieścić zmienną double w zmiennej typu float trzeba sprawdzić czy wprowadzana zmienna double nie przekracza zakresu dla zmiennej typu float
        // jeśli tak się zdarzy wyrzuca komunikat o przekroczeniu zakresu   
        public void AddGrade(double grade)
        {
            if ((grade < float.MaxValue) && (grade > float.MinValue))
            {
                this.AddGrade((float) grade);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Variable is out of range type float");
                Console.ForegroundColor = ConsoleColor.White;
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine("This string is not float number");
                Console.ForegroundColor = ConsoleColor.White;
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
            statistics.Count = this.grades.Count();
            return statistics;

        }

        public Statistics GetStatisticsFor()
        {

            var statistics = new Statistics();

            statistics.Max = this.grades[0];
            statistics.Min = this.grades[0];
            statistics.Average = 0;
            statistics.Count = 0;

            for (int index = 0; index < this.grades.Count; index++)
            {
                
                if (statistics.Min > grades[index])
                {
                    statistics.Min = grades[index];
                }
                if (statistics.Max < grades[index])
                {
                    statistics.Max = grades[index];
                }
                statistics.Count++;
                statistics.Average += grades[index];

            }

            statistics.Average /= statistics.Count;
            return statistics;

        }

        public Statistics GetStatisticsWhile()
        {

            var statistics = new Statistics();
            
            statistics.Max = this.grades[0];
            statistics.Min = this.grades[0];
            statistics.Average = 0;
            statistics.Count = 0;
            
            var index = 0;  
            
            while (index < this.grades.Count) 
            {
            
                if (statistics.Min > this.grades[index])
                {
                    statistics.Min = this.grades[index];
                }
                if (statistics.Max < this.grades[index])
                {
                    statistics.Max = this.grades[index];
                }
                statistics.Count++;
                statistics.Average += this.grades[index];
                index++;
            }

            statistics.Average /= statistics.Count;
            return statistics;

        }

        public Statistics GetStatisticsDoWhile()
        {

            var statistics = new Statistics();
            
            statistics.Max = this.grades[0];
            statistics.Min = this.grades[0];
            statistics.Average = 0;
            statistics.Count = 0;

            var index = 0;

            do
            {
                
                if (statistics.Min > grades[index])
                {
                    statistics.Min = grades[index];
                }
                if (statistics.Max < grades[index])
                {
                    statistics.Max = grades[index];
                }
                
                statistics.Count++;
                statistics.Average += grades[index];
                index++;

            } while (index < this.grades.Count);

            statistics.Average /= statistics.Count;
            return statistics;
        }

        public Statistics GetStatisticsForEach()
        {

            //metody własne
            var statistics = new Statistics();
            
            statistics.Max = this.grades[0];
            statistics.Min = this.grades[0];
            statistics.Average = 0;
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
            
            statistics.Average /= statistics.Count;
            return statistics;

        }

    }
}
