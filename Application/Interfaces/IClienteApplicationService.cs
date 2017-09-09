using Application.Input;
using Domain.Models;
using Domain.SharedKernel.Queries;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClienteApplicationService
    {
        Task<Cliente> Obter(int id);
        
        Task Adicionar(ClienteInput cliente);

        Task<PaginatedResults<Cliente>> ListarTodos(int paginaAtual, int totalPorPagina);

        Task<PaginatedResults<Cliente>> FiltrarPorNome(string nome, int paginaAtual, int totalPorPagina);

        Task Excluir(int id);

        Task Atualizar(int id, ClienteInput cliente);
    }
}
