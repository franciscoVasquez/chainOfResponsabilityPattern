using responsibilityPattern.Models;
using startingTestconsoleApp.Handler;


namespace responsibilityPattrn.Handler.validators
{
    public class CatHandler : AbstractHandler<Animal>
    {
        public override object Handle(Animal animal)
        {
            return animal.Food?.ToUpperInvariant().Equals("MILK") ?? false
                ? $"{animal.Specie}: I'll eat the {animal.Food}.\n"
                : base.Handle(animal);
        }   
    }
}