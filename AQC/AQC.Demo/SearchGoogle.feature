Feature: Google search

  Scenario: Find SpecFlow technical concepts
	Given I go to http://www.google.com.vn 
      And I fill search with "Amaris" 
	 When I press search
	 Then I should see "Amaris International Consulting Company"
	