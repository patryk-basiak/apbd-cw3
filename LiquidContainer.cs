﻿namespace Cwiczenia3;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool hazard { get; set; }
    public LiquidContainer(int height, int containerOwnMass, int depth, int maxWeight, bool hazard) : base(height, containerOwnMass, depth, "L", maxWeight)
    {
        this.hazard = hazard;
    }

    public LiquidContainer() : base("L")
    {
        this.hazard = false;
    }

    public void Notify()
    {
        Console.WriteLine("Hazardous situation in " + base.id + " container");
    }
    

    public override void AddCargo(int weight)
    {
        if (hazard)
        {
            if (maxWeight * 0.5 < cargoWeight + weight)
            {
                Notify();
            }
        }
        else
        {
            if (maxWeight * 0.9 <= cargoWeight + weight)
            {
                Notify();
            }
           
        }
        base.AddCargo(weight);
        
    }
}