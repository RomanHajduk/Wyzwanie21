using Wyzwanie21;
List<Employee> employees = new List<Employee>();

var employee1 = new Employee("Max", "Golonko", 32);
var employee2 = new Employee("Jarosław", "Kaczyński", 74);
var employee3 = new Employee("Mandaryna", "Wiśniewska", 40);

employees.AddRange(new List<Employee>() { employee1, employee2, employee3 });

Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++\n" +
                  "+  System Oceny Pracowników Działu Marketingu:  +\n" +
                  "+++++++++++++++++++++++++++++++++++++++++++++++++");
Console.WriteLine($"\nLiczba pracowników: {employees.Count}");

foreach (var employee in employees)
{
    
    while (true) 
    {
        
        Console.WriteLine($"Podaj kolejną ocenę pracownika numer {employees.IndexOf(employee) + 1}:  {employee.Name} {employee.LastName} lat: {employee.Age}");
        Console.WriteLine($"Aby zakończyć ocenę pracownika numer {employees.IndexOf(employee) + 1} wciśnij q i potwierdź!");
        var grade = Console.ReadLine();
        
        switch (grade.ToUpper())
        {
            case "A":
            case "B":
            case "C":
            case "D":
            case "E":
                Console.WriteLine("Metoda1");
                employee.AddGrade(grade[0]);
                break;
           default:
                Console.WriteLine("Metoda2");
                employee.AddGrade(grade);
                break;
        }
        if (grade.ToLower() == "q")
        {
            break;
        }

    }
               
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\n-- Wyświetlamy statystyki dla wszystkich pracowników marketingu --\n");
Console.ForegroundColor = ConsoleColor.White;

// wyświetlanie ocen
foreach (var employee in employees)
{   
    
    Console.BackgroundColor = ConsoleColor.DarkBlue;
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.Write("************************************************************************");
    Console.ForegroundColor = ConsoleColor.White;
    Console.BackgroundColor = ConsoleColor.Black;
    Console.WriteLine();
    Console.WriteLine($" Pracownik : {employee.Name} {employee.LastName} Lat: {employee.Age} ma następujące oceny:");
    Console.WriteLine($" Statystyki: \n" +
                      $" ocena najniższa: {employee.GetStatistics().Min} \n" +
                      $" ocena maksymalna:{employee.GetStatistics().Max} \n" +
                      $" średnia ocena pracownika: {employee.GetStatistics().Average:N2} \n" +
                      $" średnia ocena pracownika w skali(A-E): {employee.GetStatistics().AverageLetter} \n" +
                      $" ilość ocen pracownika: {employee.GetStatistics().Count} \n" );




}



