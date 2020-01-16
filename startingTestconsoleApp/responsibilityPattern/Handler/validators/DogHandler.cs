using responsibilityPattern.Models;
using startingTestconsoleApp.Handler;

namespace responsibilityPattrn.Handler.validators
{
    public class DogHandler: AbstractHandler<Animal>
    {
        public override object Handle(Animal animal)
        {
            return animal.Food?.ToUpperInvariant().Equals("MEATBALL") ?? false
                ? $"Dog: I'll eat the {animal.Food}.\n"
                : base.Handle(animal);
        }
    }
}