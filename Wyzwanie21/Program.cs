using Wyzwanie21;


EmployeeDatabase.EmployeeAddedToDatabase += EmployeeDatabase_EmployeeAddedToDatabase;
EmployeeDatabase.CheckedCorrectEmployeeData += EmployeeDatabase_CheckedCorrectEmployeeData;
EmployeeDatabase.EmployeeRemovedFromDatabase += EmployeeDatabase_EmployeeRemovedFromDatabase;


List<EmployeeInFile> employeesInDatabase;


void EmployeeDatabase_EmployeeRemovedFromDatabase(object sender, EventArgs args)
{
    Console.WriteLine("Usunięto pracownika z bazy");
}

void EmployeeDatabase_EmployeeAddedToDatabase(object sender, EventArgs args)
{
    Console.WriteLine("Dodano pracownika do bazy");
}

void EmployeeDatabase_CheckedCorrectEmployeeData(object sender, EventArgs args)
{
    Console.WriteLine("Wprowadzono poprawne dane");
}
void EmployeeInFile_GradeAddedToEmployee(object sender, EventArgs args)
{
    Console.WriteLine("Dodano ocenę pracownikowi");
}

while (true)
{
    Console.Clear();
    Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n" +
                      "+  System Oceny Pracowników Działu Marketingu Szemranego  +\n" +
                      "+                        MAIN MENU                        +\n" +
                      "+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
    Console.WriteLine("Wybierz opcje:" +
                      "\n1. Dodaj pracownika do bazy" +
                      "\n2. Lista pracowników" +
                      "\n3. Usuń pracownika z bazy" +
                      "\n4. Zakończ program");
    var choosenOption = Console.ReadKey();
    
    
    {
        switch (choosenOption.Key)
        {
            case ConsoleKey.D1:
            case ConsoleKey.NumPad1:
                Console.Clear();
                Console.WriteLine("************************************\n" + 
                                  "*   Dodawanie pracownika do bazy   *\n" +
                                  "************************************");
                
                do 
                {
                    if (Console.GetCursorPosition().Left != 0)
                    {
                        Console.SetCursorPosition(0,Console.GetCursorPosition().Top);
                    }
                    Console.Write("Podaj imię: ");
                    var name = Console.ReadLine();
                    Console.Write("Podaj nazwisko: ");
                    var lastname = Console.ReadLine();
                    Console.Write("Podaj wiek: ");
                    string age = Console.ReadLine();
                    Console.Write("Podaj płeć: ");
                    string sex = Console.ReadLine();
                    try
                    {
                        EmployeeDatabase.CheckCorrectDataEmployee(name,lastname,age,sex);
                        EmployeeDatabase.AddEmployee(name, lastname, int.Parse(age), char.Parse(sex.ToUpper()));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);   
                    }
                    Console.WriteLine("Aby zakończyć dodawanie pracowników wciśnij q, aby kontynuować wciśnij dowolny klawisz!");
                   
                } while(Console.ReadKey().Key != ConsoleKey.Q);
                Console.Clear();
                break;
            case ConsoleKey.D2:
            case ConsoleKey.NumPad2:
                while (true)
                {
                    Console.Clear();
                    try
                    {
                        employeesInDatabase = EmployeeDatabase.GetEmployees();
                        Console.WriteLine("***************************************************\n" +
                                          "*                LISTA PRACOWNIKÓW                *\n" +
                                          "***************************************************");
                        var count = 1;
                        Console.WriteLine("* Nr *    Imię    *   Nazwisko   * Wiek *   Płeć  *");
                        Console.WriteLine("***************************************************");
                        foreach (var employee in employeesInDatabase)
                        {
                            Console.Write($"* {count}");
                            Console.SetCursorPosition(5, Console.GetCursorPosition().Top);
                            Console.Write($"* {employee.Name}");
                            Console.SetCursorPosition(18, Console.GetCursorPosition().Top);
                            Console.Write($"* {employee.Lastname}");
                            Console.SetCursorPosition(33, Console.GetCursorPosition().Top);
                            Console.Write($"* {employee.Age}");
                            Console.SetCursorPosition(40, Console.GetCursorPosition().Top);
                            Console.WriteLine($"* {(employee.Sex == 'M' ? "Mężczyzna*" : "Kobieta  *")}");
                            count++;
                        }
                        Console.WriteLine("--------------------------------------\n" +
                                          "*     Menu Oceniania Pracowników     *\n" +
                                          "--------------------------------------");
                        Console.WriteLine("         1. Oceń pracownika\n" +
                                          "    2. Oceń wszystkich pracowników\n" +
                                          "  3. Wyświetl statystyki pracowników\n" +
                                          "      4. Powrót do głównego menu");   
                        Console.WriteLine("************Wybierz opcje*************");
                        var choosenOption2 = Console.ReadKey();
                        switch (choosenOption2.Key)
                        {
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
                                Console.WriteLine("Wybierz nr pracownika");
                                var input = Console.ReadLine();
                                if (input.All(Char.IsDigit))
                                {
                                    if (int.Parse(input) >= 1 && int.Parse(input) <= employeesInDatabase.Count)
                                    {
                                        Console.WriteLine($"Podaj ocenę pracownika nr {input} " +
                                                            $"{employeesInDatabase[int.Parse(input) - 1].Name} " +
                                                            $"{employeesInDatabase[int.Parse(input) - 1].Lastname} " +
                                                            $"Wiek: {employeesInDatabase[int.Parse(input) - 1].Age} " +
                                                            $"Płeć: {(employeesInDatabase[int.Parse(input) - 1].Sex == 'M' ? "Mężczyzna" : "Kobieta")} " +
                                                            $"(zakres oceny: 0-100): Aby zakończyć wciśnij q");
                                        employeesInDatabase[int.Parse(input) - 1].GradeAddedToEmployee += EmployeeInFile_GradeAddedToEmployee;

                                        while (true)
                                        {
                                            var grade = Console.ReadLine();
                                            if (grade.ToUpper() != "Q") 
                                            {
                                                try
                                                {
                                                    employeesInDatabase[int.Parse(input) - 1].AddGrade(grade);
                                                }
                                                catch (Exception ex)
                                                {
                                                    throw new Exception(ex.Message);
                                                }
                                                Console.WriteLine("Podaj kolejną ocenę (aby zakończyć wciśnij q i potwierdź)");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Zakończono ocenianie pracownika!");
                                                await Task.Delay(1500);
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception("Nie ma takiego pracownika");
                                    }
                                }
                                else
                                {
                                    throw new Exception("Podana wartość nie jest liczbą");
                                }
                                break;
                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Ocenianie każdego pracownika w bazie");
                                Console.ForegroundColor= ConsoleColor.White;
                                foreach (var item in employeesInDatabase)
                                {
                                    item.GradeAddedToEmployee += EmployeeInFile_GradeAddedToEmployee;
                                    Console.WriteLine($"Podaj ocenę dla pracownika nr {employeesInDatabase.IndexOf(item) + 1} " +
                                                      $"{item.Name} {item.Lastname} Wiek: {item.Age} Płeć: {(item.Sex == 'M' ? "Mężczyzna" : "Kobieta")} " +
                                                      $"(zakres oceny: 0-100): Aby zakończyć wciśnij q");
                                    while (true)
                                    {
                                        var grade = Console.ReadLine();
                                        if (grade.ToUpper() != "Q")
                                        {
                                            try
                                            {
                                                item.AddGrade(grade);
                                                Console.WriteLine("Podaj kolejną ocenę (aby zakończyć ocenianie wybranego pracownika wciśnij q i potwierdź");
                                            }
                                            catch (Exception ex)
                                            {
                                                throw new Exception(ex.Message);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Zakończono ocenianie pracownika nr {employeesInDatabase.IndexOf(item) + 1}!");
                                            break;
                                        }
                                    }
                                }
                                Console.WriteLine("Zakończono ocenianie wszystkich pracowników!");
                                await Task.Delay(1500);
                                break;
                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
                                foreach (var emp in employeesInDatabase)
                                {
                                    var statEmployee = emp.GetStatistics();
                                    Console.WriteLine("*********************************************************************************\n" +
                                                      $"Pracownik: {emp.Name} {emp.Lastname} Wiek {emp.Age} Płeć: {(emp.Sex == 'M' ? "Mężczyzna" : "Kobieta")}\n" +
                                                      $"*********************************************************************************\n" +
                                                      $"Statystyki: \n" +
                                                      $"Ilość ocen:      {statEmployee.Count}\n" +
                                                      $"Ocena najniższa: {statEmployee.Min}\n" +
                                                      $"Ocena najwyższa: {statEmployee.Max}\n" +
                                                      $"Średnia:         {statEmployee.Average}\n" +
                                                      $"Średnia(litera): {statEmployee.AverageLetter}\n");
                                }
                                Console.WriteLine("Powrót do menu wciśnij dowolny klawisz");
                                Console.ReadKey();
                                break;
                            case ConsoleKey.D4:
                            case ConsoleKey.NumPad4:
                                Console.SetCursorPosition(0,Console.GetCursorPosition().Top);
                                Console.WriteLine("Powrót do głównego menu.");
                                await Task.Delay(2000);
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Nie ma takiej opcji. Wybierz ponownie (opcje 1 - 4)");
                                Console.ForegroundColor = ConsoleColor.White;
                                await Task.Delay(1500);
                                break;
                        }
                        if (choosenOption2.Key == ConsoleKey.D4 || choosenOption2.Key == ConsoleKey.NumPad4)
                        {
                            break;
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować..");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey();
                    }
                }
                break;
            case ConsoleKey.D3:
            case ConsoleKey.NumPad3:
                while (true)
                {
                    Console.Clear();

                    try
                    {
                        employeesInDatabase = EmployeeDatabase.GetEmployees();
                        Console.WriteLine("***************************************************\n" +
                                          "*                LISTA PRACOWNIKÓW                *\n" +
                                          "***************************************************");
                        var count = 1;
                        Console.WriteLine("* Nr *    Imię    *   Nazwisko   * Wiek *   Płeć  *");
                        Console.WriteLine("***************************************************");
                        foreach (var employee in employeesInDatabase)
                        {
                            Console.Write($"* {count}");
                            Console.SetCursorPosition(5, Console.GetCursorPosition().Top);
                            Console.Write($"* {employee.Name}");
                            Console.SetCursorPosition(18, Console.GetCursorPosition().Top);
                            Console.Write($"* {employee.Lastname}");
                            Console.SetCursorPosition(33, Console.GetCursorPosition().Top);
                            Console.Write($"* {employee.Age}");
                            Console.SetCursorPosition(40, Console.GetCursorPosition().Top);
                            Console.WriteLine($"* {(employee.Sex == 'M' ? "Mężczyzna*" : "Kobieta  *")}");
                            count++;
                        }
                        Console.WriteLine("Podaj nr pracownika do usunięcia z bazy danych(aby zakończyć wciśnij q i potwierdź)");
                        var number = Console.ReadLine();
                        if (number.All(Char.IsDigit))
                        {
                            EmployeeDatabase.RemoveEmployee(int.Parse(number));
                        }
                        else
                        {
                            if (number.ToUpper() == "Q")
                            {
                                break;
                            }
                            else
                            {
                                throw new Exception("Podana wartość nie jest numerem");
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        if (ex.HResult == -2146233088)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ForegroundColor = ConsoleColor.White;
                            await Task.Delay(1500);
                            break;
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        await Task.Delay(1500);
                    }
                } 
                break;
            case ConsoleKey.D4:
            case ConsoleKey.NumPad4:
                Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
                Environment.Exit(0);
                break;
            default:
               Console.ForegroundColor = ConsoleColor.Red;
               Console.WriteLine("Nie ma takiej opcji. Wybierz ponownie (opcje 1 - 4)");
               Console.ForegroundColor = ConsoleColor.White;
               await Task.Delay(1500);
               break;
        }

    }
}







