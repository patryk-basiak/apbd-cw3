namespace Cwiczenia3;

public class Container
{
    private static int value = 0;
    private int index;
    int mass;
    private int height;
    private int weight;
    private int depth;
    protected string serialNumber {get; set;}
    protected Dictionary<string, int> load;
    protected int maxLoad { get; set; }

    public Container(int mass, int height, int weight, int depth, string type, int maxLoad)
    {
        index = value++;
        this.mass = mass;
        this.height = height;
        this.weight = weight;
        this.depth = depth;
        this.serialNumber = "KON" + type + index;
        load = new Dictionary<string, int>();
    }

    public virtual void EmptyCargo()
    {
        load = new Dictionary<string, int>();
    }

    public virtual void AddItem(string item, int mass)
    {
        if (CountMass() + mass > maxLoad)
        {
            throw new Exception(); //TODO create new exception OverfillException
        }
        else
        {
            load.Add(item, mass);
        }
       
    }

    protected int CountMass()
    {
        return load.Sum(keyValuePair => keyValuePair.Value);
    }
    
}