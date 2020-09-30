Feature: SearchResultTest


@mytag
Scenario: Check the first paragraph in Search result is shown correctly
	Given I am on the homepage
	When click on Start button
	When click on Generate button
	Then the first paragraph in Search result is missing certain "Lorem ipsum"

Scenario: Check the text in Search result is shown correctly
	Given I am on the homepage
	When click on Language button
	Then the text in Search result is contain "рыба"

Scenario: Check the text in Search result is contain the search string
	Given I am on the homepage
	When click on Generate button
	Then the text is contain "Lorem ipsum dolor sit amet, consectetur adipiscing elit"

