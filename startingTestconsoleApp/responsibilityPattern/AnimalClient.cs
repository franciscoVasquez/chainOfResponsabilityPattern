using System;
using System.Collections.Generic;
using System.Text;
using responsibilityPattrn.Handler.validators;
using startingTestconsoleApp.Models;
using startingTestconsoleApp.Validators;

namespace responsibilityPattern
{
    public static class AnimalClient 
    {
        public static string Processor(IEnumerable<Animal> animals)
        {
            var stringBuilder = new StringBuilder();
            // The other part of the processor code constructs the actual chain.
            var monkey = new MonkeyHandler();
            var squirrel = new SquirrelHandler();
            var dog = new DogHandler();
            // The client should be able to send a request to any handler, not
            // just the first one in the chain.
            monkey.SetNext(squirrel).SetNext(dog);
            object result = null;
            foreach (var animal in animals)
            {
                if (!animal.Equals(null))
                {
                    Console.WriteLine($"Client: Who wants a {animal.Food}?");
                    stringBuilder.Append($"Client: Who wants a {animal.Food}?");
                    result = monkey.Handle(animal);

                }
                if (result == null)
                {
                    stringBuilder.Append($"   {animal.Food} was left untouched."); 
                    Console.WriteLine($"   {animal.Food} was left untouched.");
                    break;    
                }
                stringBuilder.Append($"   {result}");
                Console.Write($"   {result}");
                
            }

            return stringBuilder.ToString();
        }
    }
}