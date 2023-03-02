Feature: google search

Test main google page

Background: 
	Given open the browser
	Given the current page is 'Google'

@JTest
Scenario: Sufficient results
	When the user searches for 'Apple'
	Then the number of results is more than '100000'
	Then close browser

@JTest
Scenario: Insufficient results
	When the user searches for '????'
	Then the number of results is less than '10000'
	Then close browser