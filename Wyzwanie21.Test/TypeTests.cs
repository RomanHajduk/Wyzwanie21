namespace Wyzwanie21.Test
{
    public class TypeTests
    {
        [Test]
        public void TestTwoObjectsAreNotEqual()
        {

            var employee1 = GetEmployee("Jarek", "Cienki", 32);
            var employee2 = GetEmployee("Marek", "Kaczanoga", 34);

            Assert.AreNotEqual(employee1, employee2);
           
        }

        [Test]
        public void TestTwoObjectsAreTheSame()
        {

            var employee1 = GetEmployee("Jarek", "Cienki", 32);
            var employee2 = GetEmployee("Marek", "Kaczanoga", 34);

            // jeśli usuniemy komentarz dla fragmentu kodu poniżej to test będzie zdany
            employee2 = employee1; 
            //lub drugi wariant 
            //employee1 = employee2;

            Assert.AreSame(employee1, employee2, "These objects aren't the same!!!");
            
        }

        [Test]
        public void TestTwoObjectsAreNotTheSame()
        {

            var employee1 = GetEmployee("Marek", "Kaczanoga", 34);
            var employee2 = GetEmployee("Marek", "Kaczanoga", 34);

            //employee1 = employee2;  <-- nie przechodzi testu, gdyż wskazuje ten sam obiekt 

            Assert.AreNotSame(employee1, employee2," These objects refer to the same object!");

        }

        [Test]  
        public void TestTwoObjectsAreEqual()
        {

            var employee1 = GetEmployee("Jarek", "Cienki", 32);
            var employee2 = GetEmployee("Marek", "Kaczanoga", 34);

            employee1 = employee2;

            Assert.AreEqual(employee1, employee2,"This objects aren't equal!!!");
           
        }

        [Test]
        public void TestTwoObjectsPropertyNameAreEqual()
        {

            var employee1 = GetEmployee("Marek", "Cienki", 32);
            var employee2 = GetEmployee("Marek", "Kaczanoga", 34);

            Assert.AreEqual(employee1.Name, employee2.Name);
        
        }
        
        [Test]
        public void TestTwoIntegersAreTheSame()
        {

            int number1 = 32;
            int number2 = 34;

            // warunek podstawiamy pod pierwszą liczbę liczbę drugą 
            number1 = number2;

            Assert.AreEqual(number1, number2," Liczby są różne!!!");

        }

        [Test]
        public void TestTwoIntegersAreTheSameVariant2()
        {

            int number1 = 34;
            int number2 = 34;

            Assert.AreEqual(number1, number2);

;       }

        [Test]
        public void TestTwoIntegersAreDifferent()
        {

            int number1 = 32;
            int number2 = 34;

            Assert.AreNotEqual(number1, number2);
            
        }

        [Test]
        public void TestTwoFloatsAreTheSame()
        {

            float number1 = 32.1f;
            float number2 = 32.1f;

            Assert.AreEqual(number1, number2, " Liczby są różne!!!");

        }

        [Test]
        public void TestTwoFloatsAreTheSameVariant2()
        {

            float number1 = 32.1f;
            float number2 = 33.2f;

            //warunek podstawiamy pod jedną liczbę drugą
            number2 = number1; 

            Assert.AreEqual(number1, number2);
            
        }

        [Test]
        public void TestTwoFloatsAreDifferent()
        {

            var number1 = 32.1f;
            var number2 = 34.1f;

            Assert.AreNotEqual(number1, number2);
            
        }

        [Test]
        public void TestTwoStringsAreTheSame()
        {

            string firstString = "Michał Anioł";
            string secondString = "Demon";

            //podstawiamy pod jeden ciąg znaków drugi
            firstString = secondString;

            Assert.AreEqual(firstString, secondString, "Ciągi znaków się różnią");

        }

        [Test]
        public void TestTwoStringsAreTheSameVariant2()
        {

            string firstString = "Demon";
            string secondString ="Demon";

            Assert.AreEqual(firstString, secondString);

        }

        [Test]
        public void TestTwoStringsAreDifferent()
        {

            string firstString = "Lucifer";
            string secondString = "Demon";

            Assert.AreNotEqual(firstString, secondString);

        }


        private Employee GetEmployee(string Name, string LastName, int Age)
        {

            return new Employee(Name, LastName, Age);
        }
    }
}
