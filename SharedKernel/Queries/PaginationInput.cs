using Domain.SharedKernel.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SharedKernel.Queries
{
    public sealed class PaginationInput
    {
        public PaginationInput(int currentPage, int recordsPerPage)
        {
            new Guard()
                .GreaterThan("currentPage", currentPage, 0)
                .GreaterThan("recordsPerPage", recordsPerPage, 0)
                .Validate();

            CurrentPage = currentPage;
            RecordsPerPage = recordsPerPage;
        }
        public int CurrentPage { get; private set; }
        public int RecordsPerPage { get; private set; }
        public int RecordsToSkip => (CurrentPage - 1) * RecordsPerPage;
    }
}
