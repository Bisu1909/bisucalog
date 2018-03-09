Feature: MergeInvoice

@Smoke @135484
Scenario: Verify that only Pending On Accounting T&M invoices with same Client code can be merged
	Given User go to Manage page
	When User fake authen as "BANDHOO Noushria"
	And User select on create invoice button
	Then User should see create new invoice pop up
	Given User input project ID as "14413", select invoice period month as "Jan", year as "2018"
	Then User should see create new invoice pop up is extented with extra information
	Given User select PExt information
	And User click on Create button
	Then User should be redirected to Edition page
	And User note the Invoice ID and info of invoice's items
	Given User go to Manage page
	When User fake authen as "BANDHOO Noushria"
	And User select on create invoice button
	Then User should see create new invoice pop up
	Given User input project ID as "14413", select invoice period month as "Jan", year as "2018"
	Then User should see create new invoice pop up is extented with extra information
	Given User select PExt information
	And User click on Create button
	Then User should be redirected to Edition page
	And User note the Invoice ID and info of invoice's items
	Given User go to Manage page
	When User fake authen as "BANDHOO Noushria"
	And User select on create invoice button
	Then User should see create new invoice pop up
	Given User input project ID as "14413", select invoice period month as "Jan", year as "2018"
	Then User should see create new invoice pop up is extented with extra information
	Given User select PExt information
	And User click on Create button
	Then User should be redirected to Edition page
	And User note the Invoice ID and info of invoice's items
	Given User go to Manage page
	When User fake authen as "BANDHOO Noushria"
	And User expanded Advance Search section
	And User input project ID as "14413" into Search Query
	And User select Search button
	Then User should see search result
	Given User check on 3 newly created invoices
	And User select Merge Invoices button
	Then User should see Merging pop up with warning message is "none"
	Given User select Merge button on Merging pop up
	Then User should see message on manage page: "Invoices have been merged successfully."
	Given User go to Manage page
	When User fake authen as "BANDHOO Noushria"
	And User expanded Advance Search section
	And User input Invoice ID into Search Query
	And User select Search button
	Then User should see search result
	Given User perform edit first invoice
	And User navigate to new opened tab
	And User change Consultant Format to "Empty"
	Then User should see Item list is coppied from the merged invoice
	