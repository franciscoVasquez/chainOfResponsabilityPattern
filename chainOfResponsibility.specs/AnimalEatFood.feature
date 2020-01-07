Feature: AnimalEatFood
	In order to select the animal for each food
	As a Zoo Worker 
	I want to know which animal eat what food

Scenario Outline: Feeding Animals
	Given I'm a Zoo Worker
	When I throw a <food>
	Then the animal who picked the food should be <animal>

	Examples: 
	| food     | animal   |
	| Banana   | Monkey   |
	| MeatBall | Dog      |
	| Nut      | Squirrel |

Scenario Outline: Bag of food 
	Given I'm a Zoo Worker
	When I throw a Bag with the following Foods
	| food     | specie   |
	| Nut      | Squirrel |
	| Banana   | Monkey   |
	| Milk     | Camel    |
	Then the response should be correct <response>

	Examples: 
	| response |
	| Client: Who wants a Nut | 

Scenario Outline: Bag of food missing Banana
	Given I'm a Zoo Worker
	When I throw a Bag with the following Foods
	| food     | specie   |
	| Nut      | Squirrel |
	| null     | Monkey   |
	| Milk     | Camel    |
	Then the response should be correct <response>

	Examples: 
	| response |
	| Client:  | 