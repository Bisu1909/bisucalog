Feature: BookingV2

Background: User Login into Travel Handle request page
	Given User go to Travel Agency Handle Request Page
	#When User Login with username and password	

@Smoke
Scenario: User can save booking info on Proposal Accepted request
	Given User go to Travel Agency Handle Request Page
	And User fake authen as "LAZAR Roxana" in Handle Request pages
	When User select All tab
	And User select price button on request with status "Proposal Accepted"
	And User fill all booking form info
	And User select Save Draft button
	#And User select Send Booking Information button
	#And User should see request status as "Booked Pending on Supplier"
	
