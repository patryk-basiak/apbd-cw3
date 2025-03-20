namespace Cwiczenia3;

public abstract class Container
{
    public int cargoWeight { get; set; } = 0; 
    public int height { get; set; }
    public int containerOwnMass { get; set; }
    public int depth { get; set; }
    public string serialNumber { get; set; }
    public int maxWeight { get; set; }
    private static int _index = 0;
    protected int id { get; } = 0;

    public Container(int height, int containerOwnMass, int depth, string type, int maxWeight)
    {
        this.height = height;
        this.containerOwnMass = containerOwnMass;
        this.depth = depth;
        id = _index++;
        this.serialNumber = "KON-" + type + "" + id;
        this.maxWeight = maxWeight;
    }

    public virtual void ClearCargo()
    {
        cargoWeight = 0;
    }

    public virtual void AddCargo(int weight)
    {
        if (maxWeight > cargoWeight + weight)
        {
            throw new Exception(); //TODO OverfillException
        }
        cargoWeight += weight;
    }

    public virtual void AddCargo(int weight, string type)
    {
        AddCargo(weight);
    }

    public override string ToString()
    {
        return
            $"{nameof(cargoWeight)}: {cargoWeight}, {nameof(height)}: {height}, {nameof(containerOwnMass)}: {containerOwnMass}, {nameof(depth)}: {depth}, {nameof(serialNumber)}: {serialNumber}, {nameof(maxWeight)}: {maxWeight}, {nameof(id)}: {id}";
    }
}