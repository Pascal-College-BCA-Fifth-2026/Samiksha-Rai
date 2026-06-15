namespace RealWorldClass.Models;

sealed class SeniorDeveloper : Developer
{
    public SeniorDeveloper(string name) : base(name)
    {
    }

    public override void Work()
    {
        Console.WriteLine($"{Name} leads development projects.");
    }
}