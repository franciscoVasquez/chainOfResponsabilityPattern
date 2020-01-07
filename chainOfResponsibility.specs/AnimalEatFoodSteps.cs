using responsibilityPattern;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using startingTestconsoleApp.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace chainOfResponsibility.specs
{
    [Binding]
    [ExcludeFromCodeCoverage]
    public class AnimalEatFoodSteps
    {
        private readonly AnimalEatFoodStepsContext _context;

        public AnimalEatFoodSteps(AnimalEatFoodStepsContext animalEatFoodStepsContext)
        {
            _context = animalEatFoodStepsContext;
        }
        

        [Given(@"I'm a Zoo Worker")]
        public void GivenImaZooWorker()
        {
            //class animal is declared via constructor
        }

        [When(@"I throw a (.*)")]
        public void WhenIThrowFood(string p0)
        {
            _context._animal.Food = p0;
        }

        [Then(@"the animal who picked the food should be (.*)")]
        public void ThenTheCorrectAnimalWillEatTheFood(string p0)
        {
            _context._animal.Specie = p0;

            switch (p0)
            {
                case "Dog":
                    Assert.Equal($"{p0}: I'll eat the {_context._animal.Food}.\n", _context._dogHandler.Handle(_context._animal));
                    break;
                case "Monkey":
                    Assert.Equal($"{p0}: I'll eat the {_context._animal.Food}.\n", _context._monkeyHandler.Handle(_context._animal));
                    break;
                case "Squirrel":
                    Assert.Equal($"{p0}: I'll eat the {_context._animal.Food}.\n", _context._squirrelHandler.Handle(_context._animal));
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

        }
        
        [When(@"I throw a Bag with the following Foods")]
        public void WhenIThrowABagWithTheFollowingFoods(Table table)
        {
            _context._animals = table.CreateSet<Animal>();
        }

        [Then(@"the response should be correct (.*)")]
        public void ThenTheResponseShouldBeCorrect(string result)
        {
            var res = AnimalClient.Processor(_context._animals);
            Assert.Equal(result, AnimalClient.Processor(_context._animals));
        }
    }
}
