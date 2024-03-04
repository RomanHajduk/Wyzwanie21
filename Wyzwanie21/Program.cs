using Wyzwanie21;
List<Employee> employees = new List<Employee>();

var employee1 = new Employee("Max", "Golonko", 32);
var employee2 = new Employee("Jarosław", "Kaczyński", 74);
var employee3 = new Employee("Mandaryna", "Wiśniewska", 40);

employees.AddRange(new List<Employee>() { employee1, employee2, employee3 });

// oceny dla pracowników
employee1.AddGrade(2);
employee1.AddGrade(3);
employee1.AddGrade(7.5f);

employee2.AddGrade(1.5f);
employee2.AddGrade(5);
employee2.AddGrade(9.5f);

employee3.AddGrade(2.6f);
employee3.AddGrade(4.5f);
employee3.AddGrade(7.5f);

// wyświetlanie ocen
foreach (var employee in employees)
{
    Console.WriteLine($" Pracownik : {employee.Name} {employee.LastName} Lat: {employee.Age} ma następujące oceny:");
    Console.WriteLine($" Statystyki: \n" +
                      $" ocena najniższa: {employee.GetStatistics().Min} \n" +
                      $" ocena maksymalna:{employee.GetStatistics().Max} \n" +
                      $" średnia ocena pracownika: {employee.GetStatistics().Average:N2} \n" +
                      $" ilość ocen pracownika: {employee.GetStatistics().Count} \n\n" );

}




