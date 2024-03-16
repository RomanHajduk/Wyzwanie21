﻿namespace Wyzwanie21
{
    public class Supervisor : Person, IEmployee
    {

        List<float> supervisorGrades = new List<float>();
        public Supervisor(string name, string lastname, int age, char sex) : base(name, lastname, age, sex)
        {
        }

        public event EmployeeBase.GradeAddedToEmployeeDelegate GradeAddedToEmployee;

        public void AddGrade(float grade)
        {
            if ((grade >= 0) && (grade <= 100))
            {
                this.supervisorGrades.Add(grade);
                if (GradeAddedToEmployee  != null)
                {
                    GradeAddedToEmployee(this, EventArgs.Empty);
                }
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

        public void AddGrade(int grade)
        {
            this.AddGrade((float) grade);
        }

        public void AddGrade(double grade)
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

        public void AddGrade(char grade)
        {
            throw new NotImplementedException();
        }

        public Statistics GetStatistics()
        {
            // metoda na skróty wykorzystująca możliwości listy
            var statistics = new Statistics();
            foreach (var grade in supervisorGrades) 
            {
                statistics.AddGrade(grade);
            }

            return statistics;
        }
    }
}
