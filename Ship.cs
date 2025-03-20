using System.Globalization;

namespace Cwiczenia3;

public class Ship( int maxSpeed, int maxCointainersCount, int maxWeight, string name)
{
    public List<Container> containers { get; set; } = [];
    public int max_speed { get; set; } = maxSpeed;
    public int maxCointainersCount { get; set; } = maxCointainersCount;
    public int maxWeight { get; set; } = maxWeight;
    public int currentWeight { get; private set;  } = 0;
    public string name { get; private set; } = name;

    public void AddContainer(Container? container)
    {
        if (container == null)
        {
            return;
        }
        if (maxCointainersCount > containers.Count + 1 && maxWeight > currentWeight + container.cargoWeight) 
        {
            containers.Add(container);
            currentWeight += container.cargoWeight;
        }
        else
        {
            Console.WriteLine("Cannot add container");
        }
    }

    public Container? RemoveContainer(Container container)
    {
        if (containers.Contains(container))
        {
            containers.Remove(container);
            currentWeight -= container.cargoWeight;
            return container;
        }
        Console.WriteLine("There is not such container in this ship");
        return null;
        
    }

    public void AddContainerList(List<Container> list)
    {
        foreach (var container in list)
        {
            AddContainer(container);
        }
    }

    public Container? RemoveContainer(string serialNumber)
    {
        Container? c = containers.FirstOrDefault(container => container.serialNumber == serialNumber);
        return RemoveContainer(c);
    }

    public void Replace(string serialNumber, Container replacement)
    {
        RemoveContainer(serialNumber);
        AddContainer(replacement);
    }

    public override string ToString()
    {
        return
            $"Ship name = {name} \n{string.Join(",", containers)}, {nameof(max_speed)}: {max_speed}, {nameof(maxCointainersCount)}: {maxCointainersCount}, {nameof(maxWeight)}: {maxWeight}, {nameof(currentWeight)}: {currentWeight}";
    }
}