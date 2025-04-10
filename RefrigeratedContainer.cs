﻿namespace Cwiczenia3;

public class RefrigeratedContainer : Container, IHazardNotifier
{
    public double temperature { get; }

    public readonly Dictionary<string, double> Cargo = new Dictionary<string, double>()
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Meat", -15 },
        { "Ice cream", -18 },
        { "Frozen pizza", -30 },
        { "Cheese", 7.2 },
        { "Sausages", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19 },
    };
    public RefrigeratedContainer(int height, int containerOwnMass, int depth, int maxWeight, double temperature) : base(height, containerOwnMass, depth, "C", maxWeight)
    {
        this.temperature = temperature;
    }

    public RefrigeratedContainer() : base("C")
    {
        this.temperature = 0;
    }

    public void Notify()
    {
        Console.WriteLine("Hazardous situation in " + base.id + " container");
    }

    public bool Check()
    {
        throw new NotImplementedException();
    }

    public override void AddCargo(int weight, string type)
    {
        if (Cargo.TryGetValue(type, out var value))
        {
            if (Math.Abs(temperature - value) < 1e-15)
            {
                base.AddCargo(weight);
            }
            else
            {
                Notify();
            }

        }
        else
        {
            Notify();
        }
    }

    public override void AddCargo(int weight)
    {
        Console.WriteLine("Can't add cargo that way, provide type");
    }
}
