namespace Wyzwanie21.Test
{
    public class Tests
    {

        [Test]
        public void WhenAddedCorrectLetterGrade_ShouldTheCorrectResult()
        {
            
            var employee = new EmployeeInMemory("Mariusz", "Pudzianowski", 54,'M');
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
            
            var employee = new EmployeeInMemory("Adam","Kowalski",35, 'M');
            
            employee.AddGrade(10);
            employee.AddGrade('A');
            employee.AddGrade("A");
            employee.AddGrade('E');
            employee.AddGrade(4f);
            employee.AddGrade(6f);

            var averageScore = employee.GetSummaryScore()/ 6; 
           
            var statisticEmployeeToVerified = employee.GetStatistics();
            
            Assert.AreEqual(4f, statisticEmployeeToVerified.Min);
            Assert.AreEqual(100,statisticEmployeeToVerified.Max);
            Assert.AreEqual(averageScore,statisticEmployeeToVerified.Average);
            Assert.AreEqual(6,statisticEmployeeToVerified.Count);
            
        }

        [Test]
        public void WhenAddedAllIncorrectGrade_StatisticsWillBeZero()
        {
            var employee = new EmployeeInMemory("Robin", "Hood", 24, 'M');
            
            Assert.Throws<InvalidOperationException>(()=> employee.GetStatistics());
            
                       
        }

        
        
        

        [Test]
        public void WhenAddedIncorrectGrade_ShouldThrowException()
        {
            
            var employee = new EmployeeInMemory("Robin", "Hood", 24, 'M');
            

            Assert.Throws<Exception>(() => employee.AddGrade(-6.8f));

        }

    }
}