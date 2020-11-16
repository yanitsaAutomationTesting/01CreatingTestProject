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
	#Examples: 
	#| firstName | lastName | ffnumer | age | grossIncome | relationshipStatus | businessSource  | fullName     |
	#| Sarah     | Parker   | 85662   | 19  | 20000       | Married            | Internet Search | Sarah Parker |

	