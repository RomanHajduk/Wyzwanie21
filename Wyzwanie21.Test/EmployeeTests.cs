namespace Wyzwanie21.Test
{
    public class Tests
    {

        [Test]
        public void WhenUsingTwoVersionMethodGetStatistics_ShouldTheSameResult()
        {
            
            var employee = new Employee("Mariusz", "Pudzianowski", 54);
            employee.AddGrade(7.16f);
            employee.AddGrade(5.3f);
            employee.AddGrade(8.3f);

            var statistics = employee.GetStatistics();
            var statistics2 = employee.GetStatisticsVersion2();

            Assert.AreEqual(statistics.Min, statistics2.Min);
            Assert.AreEqual(statistics.Max, statistics2.Max);
            Assert.AreEqual(statistics.Average, statistics2.Average);
            Assert.AreEqual(statistics.Count, statistics2.Count);
        }


        [Test]
        public void WhenAddedGradeUser_ShouldCorrectStatistics()
        {
            
            var employee = new Employee("Adam","Kowalski",35);
            
            employee.AddGrade(5);
            employee.AddGrade(6.4f);
            employee.AddGrade(1.4f);
            employee.AddGrade(2.5f);
            employee.AddGrade(6.9f);

            var averageScore = employee.GetSummaryScore()/ 5; 
           
            var statisticEmployeeToVerified = employee.GetStatistics();
            
            Assert.AreEqual(1.4f, statisticEmployeeToVerified.Min);
            Assert.AreEqual(6.9f,statisticEmployeeToVerified.Max);
            Assert.AreEqual(averageScore,statisticEmployeeToVerified.Average);
            Assert.AreEqual(5,statisticEmployeeToVerified.Count);
            
        }

        [Test]
        public void WhenAddedAllPositiveScoreUser_ShouldBePositiveTotalPoint()
        {
            
            var employee = new Employee("Magdalena", "Jaworska", 44);
            employee.AddGrade(15);
            employee.AddGrade(26);
            employee.AddGrade(16);
            employee.AddGrade(2);

            var averageScore = employee.GetSummaryScore() / 4;

            var statisticEmployeeToVerified = employee.GetStatistics();

            Assert.Positive(statisticEmployeeToVerified.Min);
            Assert.Positive(statisticEmployeeToVerified.Max);
            Assert.Positive(statisticEmployeeToVerified.Average);
            Assert.Positive(statisticEmployeeToVerified.Count);
        }

        [Test]
        public void WhenAddedNegativeAndPositiveScoreUser_ShouldCorrectTotalPoint()
        {

            var employee = new Employee("Domino", "Jachaœ", 28);
            employee.AddGrade(5);
            employee.AddGrade(12.5f);
            employee.AddGrade(-16);
            employee.AddGrade(-7);
            var averageScore = employee.GetSummaryScore() / 4;

            var statisticEmployeeToVerified = employee.GetStatistics();

            Assert.AreEqual(-16, statisticEmployeeToVerified.Min);
            Assert.AreEqual(12.5f, statisticEmployeeToVerified.Max);
            Assert.AreEqual(averageScore, statisticEmployeeToVerified.Average);
            Assert.AreEqual(4, statisticEmployeeToVerified.Count);
        }

        [Test]
        public void WhenAddedAllNegativeScoreUser_ShouldCorrectNegativeResultAndPositiveCountGrades()
        {
            
            var employee = new Employee("Robin", "Hood", 24);
            employee.AddGrade(-5);
            employee.AddGrade(-3);
            employee.AddGrade(-6);
            employee.AddGrade(-16.4f);
            employee.AddGrade(-7);
            employee.AddGrade(-6.8f);

            var averageScore = employee.GetSummaryScore() / 6;

            var statisticEmployeeToVerified = employee.GetStatistics();

            Assert.AreEqual(-16.4f, statisticEmployeeToVerified.Min);
            Assert.AreEqual(-3, statisticEmployeeToVerified.Max);
            Assert.AreEqual(averageScore, statisticEmployeeToVerified.Average);
            Assert.AreEqual(6, statisticEmployeeToVerified.Count);

        }

    }
}