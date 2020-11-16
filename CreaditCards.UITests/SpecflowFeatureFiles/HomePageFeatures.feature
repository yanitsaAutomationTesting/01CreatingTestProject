Feature: As a user I want to be able to use all fatures on Home page

@mytag
Scenario: Reload Home page on the back
	Given I am on Home page
	And the initial generation token is visible
	And I go to the About page
	When I go back
	Then I am on Home page
	And the generation token is different from the inital one

