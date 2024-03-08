namespace Wyzwanie21.Test
{
    public class Tests
    {

        [Test]
        public void WhenAddedCorrectLetterGrade_ShouldTheCorrectResult()
        {
            
            var employee = new Employee("Mariusz", "Pudzianowski", 54,'M');
            employee.AddGrade('E');
            employee.AddGrade('a');
            employee.AddGrade('d');
            employee.AddGrade('b');

            var statistics = employee.GetStatistics();
            

            Assert.AreEqual(20, statistics.Min);
            Assert.AreEqual(100, statistics.Max);
            Assert.AreEqual(60, statistics.Average);
            Assert.AreEqual(4, statistics.Count);
            Assert.AreEqual('B', statistics.AverageLetter);
        }


        [Test]
        public void WhenAddedCorrectGradeUser_ShouldCorrectStatistics()
        {
            
            var employee = new Employee("Adam","Kowalski",35, 'M');
            
            employee.AddGrade(10);
            employee.AddGrade('A');
            employee.AddGrade("A");
            employee.AddGrade('E');
            employee.AddGrade(4f);
            employee.AddGrade(6f);

            var averageScore = employee.GetSummaryScore()/ 5; 
           
            var statisticEmployeeToVerified = employee.GetStatistics();
            
            Assert.AreEqual(4f, statisticEmployeeToVerified.Min);
            Assert.AreEqual(100,statisticEmployeeToVerified.Max);
            Assert.AreEqual(averageScore,statisticEmployeeToVerified.Average);
            Assert.AreEqual(5,statisticEmployeeToVerified.Count);
            
        }

        [Test]
        public void WhenAddedAllPositiveCorrectAndFailScoreUser_ShouldBeCorrectTotalPoint()
        {
            
            var employee = new Employee("Magdalena", "Jaworska", 44, 'K');
            employee.AddGrade("adam");
            employee.AddGrade(-26);
            employee.AddGrade(136);
            employee.AddGrade('F');
            employee.AddGrade(99);
            employee.AddGrade(36);
            employee.AddGrade('D');
            employee.AddGrade("D");
            employee.AddGrade('a');

            var averageScore = employee.GetSummaryScore() / 5;

            var statisticEmployeeToVerified = employee.GetStatistics();

            Assert.Positive(statisticEmployeeToVerified.Min);
            Assert.Positive(statisticEmployeeToVerified.Max);
            Assert.Positive(statisticEmployeeToVerified.Average);
            Assert.Positive(statisticEmployeeToVerified.Count);
        }

        
        
        

        [Test]
        public void WhenAddedAllScoreUser_ShouldCorrectNegativeResultAndPositiveCountGrades()
        {
            
            var employee = new Employee("Robin", "Hood", 24, 'M');
            employee.AddGrade('A');
            employee.AddGrade('b');
            employee.AddGrade(21);
            employee.AddGrade('E');
            employee.AddGrade(5);
            employee.AddGrade(-6.8f);

            var averageScore = employee.GetSummaryScore() / 5;

            var statisticEmployeeToVerified = employee.GetStatistics();

            Assert.AreEqual(5, statisticEmployeeToVerified.Min);
            Assert.AreEqual(100, statisticEmployeeToVerified.Max);
            Assert.AreEqual(averageScore, statisticEmployeeToVerified.Average);
            Assert.AreEqual('C', statisticEmployeeToVerified.AverageLetter);
            Assert.AreEqual(5, statisticEmployeeToVerified.Count);

        }

    }
}