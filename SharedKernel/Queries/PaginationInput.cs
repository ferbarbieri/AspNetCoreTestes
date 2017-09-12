using Domain.SharedKernel.Validation;

namespace Domain.SharedKernel.Queries
{
    public sealed class PaginationInput
    {
        public PaginationInput(int currentPage, int recordsPerPage)
        {
            new Guard()
                .GreaterThan("Pagina", currentPage, 0)
                .GreaterThan("PorPagina", recordsPerPage, 0)
                .Validate();

            CurrentPage = currentPage;
            RecordsPerPage = recordsPerPage;
        }
        public int CurrentPage { get; private set; }
        public int RecordsPerPage { get; private set; }
        public int RecordsToSkip => (CurrentPage - 1) * RecordsPerPage;
    }
}
