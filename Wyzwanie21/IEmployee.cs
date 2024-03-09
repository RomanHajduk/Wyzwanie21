

namespace Wyzwanie21
{
    public interface IEmployee
    {
        string Name { get; }
        string Lastname {  get; }
        int Age {  get; }
        char Sex {  get; }

        void AddGrade(float grade);
        void AddGrade(string grade);
        Statistics GetStatistics();

    }
}
