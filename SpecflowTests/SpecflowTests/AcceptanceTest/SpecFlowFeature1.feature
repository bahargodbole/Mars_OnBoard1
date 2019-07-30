Feature: SpecFlowFeature1
	In order to update my profile 
	As a skill trader
	I want to add the languages that I know

	# Automated test case 1

@mytag
	Scenario Outline: Check if user could able to add 4 languages
		Given I clicked on the Language tab under Profile page
		When I add different languages '<language>'  with levels '<level>'
		Then First added 4 languages '<language>' should be displayed on my listings
		Examples: 
		| language | level          |
		| English  | Fluent         |
		| Marathi  | Native         |
		| Hindi    | Conversational |
		| Kannada  | Basic          |

	# Automated Test Case 2
		
	@mytag
Scenario: Check if user could able to delete languages 
	Given I clicked on the Language tab under Profile page
	When I delete "English" language
	Then "English" shouldnot be displayed on my listings

@mytag
Scenario: Check if user could able to add education 
	Given I clicked on the Education tab under Profile page
	And I clicked on "Add New" tab
	When I add university "Pune" Degree "MCM" 
	Then Education with Degree "MCM" should be displayed on my listings

	
@mytag
Scenario: Check if user could able to edit education 
	Given I clicked on the Education tab under Profile page
	When I edited university "Pune" to "Mumbai" 
	Then Updated Education with University "Mumbai" should be displayed on my listings
@mytag
Scenario: Check if user could able to add skills 
	Given I clicked on the skills tab under Profile page
	When I add "programming" skill
	Then "programming" skill should be displayed on my listings
@mytag
Scenario: Check if user could able to delete skills 
	Given I clicked on the skills tab under Profile page
	When I delete "programming" skill
	Then "programming" skill shouldnot be displayed on my listings

# To Automate
@mytag
Scenario: Check if user could able to edit skills 
	Given I clicked on the skills tab under Profile page
	When I edit "programming" to "Gardening"skill
	Then "Gardening" skill should be displayed on my listings
@mytag
Scenario: Check if user could able to cancel update of skills 
	Given I clicked on the skills tab under Profile page
	When I clicked on update and cancel it
	Then No update on the list and same list should be displayed on my listings
@mytag
Scenario: Check if user could able to add certifcations 
	Given I clicked on the Certifications tab under Profile page
	When I add certificate "ISTQB" from "ANZTB"
	Then "ISTQB" certificate should be displayed on my listings
@mytag
Scenario: Check if user could able to delete certifcations 
	Given I clicked on the Certifications tab under Profile page
	When I delete certificate "ISTQB" 
	Then "ISTQB" certificate shouldnot be displayed on my listings
@mytag
Scenario: Check if user could able to edit certifcations 
	Given I clicked on the Certifications tab under Profile page
	When I edit certificate "ISTQB" to "JAVA"
	Then "JAVA" certificate should be displayed on my listings
@mytag
Scenario: Check if user could able to cancel update of certifications 
	Given I clicked on the Certifications tab under Profile page
	When I clicked on update and cancel it
	Then No update on the list and same list should be displayed on my listings
@mytag
Scenario: Check if user could able to add the description 
	Given I clicked on the Description under profile page
	When I add Description and save it
	Then Description should be displayed on my listings
@mytag
Scenario: Check if user could able to edit the firstname and lastname 
	Given I clicked on the firstname and lastname under profile page
	When I edit firstname and lastname and save it
	Then Updated firstname and lastname should be displayed on my listings
@mytag
Scenario: Check if user could able to edit the Availability,Hours,EarnTarget
	Given I clicked  on the Availability,Hours,EarnTarget under profile page
	When I edit Availability,Hours,EarnTarget 
	Then Updated Availability,Hours,EarnTarget should be displayed on my listings
@mytag
Scenario: Check if user could able to add ShareSkill
	Given I clicked  on the ShareSkill under profile page
	When I added Skills to be shared and save it
	Then Skill should be displayed on Manage Listings
@mytag
Scenario Outline: Check if user could able to add already added language with same level
	Given I clicked on the Language tab under Profile page
	When I add '<language>' with level '<level>'
	Then User shouldnot be able to add same language again 
	Examples: 
	| language  | level          |
	| English   | Fluent         |
	| English   | Fluent         |
@mytag
Scenario Outline: Check if user could able to add already added language with different level
	Given I clicked on the Language tab under Profile page
	When I added the '<language>' with the level '<level>'
	Then user shouldnot be able to add language with different level 
	Examples: 
	| language  | level          |
	| English   | Fluent         |
	| English   | Native         |	
