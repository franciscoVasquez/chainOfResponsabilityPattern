using startingTestconsoleApp.Handler;
using startingTestconsoleApp.Models;

namespace responsibilityPattrn.Handler.validators
{
    public class DogHandler: AbstractHandler<Animal>
    {
        public override object Handle(Animal animal)
        {
            return animal.Food?.ToUpperInvariant().Equals("MEATBALL") ?? false
                ? $"{animal.Specie}: I'll eat the {animal.Food}.\n"
                : base.Handle(animal);
        }
    }
}