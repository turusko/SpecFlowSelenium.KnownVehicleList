@Permit
@Scheduler
Feature: Scheduler

    User is able to select dates for a permit using the Scheduler

        @tc:12727
        Scenario: User can select a permit for today
            Given I am to select todays date by default
             When i select the plus icon
             Then the date is added to my basket
             
            
