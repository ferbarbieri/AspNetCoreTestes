using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SharedKernel.Queries
{
    public sealed class PaginatedResults<T> where T:class
    {
        public int TotalRecords { get; private set; }
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int RecordsPerPage { get; private set; }

        public IList<T> Results { get; private set; }

        public PaginatedResults(IList<T> results, int totalRecords, int currentPage, int recordsPerPage)
        {
            Results = results;
            CurrentPage = currentPage;
            TotalRecords = totalRecords;
            RecordsPerPage = recordsPerPage;
            TotalPages = (int)Math.Ceiling((double)TotalRecords / RecordsPerPage);
        }
    }
}
