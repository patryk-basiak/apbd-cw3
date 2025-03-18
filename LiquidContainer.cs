namespace Cwiczenia3;

public class LiquidContainer(int mass, int height, int weight, int depth, string type, int maxLoad)
    : Container(mass, height, weight, depth, type, maxLoad), IHazardNotifier
{
    private bool _dangerous = false;
    private int _tempMass = 0;

    public void AddItem(string item, int mass, bool dangerous)
    {
        this._dangerous = dangerous;
        if (Check())
        {
            base.load[item] = mass;
        }
        
    }

    public void Notify()
    {
        Console.WriteLine("Cargo mass exceeded certain amount operation can not be performed.");
        _tempMass = 0;
    }

    public bool Check()
    {
        if (_dangerous)
        {
            double temp = (maxLoad * 0.5);
            if ((_tempMass + base.CountMass()) > temp )
            {
                this.Notify();
                return false;
            }
        }
        else
        {
            double temp = (maxLoad * 0.9);
            if ((_tempMass + base.CountMass()) > temp )
            {
                this.Notify();
                return false;
            }
        }
        return true;
    }
}
    
    