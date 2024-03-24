using Tutorial3.Exceptions;

namespace Tutorial3.Containers;

public class FreezerContainer : Container
{
    private static int sNumber = 1;
    private double temperature;
    private PossibleProducts productType;
    
    public void ShowInfo()
    {
        Console.WriteLine("Container number "+SerialNumber+": ");
        Console.WriteLine("Cargo weight: "+CargoWeight);
        Console.WriteLine("Container weight: "+Weight);
        Console.WriteLine("Height: "+Height);
        Console.WriteLine("Depth: "+Depth);
        Console.WriteLine("Capacity: "+Capacity);
        Console.WriteLine("Temperature inside: "+temperature);
        Console.WriteLine("Product type inside: "+productType);


    }
    
    public FreezerContainer(double height, double weight, double depth, double capacity, PossibleProducts product,double temp) : base( height, weight, depth, capacity)
    {
        productType = product;
        temperature = temp;
        SerialNumber = "KON-C-"+sNumber.ToString();
        sNumber++;
    }

    
    public void Unload()
    {
        CargoWeight = 0;
    }

    public virtual void Load(PossibleProducts product, double neededTemp , double cargoWeight)
    {
        Console.WriteLine("Freezer container loaded");
        CargoWeight = cargoWeight;
        if (cargoWeight > Capacity)
        {
            throw new OverfillException("Container has overfilled");
        }
        else if (product != productType)
        {
            throw new Exception("Wrong product type for container " + SerialNumber);
        }
        else if (neededTemp > temperature)
        {
            throw new Exception("Needed temperature doesn't match containers " + SerialNumber+" inside temperature.");
        }
       
    }
    
}