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
            "Client: Who wants a Milk?   Milk was left untouched.\n");
        private readonly ValuesController _controller;

        public ResponsabilityPatternShouldProcess()
        {
            _controller = new ValuesController();
        }
        [Fact]
        public void ProcessAnimalsReturnEmpty()
        {
            //Act
            var result = AnimalClient.Processor(new List<Animal>());
            //Assert
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void ProcessAnimalsPassNullValueReturnStringEmpty()
        {
            //Act
            var result = AnimalClient.Processor((null));
            //Assert
            Assert.Equal(string.Empty, result);
        }
        [Fact]
        public void ProcessAnimalsReturnExpected()
        {
            //Arrange
            var animals = new List<Animal>
            {
                new Animal {Food = "Nut", Specie = "Squirrel"},
                new Animal {Food = "Banana", Specie = "Monkey"},
                new Animal {Food = "Milk", Specie = "Cat"}
            };
            //Act 
            var result = AnimalClient.Processor((animals));
            //Assert 
            Assert.Equal(this._expected, result);
        }

        [Fact]
        public void DogHandlerReturnExpected()
        {
            //Arrange
            var dogHandler = new DogHandler();
            const string expected = "Dog: I'll eat the MeatBall.\n";
            //Act 
            var result = dogHandler.Handle(new Animal {Food = "MeatBall", Specie = "Dog"}).ToString();
            //Assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void MonkeyHandlerReturnExpected()
        {
            //Arrange
            var monkeyHandler = new MonkeyHandler();
            const string expected = "Monkey: I'll eat the BANANA.\n";
            //Act
            var result = monkeyHandler.Handle(new Animal {Food = "BANANA", Specie = "Monkey"}).ToString();
            //Assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void SquirrelHandlerReturnExpected()
        {
            //Arrange
            var squirrelHandler = new SquirrelHandler();
            const string expected = "Squirrel: I'll eat the NUT.\n";
            // Act
            var result = squirrelHandler.Handle(new Animal {Food = "NUT", Specie = "Squirrel"}).ToString();
            // Assert
            Assert.Equal(expected, result);
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
            //Arrange
            var random = new Random();
            //Act
            var noContentResult = _controller.Delete(random.Next());
            //Assert
            Assert.IsType<NoContentResult>(noContentResult);
        }
        [Fact]
        public void ConsumePut_ReturnNoContentResult()
        {
            //Arrange
            var random = new Random();
            //Act
            var noContentResult = _controller.Put(random.Next(), _expected);
            //Assert
            Assert.IsType<NoContentResult>(noContentResult);
        }
    }
}