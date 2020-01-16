using responsibilityPattern.Models;
using startingTestconsoleApp.Handler;

namespace responsibilityPattern.Handler.validators
{
    public class SquirrelHandler: AbstractHandler<Animal>
    {
        public override object Handle(Animal animal)
        {
            return animal.Food?.ToUpperInvariant().Equals("NUT") ?? false
                ? $"{animal.Specie}: I'll eat the {animal.Food}.\n"
                : base.Handle(animal);
        }
    }
}