namespace Datacom.CommonCore.Collections
{
    public class BaseSearchFilter
    {
        public BaseSearchFilter()
        {
            Pagination = new PagingFilter();
            Sort = new SortFilter();
        }
        public PagingFilter Pagination { get; set; }
        public SortFilter Sort { get; set; }
    }
}
