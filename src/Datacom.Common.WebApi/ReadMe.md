# common nuget packags solution

Solution for creating new nuget packages on the datacom midlands nuget server.
http://dslhlzdevsvr.midlands.net/guestAuth/app/nuget/v1/FeedService.svc/

##### Nuget-pack.bat 
generates the nuget package for each project in the bat script.

## Datacom.common

### Exceptions
For use with common exceptions 


### Search
contains objects that can implement basic paging and sorting on the server-side.

i.e. a search request has a filter model and the response would return a Result object.

There are IQueryable and IEnumerable extensions that help to sort and page results.

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

#### IEnumerable
##### Page(Filter filter)
page enumerable list using the filter object.

##### SortOrder(Filter filter)
sort enumerable list using the filter object.

##### SortOrder(FilterSort filtersort)
sort enumerable list using the filter sort object.

#### IQueryable

##### Page(Filter filter)

page IQueryable list using the filter object.

##### SortOrder(Filter filter)
sort IQueryable list using the filter object.

##### SortOrder(FilterSort filtersort)
sort IQueryable list using the filter sort object.