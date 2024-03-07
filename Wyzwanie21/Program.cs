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
        try
        {
            
            employee.AddGrade(grade);
            Console.ForegroundColor = ConsoleColor.Green;
            if (grade.ToLower() != "q")
            {
                Console.WriteLine("Wprowadzono poprawne dane!");
            }         

        }
        catch (Exception ex)
        {
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write(ex.Message);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.WriteLine("Wprowadzono błędne dane!");
          

        }
        finally 
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        if (grade.ToLower() == "q")
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Koniec dodawania ocen dla pracownika nr {employees.IndexOf(employee) + 1}");
            Console.ForegroundColor = ConsoleColor.White;
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



