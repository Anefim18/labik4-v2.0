class Program
{
    static void Main()
    {
        // Створення дороги
        Road cityRoad = new Road(10, 4, 2, 3);

        // Створення транспортних засобів
        List<Vehicle> vehicles = new List<Vehicle>
        {
            new Vehicle(60, 2, VehicleType.Car),
            new Vehicle(40, 4, VehicleType.Truck),
            new Vehicle(50, 3, VehicleType.Bus)
        };

        // Симуляція руху на дорозі
        TrafficSimulation.SimulateTraffic(cityRoad, vehicles);
    }
}
