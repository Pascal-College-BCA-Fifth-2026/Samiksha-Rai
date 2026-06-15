﻿using RealWorldClass.Models;

Employee employee1 = new();

Employee employee2 = new(
    "Marlin Rai",
    50000,
    EmployeeType.FullTime);

Console.WriteLine("Default Constructor");
employee1.PrintDetails();

Console.WriteLine();

Console.WriteLine("Parameterized Constructor");
employee2.PrintDetails();