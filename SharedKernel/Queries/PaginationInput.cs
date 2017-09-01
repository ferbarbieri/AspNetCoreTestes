using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SharedKernel.Queries
{
    public sealed class PaginationInput
    {
        public PaginationInput(int currentPage, int recordsPerPage)
        {
            CurrentPage = currentPage;
            RecordsPerPage = recordsPerPage;
        }
        public int CurrentPage { get; private set; }
        public int RecordsPerPage { get; private set; }
        public int RecordsToSkip => (CurrentPage - 1) * RecordsPerPage;
    }
}
