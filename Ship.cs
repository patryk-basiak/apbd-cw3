namespace Cwiczenia3;

public class Ship( int maxSpeed, int maxCointainersCount, int maxWeight)
{
    public List<Container> containers { get; set; } = new List<Container>();
    public int max_speed { get; set; } = maxSpeed;
    public int maxCointainersCount { get; set; } = maxCointainersCount;
    public int maxWeight { get; set; } = maxWeight;
}