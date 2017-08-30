# common nuget packags solution

Solution for creating new nuget packages on the datacom midlands nuget server.
http://dslhlzdevsvr.midlands.net/guestAuth/app/nuget/v1/FeedService.svc/

##### Nuget-pack.bat 
generates the nuget package for each project in the bat script.

## Datacom.common

### Exceptions
For use with common exceptions 


### Extensions
#### Strings
##### SplitBySemiColon()
sets a string to lowercase and splits it by semi-colon.
##### HasRepeatingCharacters()  
Check if all characters are the same i.e. 2222
##### IsNumber()    
Check if string is number.

#### Integers
##### HasSequentialDigits()
checks if the digits are sequential i.e. 1234
##### HasRepeatingDigits()
checks if the digits are repeating i.e. 2222