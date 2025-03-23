using Cwiczenia3;

var shipList = new List<Ship>();
var containerList = new List<Container>();

bool program = true;
Menu();
while (program)
{
    PrintAction();
    string action = Console.ReadLine();
    MakeAction(Int32.Parse(action));
    
}

return;

void Menu()
{
    Console.WriteLine("Witaj użytkowniku w systemie zarządzania portem towarowym!");
    Console.WriteLine("");
}

void PrintAction()
{
    var index = 0;
    Console.WriteLine("Możliwe akcje:");
    Console.WriteLine($"{++index}. Dodaj kontenerowiec");
    Console.WriteLine($"{++index}. Dodaj kontener");
    if (shipList.Count != 0)
    {
        Console.WriteLine($"{++index}. Zarządzaj kontenerowcem");
        if (containerList.Count != 0)
        {
            Console.WriteLine($"{++index}. Zaladuj kontener na statek");
            Console.WriteLine($"{++index}. Rozladuj kontener ze statku");
            Console.WriteLine($"{++index}. Przełóż kontener miedzy statkami");
            Console.WriteLine($"{++index}. Usun kontener");
        }
    }
    
}

void ManageShip(Ship s)
{
    Console.WriteLine($"Zarządzanie kontenerowcem {s.name}");
    Console.WriteLine($"Liczba kontenerów {s.containers.Count}/{s.maxCointainersCount}");
    Console.WriteLine($"Waga {s.currentWeight}/{s.maxWeight}");
    Console.WriteLine("Możliwe akcje:");
    Console.WriteLine("1. Dodaj kontener z magazynu:");
    Console.WriteLine("2. Dodaj nowy kontener:");
    Console.WriteLine("3. Usuń kontener:");
    Console.WriteLine("4. Przenieś kontener do innego statku:");
    string action = Console.ReadLine();
    switch (action)
    {
        case "1":
            var container = GetContainerFromStorage();
            if (container != null)
            {
                s.AddContainer(container);
            }

            return; 
        case "2":
            Console.WriteLine("Uwaga nie można modyfikować zawartości kontenera po załadowaniu na statek");
            var c = NewContainer();
            ManageContainer(c);
            s.AddContainer(c);
            break;
        case "3":
            s.containers.Remove(FindContainerInShip(s));
            break;
        case "4":
            var cont = FindContainerInShip(s);
            PrintShipListWithout(s);
            Console.WriteLine("Podaj nazwę statku docelowego");
            GetShipByName(Console.ReadLine()).AddContainer(s.RemoveContainer(cont));
            break;
    }
}

Ship GetShipByName(string name)
{
    return shipList.Find(s => s.name == name);
}

void PrintShipListWithout(Ship s)
{
    foreach (var ship in shipList)
    {
        if (ship != s)
        {
            Console.WriteLine($"{ship.name}, ");
        }
    }
}


Container FindContainerInShip(Ship s)
{
    foreach (var vContainer in s.containers)
    {
        Console.WriteLine($"[{vContainer.id},{vContainer.type}, {vContainer.cargoWeight}]");
    }
    Console.WriteLine("Podaj id kontenera:");
    var xid = Int32.Parse(Console.ReadLine());
    return s.containers.Find(s => s.id == xid);
}

void ManageContainerInStorage()
{
    var c = GetContainerFromStorage();
    ManageContainer(c);
}

void ManageContainer(Container c)
{
    Console.WriteLine("Informacje o kontenerze");
    Console.WriteLine($"[{c.id},{c.type}, {c.cargoWeight}]");
    Console.WriteLine("Akcje:");
    Console.WriteLine("1. Dodaj ładunek");
    Console.WriteLine("2. Opróżnij kontener");
    var action = Console.ReadLine();
    switch (action)
    {
        case "1":
            Console.Write("Podaj ile dodać kg ładunku: ");
            var xid = Int32.Parse(Console.ReadLine());
            c.AddCargo(xid);
            break;
        case "2":
            c.ClearCargo();
            break;
        default:
            Console.WriteLine("Brak dostępnej opcji");
            return;
    }
    
}

Container GetContainerFromStorage()
{
    if (containerList.Count == 0)
    {
        return null;
    }
    foreach (var xContainer in containerList)
    {
        Console.WriteLine($"[{xContainer.id},{xContainer.type}, {xContainer.cargoWeight}]");
    }
    Console.WriteLine("Podaj id kontenera:");
    var xid = Int32.Parse(Console.ReadLine());
    return containerList.Find(s => s.id == xid);
}

void MakeAction(int action)
{
    switch (action)
    {
        case 1:
            shipList.Add(newShip());
            break;
        case 2:
            containerList.Add(NewContainer());
            break;
        case 3:
            Console.WriteLine();
            Console.WriteLine("Lista kontenerowców:");
            foreach (var s in shipList)
            {
                Console.WriteLine(s.name + '\t');
            }
            Console.Write("Podaj nazwę kontenerwoca którym chcesz zarządzać: ");
            string contName = Console.ReadLine();
            var ship = shipList.Find(ship => ship.name == contName);
            if (ship != null)
            {
                ManageShip(ship);
            }
            else
            {
                Console.WriteLine("Nie ma takiego statku");
            }
            break; 
    }
}

Container NewContainer()
{
    Console.WriteLine("Podaj typ kontenera [L, G, C]");
    string type = Console.ReadLine().ToUpper();
    Container c = null;
    Console.Write("Podaj wysokosc kontenera: ");
    int h = Int32.Parse(Console.ReadLine());
    Console.WriteLine("Podaj wage kontenera: ");
    int w = Int32.Parse(Console.ReadLine());
    Console.WriteLine("Podaj głebokość kontenera");
    int d = Int32.Parse(Console.ReadLine());
    Console.WriteLine("Podaj masymalna wagę");
    int mW = Int32.Parse(Console.ReadLine());
    if (type == "L")
    {
        Console.WriteLine("Czy kontener służy do przewozu towarów niebezpiecznych? [Tak/Nie]");
        string dec = Console.ReadLine().ToLower();
        bool hazard = dec == "tak";
        c = new LiquidContainer(h,w,d,mW,hazard); 
    }else if (type == "G")
    {
        c = new GasContainer(h,w,d,mW); 
    }else if (type == "C")
    {
        Console.WriteLine("Podaj temperature kontenera: ");
        float temp = float.Parse(Console.ReadLine());
        c = new RefrigeratedContainer(h,w,d,mW, temp); 
    }
    else
    {
        Console.WriteLine("Wrong type");
        return null;
    }

    return c;
}

Ship newShip()
{
    Console.Write("Podaj nazwe kontenerowca: ");
    string name = Console.ReadLine();
    Console.Write("Podaj predkość maksymalną: ");
    int speed = Int32.Parse(Console.ReadLine());
    Console.Write("Podaj maksymalna liczbę kontenerów: ");
    int maxCont = Int32.Parse(Console.ReadLine());
    Console.Write("Podaj masymalna wagę: ");
    int weight = Int32.Parse(Console.ReadLine());
    return new Ship(speed, maxCont, weight, name);
}