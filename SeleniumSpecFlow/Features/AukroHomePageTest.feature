Feature: AukroHomePageTest

Scenario Outline: Aukro Test
	Given Load Current page
	And Close pop up Agreement
	And Close pop up Aukro Offer
	When I select Category Button
	When I select "<SelectCategoryOption>" Option
	When I select Parameter Options Checkboxes
	| ReturnMoneyGuarantee |
	| check               |
	Then Verify that all offers include Aukro Return Money Guarantee

Examples:
| ID   | SelectCategoryOption |
| Test | Collectibles         |