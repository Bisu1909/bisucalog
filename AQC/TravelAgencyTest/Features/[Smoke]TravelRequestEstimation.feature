Feature: TravelRequestEstimation

Background: User Login into Travel Homepage
	Given User go to Travel Agency Create Page
	#When User Login with username and password
	Then User should see Welcome message on create page

@Smoke
Scenario: Travel allocator can estimate price for travel request
	Given User go to Travel Agency Handle Request Page
	When User fake authen as "Lazar Roxana" in HandleRequest Page
	And User select All tab
	When User select estimate price button on request with "Requested" status
	And User input price as "50" currency as "EUR" for all trip
	And User select Save and Validate button on price pop-up
	Then User should see success estimation message	