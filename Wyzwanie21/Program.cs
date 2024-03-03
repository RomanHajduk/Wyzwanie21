//deklaracja zmiennych
var numberToCheck = 343477;
char[] letters = numberToCheck.ToString().ToArray();
char[] numberToLetter = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];

// pierwszy sposób
Console.WriteLine("Liczba do sprawdzenia: " + numberToCheck);

foreach (var number in numberToLetter)
{
    var count = 0;
    foreach (var letter in letters)
    {
        if (number == letter)
            count++;
    }
    Console.WriteLine(number + "=> " + count);
}

//drugi sposób
Console.WriteLine("drugi sposób z listą");

// deklaracja listy
List<char> numbers = new List<char>();
for (int i = 0; i < 10; i++)
    numbers.Add(i.ToString()[0]);

foreach (var number in numbers)
{
    var count = 0;
    foreach (var letter in letters)
    {
        if (number == letter)
            count++;
    }
    Console.WriteLine(number + "=> " + count);
}