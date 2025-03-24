using Cwiczenia3;

var shipList = new List<Ship>();
var containerList = new List<Container>();

bool program = true;
Menu();
while (program)
{
    Console.WriteLine("=========");
    PrintAction();
    string action = Console.ReadLine();
    MakeAction(Int32.Parse(action));
    
}

return;

void Menu()
{
    Console.WriteLine("Witaj użytkowniku w systemie zarządzania portem towarowym!");
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
    Console.WriteLine("9. Wyjdź z programu");
    
}

void ManageShip(Ship s)
{
    Console.WriteLine("====================================");
    Console.WriteLine($"Zarządzanie kontenerowcem {s.name}");
    Console.WriteLine($"Liczba kontenerów {s.containers.Count}/{s.maxCointainersCount}");
    Console.WriteLine($"Waga {s.currentWeight}/{s.maxWeight}");
    Console.WriteLine("Możliwe akcje:");
    Console.WriteLine("1. Dodaj kontener z magazynu:");
    Console.WriteLine("2. Dodaj nowy kontener:");
    Console.WriteLine("3. Usuń kontener:");
    Console.WriteLine("4. Przenieś kontener do innego statku:");
    Console.WriteLine("9. Powrót do menu");
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
        case "5":
            return;
        default:
            Console.WriteLine("Brak dostępnej opcji");
            return;
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
            Console.Write($"{ship.name}, ");
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
            if (c.type == "C")
            {
                Console.Write("Podaj ile typ ładunku: ");
                var type  = Console.ReadLine(); 
                c.AddCargo(xid, type);
                break;
            }
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
            var c = NewContainer();
            ManageContainer(c);
            containerList.Add(c);
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
        case 4:
            var xc = GetContainerFromStorage();
            PrintShipListWithout(null);
            Console.Write("Napisz nazwę statku na którym umiesić kontener: ");
            var sh = GetShipByName(Console.ReadLine());
            sh.AddContainer(xc);
            break;
        case 5:
            PrintShipListWithout(null);
            Console.Write("Napisz nazwę statku z którego usunać kontener: ");
            var sho = GetShipByName(Console.ReadLine());
            sho.containers.Remove(FindContainerInShip(sho));
            break;
        case 6: 
            PrintShipListWithout(null);
            MoveBetweenShip();
            break;
        case 7:
            var tempCont = GetContainerFromStorage();
            containerList.Remove(tempCont);
            break;
        case 9:
            Environment.Exit(1);
            break;
        default:
            Console.WriteLine("Brak dostępnej opcji");
            return;
    }
}

void MoveBetweenShip()
{
    if (shipList.Count < 2)
    {
        return;
    }
    Console.Write("Napisz nazwę statku z którego usunać kontener: ");
    var shipo = GetShipByName(Console.ReadLine());
    var cont = FindContainerInShip(shipo);
    PrintShipListWithout(shipo);
    Console.Write("Podaj nazwę statku docelowego: ");
    GetShipByName(Console.ReadLine()).AddContainer(shipo.RemoveContainer(cont));
}

Container NewContainer()
{
    Console.WriteLine("Podaj typ kontenera [L, G, C]");
    string type = Console.ReadLine().ToUpper();
    Container c = null;
    Console.Write("Podaj wysokosc kontenera: ");
    int h = Int32.Parse(Console.ReadLine());
    Console.Write("Podaj wage kontenera: ");
    int w = Int32.Parse(Console.ReadLine());
    Console.Write("Podaj głebokość kontenera: ");
    int d = Int32.Parse(Console.ReadLine());
    Console.Write("Podaj masymalna wagę: ");
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