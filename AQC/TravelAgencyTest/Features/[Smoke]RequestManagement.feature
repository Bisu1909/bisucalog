Feature: RequestManagement

Background: User Login into Travel Handle request page
	Given User go to Travel Agency Handle Request page
	#When User Login with username and password	

@Smoke
Scenario: Traveller select and submit travel option 
	Given User go to Travel Agency Handle Request page
	And User fake authen as "LAZAR Roxana" on Handle Request page
	And User select All tab
	And User select Request pending on traveller/manager progress bar 
	Given User select view detail button on request has status "Proposal Submitted"
	And User fake authen as Traveller
	When User select options for Flight if required
	And User select options for Train if required
	And User select options for Taxi if required
	And User select options for Car Rental if required
	And User select options for Hotel required
	Given User select Submit selection button
	Then User should see Success update proposal message
	And Request status should be "Proposal Accepted"

