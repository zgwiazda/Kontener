namespace Tutorial3.Containers;

public class ContainerShip
{
    private List<Container> containers;
    private double MaxSpeed { get; set; }
    private int MaxAmountOfContainers { get; set; }
    
    
    private double MaxWeightOnBoard { get; set; } //given in tons, switched to kgs in constructor

    public void ShowInfo()
    {
        Console.WriteLine("This container ship: ");
        Console.WriteLine("Maximum speed: "+MaxSpeed);
        Console.WriteLine("Maximum amount of containers: "+MaxAmountOfContainers);
        Console.WriteLine("Maximum weight on board: "+MaxWeightOnBoard);
        Console.WriteLine("This ship contains: ");
        foreach (Container c in containers)
        {
            c.ShowInfo();
            
        }

    }
    public ContainerShip(double maxSpeed, int maxAmountOfContainers, double maxWeightOnBoard)
    {
        MaxSpeed = maxSpeed;
        MaxAmountOfContainers = maxAmountOfContainers;
        MaxWeightOnBoard = maxWeightOnBoard * 1000;
    }


    public void LoadContainer(Container container)
    {
        double combinedWeight = container.CargoWeight + container.Weight;
        if (combinedWeight <= MaxWeightOnBoard && MaxAmountOfContainers>0)
        {
            MaxWeightOnBoard -= combinedWeight;
            MaxAmountOfContainers--;
            containers.Add(container);
        }
        else
        {
            throw new Exception("This container ship is full.");
        }
    }
    public void LoadContainer(List<Container> addedContainers)
    {
        double combinedWeight = 0;
        int amountOfContainers = 0;
        foreach(Container c in addedContainers )
        {
            combinedWeight += c.CargoWeight + c.Weight;
            amountOfContainers++;

        }
        if (combinedWeight <= MaxWeightOnBoard && MaxAmountOfContainers>=amountOfContainers)
        {
            MaxWeightOnBoard -= combinedWeight;
            MaxAmountOfContainers-= amountOfContainers;
            foreach(Container c in addedContainers )
            {
                containers.Add(c);

            }
        }
        else
        {
            throw new Exception("This container ship is full.");
        }
    }

    public void DeleteContainer(string containerNumber)
    {
        for (int i = 0; i < containers.Count; i++)
        {
            if (containers[i].SerialNumber.Equals(containerNumber))
            {  
                MaxAmountOfContainers++;
                MaxWeightOnBoard += containers[i].Weight + containers[i].CargoWeight;
                containers.RemoveAt(i);
                break;
            }
        }
        Console.WriteLine("Deleted container number "+containerNumber);
    }

    public void ReplaceContainer(Container newContainer,Container oldContainer)
    {
        DeleteContainer(oldContainer.SerialNumber);
        LoadContainer(newContainer);
        
    }

    public void MoveContainer(Container c, ContainerShip ship)
    {
        DeleteContainer(c.SerialNumber);
        ship.LoadContainer(c);
    }
    
  
}