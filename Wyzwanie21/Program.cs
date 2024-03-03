
// deklaracja imienia
var name = "Ewa";
// zmienna logiczna, prawda jeśli jest kobietą, false jeśli jest mężczyzną 
var isWoman = false;
//zmienna przechowująca wiek
var age = 18;

if (isWoman && (age < 30))
    Console.WriteLine("Kobieta poniżej 30 lat");
else if (name == "Ewa" && age == 30)
    Console.WriteLine("Ewa, lat 30");

else if (!isWoman && age < 18)
    Console.WriteLine("Niepełnoletni mężczyzna");
else 
    Console.WriteLine("nie pasuje do podanych kryteriów");
