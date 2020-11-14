Feature: Lorem Ipsum
		As a User,
		I can generate variations of Lorem Ipsum text
Background:
Given I am on the homepage

@mytag1
Scenario Outline: Generation of x-bytes equls to actual numbers of bytes on the page
	When I generate <amount> bytes of text with default starting text
	Then <expectedAmount> bytes has been found on the page
	
Examples:
	| amount	| expectedAmount 	| 
	| 0			| 5					| 
	| 1  		| 3  				| 
	| 5    		| 5     			| 
	| 10    	| 10     			| 

@mytag
Scenario Outline: Generation of x-words equls to actual numbers of words on the page
	When I generate <amount> words of text with default starting text
	Then <expectedAmount> words has been found on the page
Examples:
	| amount	| expectedAmount 	| 
	| 10		| 10				| 
	| -1  		| 5  				| 
	| 0    		| 5     			| 
	| 5    	    | 5     			| 
	| 20    	| 20     			| 