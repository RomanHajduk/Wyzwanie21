namespace Wyzwanie21.Test
{
    public class Tests
    {

        [Test]
        public void WhenAddedThreeScoreUser_ShouldCorrectTotalPoint()
        {
            
            var employee = new Employee("Mariusz", "Pudzianowski", 54);
            employee.AddScore(6);
            employee.AddScore(5);
            employee.AddScore(8);

            var totalPointToVerified = employee.Result;

            Assert.AreEqual(19, totalPointToVerified);
        }


        [Test]
        public void WhenAddedFourScoreUser_ShouldCorrectTotalPoint()
        {
            
            var employee = new Employee("Adam","Kowalski",35);
            employee.AddScore(5);
            employee.AddScore(6);
            employee.AddScore(1);
            employee.AddScore(2);
            
            var totalPointToVerified = employee.Result;

            Assert.AreEqual(14, totalPointToVerified);
            
        }

        [Test]
        public void WhenAddedAllPositiveScoreUser_ShouldBePositiveTotalPoint()
        {
            
            var employee = new Employee("Magdalena", "Jaworska", 44);
            employee.AddScore(15);
            employee.AddScore(26);
            employee.AddScore(16);
            employee.AddScore(2);

            var positiveTotalPointToVerified = employee.Result;

            Assert.Positive(positiveTotalPointToVerified);
        }

        [Test]
        public void WhenAddedNegativeAndPositiveScoreUser_ShouldCorrectTotalPoint()
        {

            var employee = new Employee("Domino", "Jachaœ", 28);
            employee.AddScore(5);
            employee.AddScore(6);
            employee.AddScore(-16);
            employee.AddScore(-7);
            
            var totalPointToVerified = employee.Result;

            Assert.AreEqual(-12, totalPointToVerified);
        }

        [Test]
        public void WhenAddedAllNegativeScoreUser_ShouldCorrectNegativeResultAndNegativeTotalPoint()
        {
            
            var employee = new Employee("Robin", "Hood", 24);
            employee.AddScore(-5);
            employee.AddScore(-3);
            employee.AddScore(-6);
            employee.AddScore(-16);
            employee.AddScore(-7);
                      
            var negativeResultToVerified = employee.Result;

            Assert.AreEqual(-37, negativeResultToVerified);
            Assert.Negative(negativeResultToVerified);

        }

    }
}