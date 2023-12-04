using System;
using System.Collections.Generic;

// Клас "Дорога"
class Road
{
    public double Length { get; set; }
    public double Width { get; set; }
    public int NumberOfLanes { get; set; }
    public int TrafficLevel { get; set; }

    public Road(double length, double width, int numberOfLanes, int trafficLevel)
    {
        Length = length;
        Width = width;
        NumberOfLanes = numberOfLanes;
        TrafficLevel = trafficLevel;
    }
}

// Енумерація для типу транспортного засобу
enum VehicleType
{
    Car,
    Truck,
    Bus
}

// Клас "Транспортний засіб"
class Vehicle : IDriveable
{
    public double Speed { get; set; }
    public double Size { get; set; }
    public VehicleType Type { get; set; }

    public Vehicle(double speed, double size, VehicleType type)
    {
        Speed = speed;
        Size = size;
        Type = type;
    }

    public void Move()
    {
        Console.WriteLine($"The {Type} is moving at a speed of {Speed} km/h.");
    }

    public void Stop()
    {
        Console.WriteLine($"The {Type} has stopped.");
    }
}

// Інтерфейс для дій транспортного засобу
interface IDriveable
{
    void Move();
    void Stop();
}

// Клас для імітації руху та зміни руху транспортних засобів
class TrafficSimulation
{
    public static void SimulateTraffic(Road road, List<Vehicle> vehicles)
    {
        Console.WriteLine($"Simulating traffic on a road with {road.NumberOfLanes} lanes and length {road.Length} km.");

        foreach (var vehicle in vehicles)
        {
            Console.WriteLine($"Vehicle Type: {vehicle.Type}, Size: {vehicle.Size}");
            vehicle.Move();
        }
    }
}

