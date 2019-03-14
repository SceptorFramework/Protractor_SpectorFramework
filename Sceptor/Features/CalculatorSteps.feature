Feature: CalculatorSteps
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers

	Given The url as http://juliemr.github.io/protractor-demo/
	Given I have entered 50 into the element first calculator
	And I have entered 70 into the element second calculator
	When I press Go! button
	Then the result should be 150 on the label /html/body/div/div/form/h2
