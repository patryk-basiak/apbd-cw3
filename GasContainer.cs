namespace Cwiczenia3;

public class GasContainer : Container
    
{
    public GasContainer(int height, int containerOwnMass, int depth, int maxWeight) : base(height,
        containerOwnMass, depth, "G", maxWeight)
    {
        
    }
    public GasContainer() : base("G")
    {
        
    }
    public double pressure { get; set; }

    public void Notify()
    {
        Console.WriteLine("Hazardous situation in " + base.id + " container");
    }

    public bool Check()
    {
        throw new NotImplementedException();
    }
    public override void ClearCargo()
    {
        maxWeight = (int)(maxWeight * 0.05);
    }

    public override void AddCargo(int weight)
    {
        if (maxWeight < cargoWeight + weight)
        {
            Notify();
        };
        base.AddCargo(weight);
        
        
    }
}