using Tutorial3.Exceptions;
using Tutorial3.Interfaces;

namespace Tutorial3.Containers;

public class Container : IContainer
{
    public double CargoWeight { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public double Depth { get; set; }
    public string SerialNumber { get; set; }
    public double Capacity { get; set; }
    
    
    public virtual void ShowInfo()
    {
        Console.WriteLine("Container number "+SerialNumber+": ");
        Console.WriteLine("Cargo weight: "+CargoWeight);
        Console.WriteLine("Container weight: "+Weight);
        Console.WriteLine("Height: "+Height);
        Console.WriteLine("Depth: "+Depth);
        Console.WriteLine("Capacity: "+Capacity);
    }
    public Container(double height, double weight, double depth, double capacity)
    {
        
        Height = height;
        Weight = weight;
        Depth = depth;
        Capacity = capacity;
    }

    public virtual void Unload()
    {
        CargoWeight = 0;
    }

    public virtual void Load(double cargoWeight)
    {
        Console.WriteLine("Container loaded");
        CargoWeight = cargoWeight;
        if (cargoWeight > Capacity)
        {
             throw new OverfillException("Container has overfilled");
        }
    }

 
}
