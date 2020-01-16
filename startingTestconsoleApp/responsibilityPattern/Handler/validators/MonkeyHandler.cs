using responsibilityPattern.Models;
using startingTestconsoleApp.Handler;

namespace responsibilityPattern.Handler.validators
{
    public class MonkeyHandler: AbstractHandler<Animal>
    {
        public override object Handle(Animal animal)
        {
            return animal.Food?.ToUpperInvariant().Equals("BANANA") ?? false
                ? $"{animal.Specie}: I'll eat the {animal.Food}.\n"
                : base.Handle(animal);
        }
    }
}