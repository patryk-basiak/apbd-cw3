namespace Cwiczenia3;

public class RefrigeratedContainer : Container, IHazardNotifier
{
    public double temperature { get; }

    public Dictionary<string, double> cargo = new Dictionary<string, double>()
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
        { "Eghs", 19 },
    };
    public RefrigeratedContainer(int height, int containerOwnMass, int depth, int maxWeight, double temperature) : base(height, containerOwnMass, depth, "C", maxWeight)
    {
        this.temperature = temperature;
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
        if (cargo.TryGetValue(type, out var value))
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
}