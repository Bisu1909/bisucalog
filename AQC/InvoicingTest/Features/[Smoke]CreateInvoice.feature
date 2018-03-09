Feature: CreateInvoice


@Smoke @119815
Scenario: Users can manually create T&M invoice from Invoicing application and validate it
	Given User go to Manage page
	When User fake authen as "BANDHOO Noushria"
	And User select on create invoice button
	Then User should see create new invoice pop up
	Given User input project ID as "14413", select invoice period month as "Jan", year as "2018"
	Then User should see create new invoice pop up is extented with extra information
	Given User select PExt information
	And User click on Create button
	Then User should be redirected to Edition page
	Given User click on Regenerate with Project button
	Then User should see attention pop up
	Given User select Regenerate button on pop up
	And User select Client Code
	And User update Description as "Automation Test"
	And User update NbUnit information as "1" 
	And User select Bank Information
	Then User should see Validate Invoice button
	And User should see invoice status as "Pending On Accounting Validation"
	Given User click on Validate Invoice button
	Then User should see message on Edition page: "This invoice has been sent for validation to the Manager."
	And User should see invoice status as "Pending On Manager Validation"
	Given User fake authen as Manager of Invoice
	When User click on Validate Invoice button
	Then User should see invoice status as "To Send"
	Given User go to Manage page
	When User fake authen as "BANDHOO Noushria"
	And User expanded Advance Search section
	And User input Invoice ID into Search Query
	And User select Search button
	Then User should see search result
	Given User perform send invoice 
	Then User should see Invoice To Send pop up
	Given User select Send button on Invoice To Send pop up
	Then User should see message on manage page: "The invoices have been sent successfully."
		

@Smoke @119841
Scenario: Users can create Rebate credit note for a project T&M
	Given User go to Manage page
	When User fake authen as "BANDHOO Noushria"
	And User select Create Credit Note button
	Then User should see Generate Credit Note pop-up
	Given User select Reason as "Rebate" on Generate Credit Note pop-up
	Then User should see Generate Credit Note pop up is extented with extra information
	Given User fill in generate credit note project ID as "14406" and select project extension 
	And select period month as "Jan", year as "2018"
	And User select on Generate Credit Note button
	Then User should be redirected to Edition page
	Given User click on Regenerate with Project button
	Then User should see attention pop up
	Given User select Regenerate button on pop up
	And User Create new Rebate Item
	And User select Bank Information
	Then User should see Validate Invoice button
	And User should see invoice status as "Pending On Accounting Validation"
	Given User click on Validate Invoice button
	Then User should see message on Edition page: "This invoice has been sent for validation to the Manager."
	And User should see invoice status as "Pending On Manager Validation"
	Given User fake authen as Manager of Invoice
	When User click on Validate Invoice button
	Then User should see invoice status as "To Send"
	Given User go to Manage page
	When User fake authen as "BANDHOO Noushria"
	And User expanded Advance Search section
	And User input Invoice ID into Search Query
	And User select Search button
	Then User should see search result
	Given User perform send invoice 
	Then User should see Invoice To Send pop up
	Given User select Send button on Invoice To Send pop up
	Then User should see message on manage page: "The invoices have been sent successfully."


@Smoke @119857
Scenario: Verify that User can create credit note for Sent/To Send invoice
	Given User go to Manage page
	When User fake authen as "BANDHOO Noushria"
	And User expanded Advance Search section
	And User input "AMABCN" into Company
	And User select Status as "Sent"
	And User select Search button
	Then User should see search result
	Given User perform edit first invoice
	And User navigate to new opened tab
	And User change Consultant Format to "Empty"
	And User note the Invoice ID and info of invoice's items
	And User navigate back to first tab
	Given User go to Manage page
	When User fake authen as "BANDHOO Noushria"
	And User select Create Credit Note button
	Then User should see Generate Credit Note pop-up
	Given User select Reason as "Client Refused" on Generate Credit Note pop-up
	Then User should see Generate Credit Note pop up is extented with extra information
	Given User fill in generate credit note pop up: invoice ID with company specified as "AMABCN"
	And select period month as "Jan", year as "2018"
	And User select on Generate Credit Note button
	Then User should be redirected to Edition page
	Given User change Consultant Format to "Empty"
	Then User should see Text Item is auto-generated
	And User should see Item list is coppied from the sent invoice
	
	

	