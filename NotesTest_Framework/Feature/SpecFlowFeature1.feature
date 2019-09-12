Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Add item in EAXamarinApp
	Given I create a new item by following values
		| key         | values      |
		| Title       | patito 123  |
		| Description | patito nada | 
	When I press add button
	Then the item should be displayed

