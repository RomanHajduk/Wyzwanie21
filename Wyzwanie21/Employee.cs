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
                    Console.WriteLine("Wrong letter");
                    break;
            
            }

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
                switch (grade.ToUpper())
                {
                    case "A":
                    case "B":
                    case "C":
                    case "D":
                    case "E":
                        Console.WriteLine("Metoda1");
                        this.AddGrade(grade.ElementAt(0));
                        break;
                    case "Q":
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Error.WriteLine("This string is not float number");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
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
