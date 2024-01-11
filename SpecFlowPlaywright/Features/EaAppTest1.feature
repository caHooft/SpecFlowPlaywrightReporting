Feature: EAEAppTest1

    @smoke
    Scenario: Test Login operation of EA Application1
        Given I navigate to appliacation
        And I click login link
        And I enter following login details
          | UserName | Password |
          | admin    | slkdfjsdlkjf |
        Then I see Employee Lists