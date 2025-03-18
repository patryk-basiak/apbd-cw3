using System.ComponentModel;

namespace Cwiczenia3;

public class GasContainer : Container, IHazardNotifier
{
    private int pressure = 0;
    public GasContainer(int mass, int height, int weight, int depth, string type, int maxLoad) : base(mass, height, weight, depth, type, maxLoad)
    {
        
    }

    public void Notify()
    {
        throw new NotImplementedException();
    }

    public bool Check()
    {
        throw new NotImplementedException();
    }

    public void AddItem(string item, int mass, int pres)
    {
        if (CountMass() + mass > maxLoad)
        {
            throw new Exception(); //TODO create new exception OverfillException
        }
        load.Add(item, mass);
        this.pressure += pres;
        
    }

    public override void EmptyCargo()
    {
        double threshold = maxLoad * 0.05;
        foreach(KeyValuePair<string, int> entry in load)
        {
            if (CountMass() - entry.Value > threshold)
            {
                load.Remove(entry.Key);
            }
            else
            {
                while (CountMass() - entry.Value > threshold)
                {
                    load[entry.Key] -= 1;
                }
            }
        }
        
    }
}