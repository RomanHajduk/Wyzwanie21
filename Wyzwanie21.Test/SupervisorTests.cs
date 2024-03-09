using NUnit.Framework.Constraints;

namespace Wyzwanie21.Test
{
    public class SupervisorTests
    {
        [Test]
        public void WhenAddedCorrectAndIncorrectNumberGrade_ShouldTheCorrectResult()
        {

            var supervisor = new Supervisor("Mariusz", "Pudzianowski", 54, 'M');
            supervisor.AddGrade("6");
            supervisor.AddGrade("-3");
            supervisor.AddGrade(15f);
            supervisor.AddGrade(6f);

            var statistics = supervisor.GetStatistics();

            Assert.AreEqual(6f, statistics.Min);
            Assert.AreEqual(100, statistics.Max);
            Assert.AreEqual(39, statistics.Average);
            Assert.AreEqual(4, statistics.Count);
            Assert.AreEqual('D', statistics.AverageLetter);
        }

        [Test]
        public void WhenAddedAllCorrectSchoolNumberGrade_ShouldTheCorrectResult()
        {

            var supervisor = new Supervisor("Robin", "Hood", 22, 'M');
            supervisor.AddGrade("6");
            supervisor.AddGrade("-5");
            supervisor.AddGrade("3+");
            supervisor.AddGrade("1");
            supervisor.AddGrade("2");

            var statistics = supervisor.GetStatistics();

            Assert.AreEqual(0, statistics.Min);
            Assert.AreEqual(100, statistics.Max);
            Assert.AreEqual(48, statistics.Average);
            Assert.AreEqual(5, statistics.Count);
            Assert.AreEqual('C', statistics.AverageLetter);
        }

        [Test]
        public void WhenAddedWrongGradeOrWrongLetter_ShouldThrowException()
        {
            var supervisor = new Supervisor("Lady", "Zgaga", 24, 'K');

            Assert.Throws<Exception>(() => supervisor.AddGrade("z"));
            Assert.Throws<Exception>(() => supervisor.AddGrade("7"));
        }
        
        [Test]
        public void WhenAddedLetterQ_ShouldNotThrowException()
        {
            var supervisor = new Supervisor("Lady", "Zgaga", 24, 'K');

            Assert.DoesNotThrow(() => supervisor.AddGrade("q"));

        }

    }



}
