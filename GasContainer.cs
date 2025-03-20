namespace Cwiczenia3;

public class GasContainer(int height, int containerOwnMass, int depth, int maxWeight)
    : Container(height, containerOwnMass, depth, "G", maxWeight), IHazardNotifier
{
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
        if (maxWeight >= cargoWeight + weight) return;
        Notify();
        cargoWeight += weight;
    }
}