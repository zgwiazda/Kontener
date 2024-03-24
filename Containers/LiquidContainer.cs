using Tutorial3.Exceptions;
using Tutorial3.Interfaces;

namespace Tutorial3.Containers;

public class LiquidContainer : Container , IHazardNotifier
{
    private static int sNumber = 1;
    public void ShowInfo()
    {
        Console.WriteLine("Container number "+SerialNumber+": ");
        Console.WriteLine("Cargo weight: "+CargoWeight);
        Console.WriteLine("Container weight: "+Weight);
        Console.WriteLine("Height: "+Height);
        Console.WriteLine("Depth: "+Depth);
        Console.WriteLine("Capacity: "+Capacity);
    }
    public LiquidContainer(double height, double weight, double depth, double capacity)
        : base( height,weight,depth,capacity)
    {
        SerialNumber = "KON-L-"+sNumber.ToString();
        sNumber++;
    }
    
    public void Load(PossibleProducts product, double cargoWeight)
    {
        CargoWeight = cargoWeight;
        double maxCapacity = Capacity;
        if (product == PossibleProducts.Petrol || product == PossibleProducts.Acid)
        {
            maxCapacity /= 2;
        }
        else
        {
            maxCapacity *= 0.9;
        }
        
       
        Console.WriteLine("Liquid container loaded");
        if (cargoWeight > maxCapacity)
        {
            Notify();
            throw new OverfillException("Container has overfilled");
        }

    }

    public void Notify()
    {
        Console.WriteLine("Dangerous situation occured on container number "+SerialNumber);
    }
}