class Program
{
    static void Main()
    {
        Ecosystem ecosystem = new Ecosystem();

        Animal lion = new Animal("Lion", 100, 5, 2.5);
        Animal zebra = new Animal("Zebra", 50, 3, 1.8);
        Plant oakTree = new Plant("Oak Tree", 30, 10, 5.0);
        Microorganism bacteria = new Microorganism("E. coli", 10, 1, 0.001);

        ecosystem.AddOrganism(lion);
        ecosystem.AddOrganism(zebra);
        ecosystem.AddOrganism(oakTree);
        ecosystem.AddOrganism(bacteria);

        ecosystem.SimulateInteractions();
    }
}