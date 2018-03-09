Feature: TravelRequestAllocation

Background: User Login into Travel Homepage
	Given User go to Travel Agency Create Page
	#When User Login with username and password
	Then User should see Welcome message on create page

@Smoke
Scenario: Travel allocator can allocated travel request
	Given User go to Travel Agency Handle Request Page
	When User fake authen as "LAZAR Roxana" in HandleRequest Page
	Then User should see Pending On Allocation tab
	Given User allocate new request to "LAZAR Roxana"
	Then User should see success allocated message with requestID


