namespace Wyzwanie21
{
    static public class EmployeeDatabase
    {
        public delegate void EmployeeAddedToDatabaseDelegate(object sender, EventArgs args);
        public delegate void EmployeeRemovedFromDatabaseDelegate(object sender, EventArgs args);
        public delegate void CheckedCorrectEmployeeDataDelegate(object sender, EventArgs args);

        public static event EmployeeAddedToDatabaseDelegate EmployeeAddedToDatabase;
        public static event EmployeeRemovedFromDatabaseDelegate EmployeeRemovedFromDatabase;
        public static event CheckedCorrectEmployeeDataDelegate CheckedCorrectEmployeeData;

        const string databaseEmployees = "Employees.txt";

        public static void CheckCorrectDataEmployee(string name, string lastname, string stringAge, string sex)
        {
            bool correctName, correctLastname, correctAge, correctSex;
            
            if (stringAge.All(Char.IsDigit))
            {
                correctAge = int.Parse(stringAge) >= 18 && int.Parse(stringAge) <= 65 ? true : false;
            }
            else
            {
                throw new Exception("Wartość podana jako wiek to nie jest liczba (przedział 18-65)");
            }
            correctName = name.All(Char.IsLetter);
            correctLastname = lastname.All(Char.IsLetter);
            
            correctSex = Char.Parse(sex.ToUpper()) == 'M' || Char.Parse(sex.ToUpper()) == 'K'? true : false;  
            
            // A tu rzucamy odpowiedni wyjątek albo uruchamiamy zdarzenie
            if (correctName && correctLastname & correctAge & correctSex)
            { 
                if (CheckedCorrectEmployeeData != null)
                {
                    CheckedCorrectEmployeeData(null,EventArgs.Empty);
                }

            }
            if (!correctName && correctLastname & correctAge & correctSex) 
            {
                throw new Exception("Nieprawidłowe imię");
            }
            if (correctName && !correctLastname & correctAge & correctSex)
            {
                throw new Exception("Nieprawidłowe nazwisko");
            }
            if (!correctName && !correctLastname & correctAge & correctSex)
            {
                throw new Exception("Nieprawidłowe imię i nazwisko");
            }
            if (correctName && correctLastname & !correctAge & correctSex)
            {
                throw new Exception("Nieprawidłowy wiek (przedział 18-65)");
            }
            if (!correctName && correctLastname & !correctAge & correctSex)
            {
                throw new Exception("Nieprawidłowe imię i nieprawidłowy wiek (przedział 18-65)");
            }
            if (correctName && !correctLastname & !correctAge & correctSex)
            {
                throw new Exception("Nieprawidłowe nazwisko i nieprawidłowy wiek (przedział 18-65)");
            }
            if (!correctName && !correctLastname & !correctAge & correctSex)
            {
                throw new Exception("Nieprawidłowe imię i nazwisko oraz nieprawidłowy wiek (przedział 18-65)");
            }
            if (correctName && correctLastname & correctAge & !correctSex)
            {
                throw new Exception("Nieprawidłowa płeć (K - Kobieta M - Mężczyzna)");
            }
            if (!correctName && correctLastname & correctAge & !correctSex)
            {
                throw new Exception("Nieprawidłowe imię i nieprawidłowa płeć (K - Kobieta M - Mężczyzna)");
            }
            if (correctName && !correctLastname & correctAge & !correctSex)
            {
                throw new Exception("Nieprawidłowe nazwisko i nieprawidłowa płeć (K - Kobieta M - Mężczyzna)");
            }
            if (!correctName && !correctLastname & correctAge & !correctSex)
            {
                throw new Exception("Nieprawidłowe imię i nazwisko oraz nieprawidłowa płeć (K - Kobieta M - Mężczyzna)");
            }
            if (correctName && correctLastname & !correctAge & !correctSex)
            {
                throw new Exception("Nieprawidłowy wiek (przedział 18-65) i nieprawidłowa płeć (K - Kobieta M - Mężczyzna)");
            }
            if (!correctName && correctLastname & !correctAge & !correctSex)
            {
                throw new Exception("Nieprawidłowe imię, nieprawidłowy wiek (przedział 18-65) oraz nieprawidłowa płeć (K - Kobieta M - Mężczyzna)");
            }
            if (correctName && !correctLastname & !correctAge & !correctSex)
            {
                throw new Exception("Nieprawidłowe nazwisko, nieprawidłowy wiek (przedział 18-65) oraz nieprawidłowa płeć (K - Kobieta M - Mężczyzna)");
            }
            if (!correctName && !correctLastname & !correctAge & !correctSex)
            {
                throw new Exception("Nieprawidłowe imię i nazwisko, nieprawidłowy wiek (przedział 18-65) oraz nieprawidłowa płeć (K - Kobieta M - Mężczyzna)");
            }

        }

        public static void AddEmployee(string name, string lastname, int age, char sex)
        {
            
            var employee = new EmployeeInFile(name, lastname, age, sex);
            using (var writer = File.AppendText(databaseEmployees))
            {

                writer.WriteLine(employee.Name + " " +
                                    employee.Lastname + " " +
                                    employee.Age + " " +
                                    employee.Sex);
            }
            if (EmployeeAddedToDatabase != null)
            {
                EmployeeAddedToDatabase(null, EventArgs.Empty);
            }
                  
        }
        
       
        public static List<EmployeeInFile> GetEmployees() 
        {
            if (File.Exists(databaseEmployees))
            {
                List<EmployeeInFile> employees = new List<EmployeeInFile>();
                using (var reader = File.OpenText(databaseEmployees))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        string[] dataEmployee = line.Split(" ", StringSplitOptions.None);
                        employees.Add(new EmployeeInFile(dataEmployee[0], dataEmployee[1], int.Parse(dataEmployee[2]), dataEmployee[3].ElementAt(0)));
                        line = reader.ReadLine();
                    }
                }
                return employees;
            }
            else
            {
                throw new Exception("Plik z bazą pracowników nie istnieje!");
            }
        }

        public static void RemoveEmployee(int number)
        {
            if (File.Exists(databaseEmployees))
            {
                List<EmployeeInFile> employees = GetEmployees();
                if (number > employees.Count) 
                {
                    throw new Exception("Nie ma takiego nr pracownika");
                }
                else
                {   
                    employees.RemoveAt(number-1);
                    using (var writer = File.CreateText(databaseEmployees))
                    {
                        foreach (var employee in employees)
                        {
                            writer.WriteLine(employee.Name + " " +
                                             employee.Lastname + " " +
                                             employee.Age + " " +
                                             employee.Sex);

                        }
                    }
                    if (EmployeeRemovedFromDatabase != null)
                    {
                        EmployeeRemovedFromDatabase(null, EventArgs.Empty);
                    }
                    if (employees.Count == 0)
                    {
                        File.Delete(databaseEmployees);
                        throw new Exception("Usunięto ostatniego pracownika z bazy. Plik zostaje usunięty.");
                    }
                }
            }
            else
            {
                throw new Exception("Baza pracowników nie istnieje! Pierwsze uruchomienie programu");
            }
        }

    }
}
