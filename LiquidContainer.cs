namespace Cwiczenia3;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool hazard { get; set; } = false;
    public LiquidContainer(int height, int containerOwnMass, int depth, int maxWeight, bool hazard) : base(height, containerOwnMass, depth, "L", maxWeight)
    {
        this.hazard = hazard;
    }

    public void Notify()
    {
        Console.WriteLine("Hazardous situation in " + base.id + " container");
    }

    public bool Check()
    {
        throw new NotImplementedException();
    }

    public override void AddCargo(int weight)
    {
        if (hazard)
        {
            if (maxWeight * 0.5 > cargoWeight + weight)
            {
                cargoWeight += weight;
            }
            else
            {
                Notify();
            }
        }
        else
        {
            if (maxWeight * 0.9 > cargoWeight + weight)
            {
                cargoWeight += weight;
            }
            else
            {
                Notify();
            }
        }
        
    }
}