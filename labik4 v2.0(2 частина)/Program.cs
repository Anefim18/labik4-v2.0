class Program
{
    static void Main()
    {
        Network network = new Network();

        Server server = new Server("192.168.0.1", 1000, "Windows Server", 5000);
        Workstation workstation = new Workstation("192.168.0.2", 500, "Windows 10", "Development");
        Router router = new Router("192.168.0.3", 200, "RouterOS", 100);

        network.AddComputer(server);
        network.AddComputer(workstation);
        network.AddComputer(router);

        network.SimulateConnections();
    }
}
