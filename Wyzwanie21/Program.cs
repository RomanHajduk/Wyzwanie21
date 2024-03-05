using Wyzwanie21;
List<Employee> employees = new List<Employee>();

var employee1 = new Employee("Max", "Golonko", 32);
var employee2 = new Employee("Jarosław", "Kaczyński", 74);
var employee3 = new Employee("Mandaryna", "Wiśniewska", 40);

employees.AddRange(new List<Employee>() { employee1, employee2, employee3 });

// oceny dla pracowników
employee1.AddGrade("3,2");
employee1.AddGrade("BlaBlabla Moja Ocena");
employee1.AddGrade(3.25F);
employee1.AddGrade(3.5678e44D);  
employee1.AddGrade(7.5F);
employee1.AddGrade(300);
employee1.AddGrade(30000000000000000);

employee2.AddGrade(1.5D);
employee2.AddGrade(5);
employee2.AddGrade(9.5F);
employee2.AddGrade(12L);
employee2.AddGrade(13L);

employee3.AddGrade(2.6f);
employee3.AddGrade(4.5f);
employee3.AddGrade(7.5f);

// wyświetlanie ocen
foreach (var employee in employees)
{   
    
    Console.BackgroundColor = ConsoleColor.Green;
    Console.WriteLine("Calling method GetStatistics - version with loop for:");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.WriteLine();
    Console.WriteLine($" Pracownik : {employee.Name} {employee.LastName} Lat: {employee.Age} ma następujące oceny:");
    Console.WriteLine($" Statystyki: \n" +
                      $" ocena najniższa: {employee.GetStatisticsFor().Min} \n" +
                      $" ocena maksymalna:{employee.GetStatisticsFor().Max} \n" +
                      $" średnia ocena pracownika: {employee.GetStatisticsFor().Average:N2} \n" +
                      $" ilość ocen pracownika: {employee.GetStatisticsFor().Count} \n" );

    Console.BackgroundColor = ConsoleColor.Green;
    Console.WriteLine("Calling method GetStatistics - version with loop while:");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.WriteLine();
    Console.WriteLine($" Pracownik : {employee.Name} {employee.LastName} Lat: {employee.Age} ma następujące oceny:");
    Console.WriteLine($" Statystyki: \n" +
                      $" ocena najniższa: {employee.GetStatisticsWhile().Min} \n" +
                      $" ocena maksymalna:{employee.GetStatisticsWhile().Max} \n" +
                      $" średnia ocena pracownika: {employee.GetStatisticsWhile().Average:N2} \n" +
                      $" ilość ocen pracownika: {employee.GetStatisticsWhile().Count} \n");

    Console.BackgroundColor = ConsoleColor.Green;
    Console.WriteLine("Calling method GetStatistics - version with loop do-while:");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.WriteLine();
    Console.WriteLine($" Pracownik : {employee.Name} {employee.LastName} Lat: {employee.Age} ma następujące oceny:");
    Console.WriteLine($" Statystyki: \n" +
                      $" ocena najniższa: {employee.GetStatisticsDoWhile().Min} \n" +
                      $" ocena maksymalna:{employee.GetStatisticsDoWhile().Max} \n" +
                      $" średnia ocena pracownika: {employee.GetStatisticsDoWhile().Average:N2} \n" +
                      $" ilość ocen pracownika: {employee.GetStatisticsDoWhile().Count} \n");

    Console.BackgroundColor = ConsoleColor.Green;
    Console.WriteLine("Calling method GetStatistics - version with loop foreach:");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.WriteLine();
    Console.WriteLine($" Pracownik : {employee.Name} {employee.LastName} Lat: {employee.Age} ma następujące oceny:");
    Console.WriteLine($" Statystyki: \n" +
                      $" ocena najniższa: {employee.GetStatisticsForEach().Min} \n" +
                      $" ocena maksymalna:{employee.GetStatisticsForEach().Max} \n" +
                      $" średnia ocena pracownika: {employee.GetStatisticsForEach().Average:N2} \n" +
                      $" ilość ocen pracownika: {employee.GetStatisticsForEach().Count} \n");

}



