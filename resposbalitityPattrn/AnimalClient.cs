using System;
using startingTestconsoleApp.Models;
using startingTestconsoleApp.Handler;
using System.Collections.Generic;
using startingTestconsoleApp.Validators;

namespace startingTestconsoleApp
{
    public class AnimalClient 
    {
        public void Processor(List<Animal> animals)
        {
            // The other part of the processor code constructs the actual chain.
            var monkey = new MonkeyHandler();
            var squirrel = new SquirrelHandler();
            var dog = new DogHandler();

            // The client should be able to send a request to any handler, not
            // just the first one in the chain.
            monkey.SetNext(squirrel).SetNext(dog);

             foreach (var animal in animals)
            {
                Console.WriteLine($"Client: Who wants a {animal.food}?");

                var result = monkey.Handle(animal);

                if (result != null)
                {
                    Console.Write($"   {result}");
                }
                else
                {
                    Console.WriteLine($"   {animal.food} was left untouched.");
                }
            }
        }
    }
}