using System;
using System.Collections.Generic;

// Базовий клас "Живий організм"
class LivingOrganism
{
    public double Energy { get; set; }
    public int Age { get; set; }
    public double Size { get; set; }

    // Конструктор класу
    public LivingOrganism(double energy, int age, double size)
    {
        Energy = energy;
        Age = age;
        Size = size;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Energy: {Energy}, Age: {Age}, Size: {Size}");
    }
}

// Інтерфейс для розмноження
interface IReproducible
{
    void Reproduce();
}

// Інтерфейс для хижачого способу життя
interface IPredator
{
    void Hunt(LivingOrganism prey);
}

// Клас "Тварина", який успадковує від "Живого організму" та реалізує інтерфейси
class Animal : LivingOrganism, IReproducible, IPredator
{
    public string Species { get; set; }

    public Animal(string species, double energy, int age, double size)
        : base(energy, age, size)
    {
        Species = species;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Species: {Species}");
    }

    public void Reproduce()
    {
        Console.WriteLine($"{Species} is reproducing.");
    }

    public void Hunt(LivingOrganism prey)
    {
        Console.WriteLine($"{Species} is hunting {prey.GetType().Name}.");
    }
}

// Клас "Рослина", який успадковує від "Живого організму" та реалізує інтерфейс
class Plant : LivingOrganism, IReproducible
{
    public string Type { get; set; }

    public Plant(string type, double energy, int age, double size)
        : base(energy, age, size)
    {
        Type = type;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Type: {Type}");
    }

    public void Reproduce()
    {
        Console.WriteLine($"{Type} is reproducing.");
    }
}

// Клас "Мікроорганізм", який успадковує від "Живого організму" та реалізує інтерфейс
class Microorganism : LivingOrganism, IReproducible
{
    public string Strain { get; set; }

    public Microorganism(string strain, double energy, int age, double size)
        : base(energy, age, size)
    {
        Strain = strain;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Strain: {Strain}");
    }

    public void Reproduce()
    {
        Console.WriteLine($"{Strain} is reproducing.");
    }
}

// Клас "Екосистема", що моделює взаємодію організмів
class Ecosystem
{
    private List<LivingOrganism> organisms;

    public Ecosystem()
    {
        organisms = new List<LivingOrganism>();
    }

    public void AddOrganism(LivingOrganism organism)
    {
        organisms.Add(organism);
    }

    public void SimulateInteractions()
    {
        foreach (var organism in organisms)
        {
            Console.WriteLine($"Interactions for {organism.GetType().Name}:");
            organism.DisplayInfo();

            if (organism is IReproducible)
            {
                ((IReproducible)organism).Reproduce();
            }

            if (organism is IPredator)
            {
                foreach (var prey in organisms)
                {
                    if (organism != prey)
                    {
                        ((IPredator)organism).Hunt(prey);
                    }
                }
            }

            Console.WriteLine();
        }
    }
}

