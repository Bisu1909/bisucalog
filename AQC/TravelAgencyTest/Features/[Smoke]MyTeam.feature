Feature: MyTeam

Background: User Login into My Team page
	Given User go to Travel Agency My Team Page
	#When User Login with username and password
	

@Smoke
Scenario: Traveller manager can approved request
	Given User go to Travel Agency My Team Page
	And User fake authen as "DELATTRE Olivier" in My team page
	When User select approve button on first request pending on my validation
	Then User should see request approved successfully message
	And User should see request status bar as "Approved"
	# for test data prep
	Given User select Undo validate button
	
	
