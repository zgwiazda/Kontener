using Tutorial3;
using Tutorial3.Containers;

// var container = new Container(10.0)
// {
//     CargoWeight = 12.0
// };
//
// int? a = 1;
// a = null;
//
// Exception? ex = new Exception();
// ex = null;
//
// Console.WriteLine(ex.Message);

Container container = new Container(100,20,20,1000);
Container liquidContainer = new LiquidContainer(20,30,12,33);
LiquidContainer liquidContainer2 = new LiquidContainer(1,2,3,4);
container.Load(10);
liquidContainer.Load(10);
liquidContainer2.Load(PossibleProducts.Acid,10);

ContainerShip containerShip = new ContainerShip(12, 2, 2);
containerShip.LoadContainer(container);
containerShip.LoadContainer(liquidContainer2);
containerShip.LoadContainer(liquidContainer);


// ArrayList
List<int> numbers = new List<int>() { 1, 2, 3 };
List<int> numbers2 = new() { 1, 2, 3 };
// Set
HashSet<int> set = new HashSet<int>() { 3, 4, 5 };
// Map
Dictionary<PossibleProducts, double> products = new();