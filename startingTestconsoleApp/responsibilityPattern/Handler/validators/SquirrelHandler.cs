using startingTestconsoleApp.Handler;
using startingTestconsoleApp.Models;

namespace responsibilityPattrn.Handler.validators
{
    public class SquirrelHandler: AbstractHandler<Animal>
    {
        public override object Handle(Animal animal)
        {
            return animal.Food != null && animal.Food.ToUpperInvariant().Equals("NUT")
                ? $"{animal.Specie}: I'll eat the {animal.Food}.\n"
                : base.Handle(animal);
        }
    }
}