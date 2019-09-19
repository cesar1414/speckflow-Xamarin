Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


Scenario: Add item in NotesApp
	Given I create a new item by following values
		| key         | values      |
		| Title       | patito 123  |
		| Description | patito nada | 
	When I press Save button
	Then the item should be displayed on Home page

Scenario: the user can delete Note in NotesApp
	Given I Edit "patito 123" a Note
	When I press Dlete button on Update page
	Then the Note not displayed in Home page

@CreateNote
 Scenario: the user can edit Note in NotesApp
	Given I Edit "patito hook" a Note by following values
		| key         | values       |
		| Title       | patito 1234  |
		| Description | patito nada  | 
	When I press Save button on Update page
	Then the item should be displayed on Home page
