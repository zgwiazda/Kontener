using Tutorial3.Exceptions;
using Tutorial3.Interfaces;

namespace Tutorial3.Containers;

public class GasContainer : Container , IHazardNotifier

{
    private static int sNumber = 1;
    private double AtmPressure;
    public void ShowInfo()
    {
        Console.WriteLine("Container number "+SerialNumber+": ");
        Console.WriteLine("Cargo weight: "+CargoWeight);
        Console.WriteLine("Container weight: "+Weight);
        Console.WriteLine("Height: "+Height);
        Console.WriteLine("Depth: "+Depth);
        Console.WriteLine("Capacity: "+Capacity);
        Console.WriteLine("Atmospheric Pressure: "+AtmPressure);

    }

    public GasContainer( double height, double weight, double depth, double capacity, double pressure)
        : base(height, weight, depth, capacity)
    {
        AtmPressure = pressure;
        SerialNumber = "KON-G-"+sNumber.ToString();
        sNumber++;
    }
    public void Unload()
    {
        CargoWeight -= 0.95 * CargoWeight;

    }

    public void Load(double cargoWeight)
    {
        Console.WriteLine("Gas container loaded");
        CargoWeight = cargoWeight;
        if (cargoWeight > Capacity)
        {
            throw new OverfillException("Container has overfilled");
        }
        
       
    }

    public void Notify()
    {
        Console.WriteLine("Dangerous situation occured on container number "+SerialNumber);
    }
}