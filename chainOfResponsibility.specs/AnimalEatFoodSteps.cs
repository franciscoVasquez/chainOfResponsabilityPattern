using System;
using responsibilityPattern;
using responsibilityPattrn.Handler.validators;
using startingTestconsoleApp.Models;
using startingTestconsoleApp.Validators;
using TechTalk.SpecFlow;
using Xunit;

namespace chainOfResponsibility.specs
{
    [Binding]
    public class AnimalEatFoodSteps
    {
        private Animal _animal;
        private MonkeyHandler _monkeyHandler;
        private SquirrelHandler _squirrelHandler;
        private DogHandler _dogHandler;

        [Given(@"I'm a Zoo Worker")]
        public void GivenImaZooWorker()
        {
            _animal = new Animal();
        }

        [When(@"I throw a (.*)")]
        public void WhenIThrowFood(string p0)
        {
            _animal.Food = p0;
        }

        [Then(@"the animal who picked the food should be (.*)")]
        public void ThenTheCorrectAnimalWillEatTheFood(string p0)
        {
            _animal.Specie = p0;

            switch (p0)
            {
                case "Dog":
                    _dogHandler = new DogHandler();
                    Assert.Equal($"{p0}: I'll eat the {_animal.Food}.\n", _dogHandler.Handle(_animal));
                    break;
                case "Monkey":
                    _monkeyHandler = new MonkeyHandler(); ;
                    Assert.Equal($"{p0}: I'll eat the {_animal.Food}.\n", _monkeyHandler.Handle(_animal));
                    break;
                case "Squirrel":
                    _squirrelHandler = new SquirrelHandler();
                    Assert.Equal($"{p0}: I'll eat the {_animal.Food}.\n", _squirrelHandler.Handle(_animal));
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

        }

    }
}
