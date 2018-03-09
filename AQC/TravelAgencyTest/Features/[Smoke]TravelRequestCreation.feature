Feature: TravelRequestCreation

Background: User Login into Travel Homepage
	Given User go to Travel Agency Create Page
	#When User Login with username and password
	Then User should see Welcome message on create page

@Regression @Smoke
Scenario: Traveller can quickly create Travel request
	Given User go to Travel Agency Create Page
	And User fake authen as "Dinh Xuan Loc" in Create Page
	When Traveller select traveller "Dinh Xuan Loc"
	And Traveller select main transportation as "plane" 
	And Traveller select other services as CarRental
	And Traveller select other services as Taxi
	And Traveller select other services as Hotel
	And Traveller fill Start Date as today + 5 and End Date as today + 10
	And Traveller fill From Field "Singapore" and To Field "Ho Chi Minh"
	And Traveller select I'm in a hurry button
	Then Traveller should see Success request creation message with requestID

@Regression @Smoke
Scenario: Traveller can create Travel request with details
	Given User go to Travel Agency Create Page
	And User fake authen as "Dinh Xuan Loc" in Create Page
	When Traveller select main transportation as "plane" 
	And Traveller select other services as CarRental
	And Traveller select other services as Taxi
	And Traveller select other services as Hotel
	And Traveller fill Start Date as today + 5 and End Date as today + 10
	And Traveller fill From Field "Geneva" and To Field "Hong Kong"
	And Traveller select Continue button 
	And Traveller fill Trip detail: Flight from "Australia", to "Ho Chi Minh", outbound  as today + 5 and return as today + 10
	When Traveller fill Trip detail: Hotel location "Australia", check in date as today + 5, check out date as today + 10
	And Traveller fill Trip detail: Taxi detail
	And Traveller fill Trip detail: Car Rental with pick-up "Australia", drop-off "Ho Chi Minh", outbound date as today + 5 and return as today + 10
	And Traveller select Finish button
	#Then Traveller should see Success request creation message with requestID

