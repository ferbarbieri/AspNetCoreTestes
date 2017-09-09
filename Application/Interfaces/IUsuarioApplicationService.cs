using Application.Input;
using Application.ViewModels;
using Domain.Models;
using Domain.SharedKernel.Queries;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUsuarioApplicationService
    {
        Task<UsuarioViewModel> Obter(int id);
        
        Task Adicionar(UsuarioInput input);

        Task Atualizar(int id, UsuarioInput input);

        Task Excluir(int id);
        
        Task<PaginatedResults<Usuario>> ListarTodos(int paginaAtual, int totalPorPagina);

        Task<PaginatedResults<Usuario>> FiltrarPorNome(string nome, int paginaAtual, int totalPorPagina);

    }
}
