Feature: SearchResultTest
Background:
Given I am on the homepage

@mytag
Scenario: Check the first paragraph in Search result is shown correctly	
	When click on Start button
	When click on Generate button
	Then the first paragraph in Search result is missing certain "Lorem ipsum"

Scenario: Check the text in Search result is shown correctly
	When click on Language button
	Then the text in Search result is contain "рыба"

Scenario: Check the text in Search result is contain the search string
	When click on Generate button
	Then the text is contain "Lorem ipsum dolor sit amet, consectetur adipiscing elit"

Scenario: Check the average number of found words in paragraphs
	When click on Generate button
	Then the average number of found "Lorem ipsum" in paragraphs 

