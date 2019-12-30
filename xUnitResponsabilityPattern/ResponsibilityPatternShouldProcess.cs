using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using responsibilityPattern;
using responsibilityPattrn.Handler.validators;
using starting_guy.Controllers;
using startingTestconsoleApp.Models;
using startingTestconsoleApp.Validators;
using Xunit;

namespace xUnitResponsabilityPattern
{
    public class ResponsabilityPatternShouldProcess
    {
        
        private readonly string _expected = string.Join("\n", 
            "Client: Who wants a Nut?   Squirrel: I'll eat the Nut.",
            "Client: Who wants a Banana?   Monkey: I'll eat the Banana.",
            "Client: Who wants a Milk?   Milk was left untouched.");
        private readonly ValuesController _controller;

        public ResponsabilityPatternShouldProcess()
        {
            _controller = new ValuesController();
        }
        [Fact]
        public void ProcessAnimalsReturnEmpty()
        {
            Assert.Equal(string.Empty, AnimalClient.Processor(new List<Animal>()));
        }

        [Fact]
        public void ProcessAnimalsReturnExpected()
        {
            var animals = new List<Animal>
            {
                new Animal {Food = "Nut", Specie = "Squirrel"},
                new Animal {Food = "Banana", Specie = "Monkey"},
                new Animal {Food = "Milk", Specie = "Cat"}
            };
            Assert.Equal(this._expected, AnimalClient.Processor((animals)));
        }

        [Fact]
        public void DogHandlerReturnExpected()
        {
            var dogHandler = new DogHandler();
            const string expected = "Dog: I'll eat the MeatBall.\n";
            Assert.Equal(expected, dogHandler.Handle(new Animal {Food = "MeatBall", Specie = "Dog"}).ToString());
        }
        
        [Fact]
        public void MonkeyHandlerReturnExpected()
        {
            var monkeyHandler = new MonkeyHandler();
            const string expected = "Monkey: I'll eat the BANANA.\n";
            Assert.Equal(expected, monkeyHandler.Handle(new Animal {Food = "BANANA", Specie = "Monkey"}).ToString());
        }
        
        [Fact]
        public void SquirrelHandlerReturnExpected()
        {
            var squirrelHandler = new SquirrelHandler();
            const string expected = "Squirrel: I'll eat the NUT.\n";
            // Act and Assert
            Assert.Equal(expected, squirrelHandler.Handle(new Animal {Food = "NUT", Specie = "Squirrel"}).ToString());
        }

        [Fact]
        public void Get_WhenCall_ReturnOkResult()
        {
            // Act
            var okResult = _controller.Get();
 
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ReturnsOkResult()
        {
            // Arrange
            var random = new Random();
            // Act
            var okResult = _controller.Get(random.Next());
 
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void ConsumeProcessor_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Act
            var badResponse = _controller.Post(null);
 
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }
        
        [Fact]
        public void ConsumeProcessor_ValidObjectPassed_ReturnsOkResult()
        {
            // Arrange
            var animals = new List<Animal>
            {
                new Animal {Food = "Nut", Specie = "Squirrel"},
                new Animal {Food = "Banana", Specie = "Monkey"},
                new Animal {Food = "Milk", Specie = "Cat"}
            };
            var valueAnimal = JsonConvert.SerializeObject(animals);
            // Act
            var okResult = _controller.Post(valueAnimal);
 
            // Assert
            Assert.NotNull(okResult);
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void ConsumeDelete_ReturnNoContentResult()
        {
            //arrange
            var random = new Random();
            //act
            var noContentResult = _controller.Delete(random.Next());
            //assert
            Assert.IsType<NoContentResult>(noContentResult);
        }
        [Fact]
        public void ConsumePut_ReturnNoContentResult()
        {
            //arrange
            var random = new Random();
            //act
            var noContentResult = _controller.Put(random.Next(), _expected);
            //assert
            Assert.IsType<NoContentResult>(noContentResult);
        }
    }
}