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
            if (animals == null) return stringBuilder.ToString();
            foreach (var animal in animals)
            {
                stringBuilder.Append($"Client: Who wants a {animal.Food}?");
                var result = monkey.Handle(animal);
                stringBuilder.Append(result == null ? $"   {animal.Food} was left untouched.\n" : $"   {result}");
            }

            return stringBuilder.ToString();
        }
    }
}