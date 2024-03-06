using konsola;

Console.WriteLine("Hello, World!");
Cow mycow = new Cow(2, "John", Animal.gender.male, 22.45, 5);
Console.WriteLine(mycow.value());
mycow.Obtained_milk = 10;
Console.WriteLine(mycow.Obtained_milk);
Console.ReadLine();
