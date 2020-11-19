Feature: As a user I want to be able to use all fatures on Home page

@mytag
Scenario: Reload Home page on the back
	Given I am on Home page
	And the initial generation token is visible
	And I go to the About page
	When I go back from the About Page
	Then I am on Home page
	And the generation token is different from the inital one

Scenario: Verify Product Rates
	Given I am on Home page
	Then Product and Rates are:
	| productName        | rate    |
	| Easy Credit Card   | 20% APR |
	| Silver Credit Card | 18% APR |
	| Gold Credit Card   | 17% APR |

Scenario: Go to Contact page clicking on Contact link
	Given I am on Home page
	When I click on the Contact link
	Then the Contact page is loaded in a new tab

Scenario Outline: Open Alert pop-up and close it
	Given I am on Home page
	When I click on the Start Live Chat link
	Then the Alert pop-up is visible with text <text> and accept it
	Examples: 
	| text                           |
	| Live chat is currently closed. |

Scenario Outline: Not navigate to About page on Cancel and navigate to it on OK
	Given I am on Home page
	When I click on the All Aout Us link
	Then the Alert pop-up is visible with text <text> and close it
	And I am on Home page
	When I click on the All Aout Us link
	Then the Alert pop-up is visible with text <text> and accept it
	And I am on About page
	Examples: 
	| text                                |
	| Do you want to learn more about us? |



	




