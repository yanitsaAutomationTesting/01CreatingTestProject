Feature: SubmitApplication
	As a user I want to be able to submit my application

@basic
Scenario: Submit my application with valid inputs in all fields
	
	Given I am on Home page
	When I click on the apply button
	Then I am on the application page
	Given I enter first name Sarah
	And I enter last name Parker
	And I enter Frequent Flyer Number 15363
	And I enter Age 19
	And I enter Gross Income 20000
	And I select Relationship status Married
	And I select business source Internet Search
	And I accept terms
	When I click on the Submit Application button
	And I am on the Application Complete Page
	Then the full name is Sarah Parker
	

	Scenario: Submit my application after correcting invalid inputs
	Given I am on Home page
	When I click on the apply button
	Then I am on the application page
	Given I enter first name Sarah
	And I enter Frequent Flyer Number 15363
	And I enter Age 17
	And I enter Gross Income 20000
	And I select Relationship status Married
	And I select business source Internet Search
	And I accept terms
	When I click on the Submit Application button
	Then I am on the application page
	Given there are 2 error messages
	And validation for missing Last Name is displayed
	And validation message for invalid age is displayed
	And I enter last name Parker
	And I clear the Age field
	And I enter Age 19
	When I click on the Submit Application button
	And I am on the Application Complete Page
	Then the full name is Sarah Parker
