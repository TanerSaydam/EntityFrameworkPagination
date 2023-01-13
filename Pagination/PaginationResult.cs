namespace EntityFrameworkPagination.Pagination
{
    public class PaginationResult<T>
    {
        public PaginationResult(IList<T> datas,int pageNumber, int pageSize, int totalCount)
        {
            Datas = datas;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            IsFirstPage = PageNumber == 1;
            IsLastPage = PageNumber == TotalPages;
        }
        public IList<T> Datas { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }
    }
}
