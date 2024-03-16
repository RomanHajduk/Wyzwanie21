

using static Wyzwanie21.EmployeeBase;

namespace Wyzwanie21
{
    public interface IEmployee
    {
        string Name { get; }
        string Lastname {  get; }
        int Age {  get; }
        char Sex {  get; }

        void AddGrade(float grade);
        void AddGrade(int grade);
        void AddGrade(double grade);
        void AddGrade(char grade);
        void AddGrade(string grade);
        event GradeAddedToEmployeeDelegate GradeAddedToEmployee;
        Statistics GetStatistics();
        
    }
}
