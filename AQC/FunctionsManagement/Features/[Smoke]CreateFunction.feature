Feature: CreateFunction

@Smoke @CreateFunction
Scenario: User can create new function
	Given User go to Function Management page
	And User login with right auth
	When User fake authen as "Le Page Thomas"
	And User click on (+Function) button
	Then User should be redirected to new function page
	Given User is at New Function profile page
	When User click on General Information to expand info
	When User select Department name as "IT Quality Control"
	And User input new Function name as " Test Function21001"
	And User select Function type
	And User select Function Parent name as "QC Officer"
	And User input Short Definition as "Tested Short Definition abc"
	And User input Responsibility as "Response test zyx"
	And User select Focus
	And User click on (Create as Validated) button
	Then User should be redirected to Function Management page

@Smoke @ValidateCreatingFunction
Scenario: User can validate that function is created successfully
	Given User go to Function Management page
	And User login with right auth
	When User fake authen as "Le Page Thomas"
	And User search function "Function21001"
	Then New Function "Function21001" is created successfully

@Smoke @EditFunction
Scenario: User can edit Function
	Given User go to Function Management page
	And User login with right auth
	When User fake authen as "Le Page Thomas"
	And User search function "Test Function21001"
	And User open profile page of function "Test Function21001"
	Then User should be redirected to function profile page of function "Test Function21001"
	Given User is at "Test Function21001" Function profile page
	When User click on General Information to expand info
	And User input "123" to Function Title field
	And User clear and type text in Short Definition field as "Edit Short Definition 1"
	And User clear and type text in Responsibility field as "Response edit 1"
	And User click on (Create as Validated) button
	Then User should see the notification for editing successfully

@Smoke @ValidateEditingFunction
Scenario: User can validate that function is edited successfully
	Given User go to Function Management page
	And User login with right auth
	When User fake authen as "Le Page Thomas"
	And User search function "Test Function21123"
	And User open profile page of function "Test Function21123"
	Then User should be redirected to function profile page of function "Test Function21123"
	Given User is at "Test Function21123" Function profile page
	When User click on General Information to expand info
	Then User verify that Function Title field has changed to "Test Function21123"
	And User verify that Short Definition field has change to "Edit Short Definition 1"
	And User verify that Responsibility field has change to "Response edit 1"

