namespace RealWorldClass.Models;

class Employee
{
    public string Name { get; set; }

    public double MonthlySalary { get; set; }

    public EmployeeType Type { get; set; }

    public double AnnualSalary
    {
        get
        {
            return MonthlySalary * 12;
        }
    }

    public Employee()
{
    Name = "Samiksha Rai";
    MonthlySalary = 0;
    Type = EmployeeType.Intern;
}

    public Employee(
        string name,
        double monthlySalary,
        EmployeeType type)
    {
        Name = name;
        MonthlySalary = monthlySalary;
        Type = type;
    }

    public void PrintDetails()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Monthly Salary: {MonthlySalary}");
        Console.WriteLine($"Employee Type: {Type}");
        Console.WriteLine($"Annual Salary: {AnnualSalary}");
    }
}