Feature: Navigate to Application Page from home page
	

@basic
Scenario: Navigate to application page clicking on the apply button
	Given I am on Home page
	When I click on the apply button
	Then I am on the application page
	

Scenario: Navigate to application clicking on the 3rd apply button
	Given I am on Home page
	And I click on the Next button on the right
	And I click on the Next button on the right
	When I click on the 3rd apply button
	Then I am on the application page

			
Scenario: Navigate to application page clicking on the random greeting link
	Given I am on Home page
	When I click on the random greeting link
	Then I am on the application page

Scenario: Navigate to application page clicking on the Easy Application button
	Given I am on Home page
	And I wait for the Easy Application button to be visible
	When I click on the Easy Application button
	Then I am on the application page





