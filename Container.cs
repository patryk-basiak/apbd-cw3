namespace Cwiczenia3;

public abstract class Container
{
    public int cargoWeight { get; set; } = 0; 
    public int totalWeight { get; set; } = 0; 
    public int height { get; set; }
    public int containerOwnMass { get; set; }
    public int depth { get; set; }
    public string serialNumber { get; set; }
    public int maxWeight { get; set; }
    private static int _index = 0;
    public int id { get; } = 0;
    public string type { get; }

    public Container(int height, int containerOwnMass, int depth, string type, int maxWeight)
    {
        this.height = height;
        this.containerOwnMass = containerOwnMass;
        this.depth = depth;
        id = _index++;
        this.type = type;
        this.totalWeight += containerOwnMass;
        this.serialNumber = "KON-" + type + "" + id;
        this.maxWeight = maxWeight;
    }

    public Container(string type)
    {
        this.height = 100;
        this.containerOwnMass = 10;
        this.depth = 10;
        id = _index++;
        this.serialNumber = "KON-" + type + "" + id;
        this.maxWeight = 100;
    }

    public virtual void ClearCargo()
    {
        cargoWeight = 0;
    }

    public virtual void AddCargo(int weight)
    {
        if (maxWeight < cargoWeight + weight)
        {
            throw new OverFillException();
        }
        cargoWeight += weight;
        totalWeight += cargoWeight;
    }

    public virtual void AddCargo(int weight, string type)
    {
        AddCargo(weight);
    }

    public override string ToString()
    {
        return
            $"{type}, waga: {totalWeight}kg, id: {id}";
    }
}