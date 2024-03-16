﻿namespace Wyzwanie21
{
    public class EmployeeInFile : EmployeeBase
    {

        
        string fileName;

        public override event GradeAddedToEmployeeDelegate GradeAddedToEmployee;

        public EmployeeInFile(string name, string lastname, int age, char sex) : base(name, lastname, age, sex)
        {
            
            fileName = $"{name}{lastname}.txt";
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
                    List<float> grades = sGrades.ConvertAll(float.Parse).ToList();
                    
                    foreach (var grade in grades)
                    {
                        stats.AddGrade(grade); 
                        //grades.Add(float.Parse(item));
                    }
                    
                    
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
