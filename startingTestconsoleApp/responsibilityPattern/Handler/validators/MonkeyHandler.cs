using startingTestconsoleApp.Handler;
using startingTestconsoleApp.Models;

namespace startingTestconsoleApp.Validators
{
    public class MonkeyHandler: AbstractHandler<Animal>
    {
        public override object Handle(Animal animal)
        {
            return animal.Food.ToUpperInvariant().Equals("BANANA")
                ? $"{animal.Specie}: I'll eat the {animal.Food}.\n"
                : base.Handle(animal);
        }
    }
}