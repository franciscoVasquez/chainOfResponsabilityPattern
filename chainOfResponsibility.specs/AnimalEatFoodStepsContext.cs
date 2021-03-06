﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using responsibilityPattern.Handler.validators;
using responsibilityPattern.Models;
using responsibilityPattrn.Handler.validators;

namespace chainOfResponsibility.specs
{
    [ExcludeFromCodeCoverage]
    public class AnimalEatFoodStepsContext
    {
        private static readonly string _expected = string.Join("\n",
            "Client: Who wants a Nut?   Squirrel: I'll eat the Nut.",
            "Client: Who wants a Banana?   Monkey: I'll eat the Banana.",
            "Client: Who wants a Milk?   Milk was left untouched.\n");
        public Animal _animal { get; set; } = new Animal();
        public MonkeyHandler _monkeyHandler { get; set; } = new MonkeyHandler();
        public SquirrelHandler _squirrelHandler { get; set; } = new SquirrelHandler();
        public DogHandler _dogHandler { get; set; } = new DogHandler();
        public IEnumerable<Animal> _animals { get; set; } = new List<Animal>();

        public string Expected { get; set; } = _expected;
        
    }
}
