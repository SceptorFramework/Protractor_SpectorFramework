Feature: CalculatorSuccess
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given I add url as http://juliemr.github.io/protractor-demo/
	Given I enter entered 50 into the element first calculator
	And I enter entered 70 into the element second calculator
	When I give Go! button
	Then the result must be 120 on the label /html/body/div/div/form/h2
