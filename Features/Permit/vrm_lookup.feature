@Permit
@VrmLookup
Feature: User is able to lookup VRM
      
      User is able to perform a lookup on their vehicle and confirm that their vehicle has been found

        
        @tc:12728
        Scenario Outline: Vehicle lookup returns correct make and colour
             When user look up <vrm>
             Then vehicle colour is displayed as <colour>
              And vehicle make is displayed as <make>

        Examples: vehicles
                  | vrm   | colour | make   |
                  | t2omf | black  | jaguar |
                  | taw1  | silver | mini   |

