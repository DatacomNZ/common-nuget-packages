namespace Datacom.CommonCore.Collections
{
    /// <summary>
    /// Base filter object used for filter searches
    /// </summary>
    public class PagingFilter
    {
        public PagingFilter()
        {
            Take = 100;
            Page = 1;
        }
        
        public int Take { get; set; }
        public int Page { get; set; }
        public int Skip
        {
            get
            {
                return Take * (Page - 1);
            }
        }
    }
}
