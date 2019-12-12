using System;
using startingTestconsoleApp.Models;
using startingTestconsoleApp;
using System.Collections.Generic;

namespace resposbalitityPattrn
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //It's possible define any quatity of animals in the chain. 
            List<Animal> animals = new List<Animal>();
            animals.Add(new Animal {food = "Nut",specie = "Squirrel"});
            animals.Add(new Animal {food = "Banana",specie = "Monkey"});
            animals.Add(new Animal {food = "Milk",specie = "Cat"});

             
            Console.WriteLine("Chain: Squirrel > Monkey > Cat\n");

            var AnimalsClient = new AnimalClient();
            AnimalsClient.Processor(animals);
            Console.WriteLine();

            Console.WriteLine("Subchain: Squirrel > Dog\n");
        }
    }
}
