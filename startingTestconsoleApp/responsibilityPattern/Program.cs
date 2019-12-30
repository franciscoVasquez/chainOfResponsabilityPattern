using System;
using startingTestconsoleApp.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace responsibilityPattern
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Chain: Squirrel > Monkey > Cat\n");
            GetAnimals();
            AnimalClient.Processor(GetAnimals());

            Console.WriteLine("Subchain: Squirrel > Dog\n");
            Console.ReadKey();
        }

        private static List<Animal> GetAnimals()
        {
            //It's possible define any quantity of animals in the chain. 

            var animals = new List<Animal>
            {
                new Animal {Food = "Nut", Specie = "Squirrel"},
                new Animal {Food = "Banana", Specie = "Monkey"},
                new Animal {Food = "Milk", Specie = "Cat"}
            };

            return animals;
        }
    }
}
