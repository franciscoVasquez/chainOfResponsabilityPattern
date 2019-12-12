using startingTestconsoleApp.Handler;
using startingTestconsoleApp.Models;
using System;

namespace startingTestconsoleApp.Validators
{
    public class SquirrelHandler: AbstractHandler<Animal>
    {
        public override object Handle(Animal animal)
        {
            if (animal.food.ToString() == "Nut")
            {
                return $"{animal.specie}: I'll eat the {animal.food.ToString()}.\n";
            }
            else
            {
                return base.Handle(animal);
            }
        }
    }
}