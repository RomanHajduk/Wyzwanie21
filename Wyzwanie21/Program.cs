using Wyzwanie21;

var prac1 = new Employee("Mariusz", "Kolonko", 32);
var prac2 = new Employee("Ryszard", "Ochódzki", 50);
var prac3 = new Employee("Mandaryna", "Wiśniewska", 40);

prac1.AddScore(7);
prac1.AddScore(3);
prac1.AddScore(4);
prac1.AddScore(5);
prac1.AddScore(10);

prac2.AddScore(10);
prac2.AddScore(7);
prac2.AddScore(10);
prac2.AddScore(2);
prac2.AddScore(8);

prac3.AddScore(10);
prac3.AddScore(11);
prac3.AddScore(4);
prac3.AddScore(5);
prac3.AddScore(8);

List<Employee> employees = new List<Employee>();
employees.Add(prac1);
employees.Add(prac2);
employees.Add(prac3);

int Count = 0;
int maxPoint = 0;
foreach (var employee in employees)
{
    if (maxPoint < employee.Result)
    {
        maxPoint = employee.Result;
        Count = employees.IndexOf(employee);
    }
}
Console.WriteLine("Pracownik " + employees.ElementAt(Count).Name + " " + employees.ElementAt(Count).LastName + " " +
                  "z wiekiem " + employees.ElementAt(Count).Age + " lat ma największą liczbę punktów czyli: " + employees.ElementAt(Count).Result);
// drugi sposób - ten lepszy bo uwzględnia wszystkich mających taką samą największą liczbę punktów
int maxPoint2 = 0;

List<Employee> employeesWithMaxScore = new List<Employee>();
foreach (var employee in employees)
{
    if (maxPoint2 <= employee.Result)
    {
        maxPoint2 = employee.Result;
    }
}
Console.WriteLine();
Console.WriteLine("Drugi sposób, który wyświetla wszystkich mających największą sumę punktów, gdyby się tak zdarzyło!");
Console.WriteLine("Najwięcej punktów mają:");
foreach (var employee in employees)
{
    if (maxPoint2 == employee.Result)
    {
        Console.WriteLine("Pracownik " + employee.Name + " " + employee.LastName + " lat: " + employee.Age + " ma punktów: " + employee.Result);
    }

}