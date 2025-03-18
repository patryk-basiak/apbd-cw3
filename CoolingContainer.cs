namespace Cwiczenia3;

public class CoolingContainer : Container, IHazardNotifier
{
    private string _cargoType;
    private Dictionary<string, double> temperature;
    private double temp;
    private bool empty = true;
    public CoolingContainer(int mass, int height, int weight, int depth, int maxLoad, string cargoType) : base(mass, height, weight, depth, "G", maxLoad)
    {
        temperature = new Dictionary<string, double>()
        {
            { "Bananas", 13.3 },
            { "Chocolate", 18 },
            { "Fish", 2 },
            { "Meat", -15 },
            { "Ice cream", -18 },
            { "Frozen pizza", -30 },
            { "Cheese", 7.2 },
            { "Sausages", 5  },
            { "Butter", 20.5  },
            { "Eggs", 19  },
        };
        
    }

    public override void AddItem(string item, int mass)
    {
        if (empty)
        {
            base.AddItem(item, mass);
            _cargoType = item;
        }
        if (_cargoType != item)
        {
            Notify();
        }
        else
        {
            base.AddItem(item, mass);
        }
    
    }

    public override void EmptyCargo()
    {
        base.EmptyCargo();
        empty = true;
    }

    public void Notify()
    {
        Console.WriteLine("Item is not the same type of cargo \n Item can not be added to CoolingContainer");
    }

    public bool Check()
    {
        throw new NotImplementedException();
    }
}