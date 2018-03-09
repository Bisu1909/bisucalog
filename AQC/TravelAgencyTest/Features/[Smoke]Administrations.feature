Feature: Administrations

Background: User Login into Travel price Guideline page
	Given User go to Travel Agency price Guideline page
	#When User Login with username and password	

@Smoke
Scenario: User can add and delete new Flight guideline
	Given User go to Travel Agency price Guideline page
	And User fake authen as "LAZAR Roxana" in price Guideline page
	When User select create new guideline button
	And User select service as "Flight" on create price guideline popup
	And User select from and to as "Geneva" and "Singapore"
	And User select "Business Class" Class
	And User fill Low price as "50", average price as "100", High price as "500"
	And User select Create button on create price guideline popup
	Then User should see success create price guideline message
	Given User search Flight from "Geneva" to "Singapore", class as "Business Class"
	And User delete guideline on page
	Then User should see success delete price guideline message
	
