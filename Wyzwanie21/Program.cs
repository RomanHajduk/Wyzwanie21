using Wyzwanie21;
List<Supervisor> supervisors = new List<Supervisor>();

var supervisor1 = new Supervisor("Max", "Golonko", 32, 'M');
var supervisor2 = new Supervisor("Jarosław", "Kaczyński", 74, 'M');
var supervisor3 = new Supervisor("Mandaryna", "Wiśniewska", 40, 'K');

supervisors.AddRange(new List<Supervisor>() { supervisor1, supervisor2, supervisor3 });

Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n" +
                  "+  System Oceny Pracowników Wyższego Szczebla:Kierownicy  +\n" +
                  "+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
Console.WriteLine($"\nLiczba pracowników wyższego szczebla(kierownicy): {supervisors.Count}");

foreach (var supervisor in supervisors)
{
    
    while (true) 
    {
        
        Console.WriteLine($"Podaj kolejną ocenę kierownika numer {supervisors.IndexOf(supervisor) + 1}:  {supervisor.Name} {supervisor.Lastname} lat: {supervisor.Age} płeć: {supervisor.Sex}");
        Console.WriteLine($"Aby zakończyć ocenę kierownika numer {supervisors.IndexOf(supervisor) + 1} wciśnij q i potwierdź!");
        var grade = Console.ReadLine();
        try
        {
            
            supervisor.AddGrade(grade);
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
            Console.WriteLine($"Koniec dodawania ocen dla kierownika nr {supervisors.IndexOf(supervisor) + 1}");
            Console.ForegroundColor = ConsoleColor.White;
            break;
        }

    }
               
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\n-- Wyświetlamy statystyki dla wszystkich pracowników wyższego szczebla (kierownicy) --\n");
Console.ForegroundColor = ConsoleColor.White;

// wyświetlanie ocen
foreach (var supervisor in supervisors)
{   
    
    Console.BackgroundColor = ConsoleColor.DarkBlue;
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.Write("************************************************************************");
    Console.ForegroundColor = ConsoleColor.White;
    Console.BackgroundColor = ConsoleColor.Black;
    Console.WriteLine();
    Console.WriteLine($" Pracownik wyższego szczebla (kierownik): {supervisor.Name} {supervisor.Lastname} Lat: {supervisor.Age} Płeć {supervisor.Sex} ma następujące oceny:");
    Console.WriteLine($" Statystyki: \n" +
                      $" ocena najniższa: {supervisor.GetStatistics().Min} \n" +
                      $" ocena maksymalna:{supervisor.GetStatistics().Max} \n" +
                      $" średnia ocena kierownika: {supervisor.GetStatistics().Average:N2} \n" +
                      $" średnia ocena kierownika w skali(A-E): {supervisor.GetStatistics().AverageLetter} \n" +
                      $" ilość ocen kierownika: {supervisor.GetStatistics().Count} \n" );

}



