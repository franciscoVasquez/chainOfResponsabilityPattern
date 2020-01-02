Feature: AnimalEatFood
	In order to select the animal for each food
	As a Zoo Worker 
	I want to know which animal eat what food

Scenario: The Monkey will eat when I pass Banana
	Given I'm a Zoo Worker
	When I throw a Banana
	Then the animal who picked the food should be Monkey


Scenario: The Dog will eat when I pass MeatBall
	Given I'm a Zoo Worker
	When I throw a MeatBall
	Then the animal who picked the food should be Dog

	
Scenario: The Squirrel will eat when I pass Nut
	Given I'm a Zoo Worker
	When I throw a Nut
	Then the animal who picked the food should be Squirrel