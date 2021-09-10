using System;

namespace ProductApp.BLL.Models
{
    public class PageDomain
    {
        public int PageNumber { get; private set; }
        public int TotalPages { get; private set; }

        public PageDomain(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public bool HasPreviousPage => (PageNumber > 1);

        public bool HasNextPage => (PageNumber < TotalPages);
    }
}