Feature: Search

@SmokeTests
Scenario: User uses search on UBS landing page
	When User Navigates to UBS page
		And User clicks Set Preferences on Privacy Settings popup
		And User searches investment using search icon on landing page
