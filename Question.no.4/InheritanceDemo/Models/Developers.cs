namespace RealWorldClass.Models;

class Developer : Employee
{
    public Developer(string name) : base(name)
    {
    }

    public override void Work()
    {
        Console.WriteLine($"{Name} develops software.");
    }
}