using RealWorldClass.Models;

Console.WriteLine("Child Class Example");
Developer developer = new Developer("Samiksha Rai");
developer.Work();

Console.WriteLine();

Console.WriteLine("Grand Child Class Example");
SeniorDeveloper seniorDeveloper = new SeniorDeveloper("Marlin Rai");
seniorDeveloper.Work();