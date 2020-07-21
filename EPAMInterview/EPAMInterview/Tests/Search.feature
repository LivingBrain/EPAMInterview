Feature: Search

@SmokeTests
Scenario: User uses search on UBS landing page
	When User Navigates to UBS page
		And Cookie is added to hide popup and page is refreshed
		And User searches investment using search icon on landing page
