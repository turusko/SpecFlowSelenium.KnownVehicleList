@Permit
@ChargePage
Feature: User is able to review how much they wll be charged per displayed

    User is able to review how much their daily charge is including if they have discounts or exempt

    
        Scenario Outline: Vehicle charge amount is returned
            Given user look up <vrm>
             When user proceeds to charge page
             Then the charge of the vehicle is £<charge>
              And Charge Name is <name>

        Examples:vehilces
                  | vrm     | charge | name          |
                  | T2OMF   | 10     | Default       |
                  | GE19BXJ | 0      | zero emission |


