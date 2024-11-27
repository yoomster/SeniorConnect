# Invariants 


## User 
- An user cannot register with an email that is already registered


## Activity invariants
- An activity cannot contain more than the maximum number of participants
- A reservation cannot be canceled for free less than 24 hours before the session starts


## Location invariants
- A location cannot have two or more overlapping activities


## Activity coordinator invariants
- An activity coordinator cannot host two or more overlapping activities


## Participant
- A participant cannot reserve overlapping activities