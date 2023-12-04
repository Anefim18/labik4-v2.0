using System;
using System.Collections.Generic;

// Базовий клас "Комп'ютер"
class Computer
{
    public string IPAddress { get; set; }
    public int Power { get; set; }
    public string OperatingSystem { get; set; }

    // Конструктор класу
    public Computer(string ipAddress, int power, string operatingSystem)
    {
        IPAddress = ipAddress;
        Power = power;
        OperatingSystem = operatingSystem;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"IP Address: {IPAddress}, Power: {Power}, OS: {OperatingSystem}");
    }
}

// Інтерфейс для з'єднання комп'ютерів
interface IConnectable
{
    void Connect(Computer targetComputer);
    void Disconnect(Computer targetComputer);
    void TransferData(Computer targetComputer, string data);
}

// Клас "Сервер", який успадковує від "Комп'ютера" та реалізує інтерфейси
class Server : Computer, IConnectable
{
    public int StorageCapacity { get; set; }

    public Server(string ipAddress, int power, string operatingSystem, int storageCapacity)
        : base(ipAddress, power, operatingSystem)
    {
        StorageCapacity = storageCapacity;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Storage Capacity: {StorageCapacity} GB");
    }

    public void Connect(Computer targetComputer)
    {
        Console.WriteLine($"Server connected to {targetComputer.IPAddress}");
    }

    public void Disconnect(Computer targetComputer)
    {
        Console.WriteLine($"Server disconnected from {targetComputer.IPAddress}");
    }

    public void TransferData(Computer targetComputer, string data)
    {
        Console.WriteLine($"Data transferred from {IPAddress} to {targetComputer.IPAddress}: {data}");
    }
}

// Клас "Робоча станція", який успадковує від "Комп'ютера" та реалізує інтерфейси
class Workstation : Computer, IConnectable
{
    public string Department { get; set; }

    public Workstation(string ipAddress, int power, string operatingSystem, string department)
        : base(ipAddress, power, operatingSystem)
    {
        Department = department;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Department: {Department}");
    }

    public void Connect(Computer targetComputer)
    {
        Console.WriteLine($"Workstation connected to {targetComputer.IPAddress}");
    }

    public void Disconnect(Computer targetComputer)
    {
        Console.WriteLine($"Workstation disconnected from {targetComputer.IPAddress}");
    }

    public void TransferData(Computer targetComputer, string data)
    {
        Console.WriteLine($"Data transferred from {IPAddress} to {targetComputer.IPAddress}: {data}");
    }
}

// Клас "Маршрутизатор", який успадковує від "Комп'ютера" та реалізує інтерфейси
class Router : Computer, IConnectable
{
    public int DataTransferRate { get; set; }

    public Router(string ipAddress, int power, string operatingSystem, int dataTransferRate)
        : base(ipAddress, power, operatingSystem)
    {
        DataTransferRate = dataTransferRate;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Data Transfer Rate: {DataTransferRate} Mbps");
    }

    public void Connect(Computer targetComputer)
    {
        Console.WriteLine($"Router connected to {targetComputer.IPAddress}");
    }

    public void Disconnect(Computer targetComputer)
    {
        Console.WriteLine($"Router disconnected from {targetComputer.IPAddress}");
    }

    public void TransferData(Computer targetComputer, string data)
    {
        Console.WriteLine($"Data transferred from {IPAddress} to {targetComputer.IPAddress}: {data}");
    }
}

// Клас "Мережа", який моделює взаємодію між комп'ютерами
class Network
{
    private List<Computer> computers;

    public Network()
    {
        computers = new List<Computer>();
    }

    public void AddComputer(Computer computer)
    {
        computers.Add(computer);
    }

    public void SimulateConnections()
    {
        foreach (var computer in computers)
        {
            Console.WriteLine($"Connections for {computer.GetType().Name}:");
            computer.DisplayInfo();

            if (computer is IConnectable)
            {
                foreach (var targetComputer in computers)
                {
                    if (computer != targetComputer)
                    {
                        ((IConnectable)computer).Connect(targetComputer);
                        ((IConnectable)computer).TransferData(targetComputer, "Sample data");
                        ((IConnectable)computer).Disconnect(targetComputer);
                    }
                }
            }

            Console.WriteLine();
        }
    }
}

