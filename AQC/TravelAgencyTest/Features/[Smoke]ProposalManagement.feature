Feature: ProposalManagement

Background: User Login into Travel Handle request page
	Given User go to Travel Agency Handle Request Page
	#When User Login with username and password	

@Smoke
Scenario: User can create proposal details and send for traveller's validation 
	Given User go to Travel Agency Handle Request Page
	And User fake authen as "LAZAR Roxana" in Handle Request page
	And User select All tab
	Given User select view detail button on request has status "Approved"
	And User select manage proposals button on request detail page
	Then User shoud see request in status "Approved" in proposal Detail page
	Given User create flight proposal if required: Supplier "Amadeus", price "50", start date as today + 5, end date as today + 10
	Given User create Hotel proposal if required: Price "50", checkin as today + 5, checkout as today + 10
	Given User create Car rental proposal if required: Supplier "car", price "50", from "Singapore", to "Geneva", start date as today + 5, end date as today + 10
	Given User create Taxi proposal if required: Supplier "car", price "50", from "Singapore", to "Geneva", start date as today + 5, end date as today + 10
	Given User create Train proposal if required: Supplier "train", price "50", from "Singapore", to "Geneva", start date as today + 5, end date as today + 10
	And User select Send Proposal Email button
	Then User should see success send proposal message
	And User shoud see request in status "Proposal Submitted" in proposal Detail page

@Smoke	
Scenario: User can edit Booked request - Flight, Low additional cost
	Given User go to Travel Agency Handle Request Page
	And User fake authen as "LAZAR Roxana" in Handle Request page
	And User select All tab
	And User select Booked but unfinished requests progress bar 
	Given User select view detail on request has status "Booked", has flight proposal and start date not passed current date
	And User select manage proposals button on request detail page
	Then User shoud see request in status "Booked" in proposal Detail page
	Given User select Change button on Booked flight proposal
	When User fill Change reason, fill Additional cost as 2 on flight change proposal pop-up
	And User select Change proposal button
	Then User should see Success change request message
	And User shoud see request in status "Pending Change (Change Validated)" in proposal Detail page
	And User should see status "Pending Change (Change Validated)" on flight proposal
	And User should see status "Change Validated" on all flight segments
	When User select Create Proposal For Changes button
	Then User should see Success add transport proposal message
	And User should see status "New" on newly created flight proposal
	And User should see status "New" on newly created flight segments 
	Given User select Send Proposal Email button	
	Then User should see success send proposal message
	And User shoud see request in status "Pending Change (Proposal Submitted)" in proposal Detail page

	
	
