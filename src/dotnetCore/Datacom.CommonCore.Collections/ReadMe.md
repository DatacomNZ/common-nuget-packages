# Datacom.CommonCore.Collections

Contains some common functionality for collections used in 
datacom midlands solutions.

#### Collection Types
1. PagedResult (base object for Paged Lists)
2. BaseSearchFilter (base object for search requests includes paging and sorting)

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