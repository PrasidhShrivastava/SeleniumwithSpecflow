Feature: Tendable site scenarios

@Point1and2
Scenario Outline: Verify accessibility of the top-level menus: Home, Our Story, Our Solution, and Why Tendable
	Given I am on Tendable home page
	Then I can see "Tendable" logo on top left
	When I click on <menu_name> menu item
	Then I will land on <menu_path> page
	And I see "Request a Demo" button on the page

	Examples: 
	| menu_name       | menu_path       |
	| "Our Story"	  | "/our-story"    |
	| "Our Solution"  | "/our-solution" |
	| "Why Tendable?" | "/why-tendable" |


@Point3
Scenario Outline: Verify Contact Us form under marketing section
	Given I am on Tendable home page
	When I click on "Contact Us" button
	And I click on Marketing contact button
	And I fill the Contact form
	And I click on Submit button
	Then I will see error message as "Sorry, there was an error submitting the form. Please try again."


	