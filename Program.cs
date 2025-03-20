// See https://aka.ms/new-console-template for more information

using Cwiczenia3;

Console.WriteLine("Hello, World!");

LiquidContainer lq = new LiquidContainer(100,10, 5, 20, false);
Ship s = new Ship(100, 15, 50, "orzel");
lq.AddCargo(15);
s.AddContainer(lq);
s.AddContainerList([new LiquidContainer(100,10, 5, 20, true), new GasContainer(10,5,10,100),
new RefrigeratedContainer(100, 10, 20, 30, -20)]);
s.RemoveContainer(lq);
lq.ClearCargo();
s.AddContainer(lq);
s.Replace(lq.serialNumber, new RefrigeratedContainer(100,10,10,10,2));
Ship s2 = new Ship(100,100, 1000, "żbik");
GasContainer gs = new GasContainer(10, 5, 10, 100); 
s.AddContainer(gs);
s2.AddContainer(s.RemoveContainer(gs));
Console.WriteLine(gs);
Console.WriteLine(s2);