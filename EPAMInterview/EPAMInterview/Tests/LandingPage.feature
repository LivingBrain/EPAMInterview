Feature: LandingPage

@SmokeTests
Scenario: User selects domicile on landing page
	When User Navigates to UBS page
		And Cookie is added to hide popup and page is refreshed
		And User clicks Select domicile button in header and selects Europe as region and Germany as country
	Then User should be on de page with en language

@SmokeTests
Scenario: User changes page language to DE
	When User Navigates to UBS page
		And Cookie is added to hide popup and page is refreshed
	Then Main section headers should be
		| SectionTitle                               |
		| UBS financial results                      |
		| What's next?                               |
		| Business unusual                           |
		| The world after COVID-19                   |
		| Our capabilities                           |
		| Who? What? Where?                          |
		| Investment views and financial market data |
		| About us                                   |
	When User clicks language code in header to change to DE language
	Then Main section headers should be
		| SectionTitle                          |
		| UBS-Finanzergebnisse                  |
		| Wie geht es weiter?                   |
		| Nichts bleibt beim Alten              |
		| Die Welt nach COVID-19                |
		| Globale Kompetenzen                   |
		| Wo überall auf der Welt?              |
		| Investment Views und Finanzmarktdaten |
		| Wir über uns                          |
