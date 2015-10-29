Feature: SampleAppContact
	In order to open a line of communication with the business
	As a user,
	I would like to be able to submit my contact information

Scenario: Enter all valid information
	Given I have entered correct information in all fields available
	When I press submit
	Then I should see the Thank You page

Scenario: Enter all invalid firstName
	Given I have entered invalid first name 
	When I submit invalid information
	Then I should remain on the Contact Page and see a validation error

Scenario: Enter no FirstName
	Given I have entered no first name
	When I submit invalid information
	Then I should remain on the Contact Page and see a validation error


