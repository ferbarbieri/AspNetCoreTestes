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
        
        Task<UsuarioViewModel> Adicionar(UsuarioInput input);

        Task Atualizar(int id, UsuarioInput input);

        Task Excluir(int id);
        
        Task<PaginatedResults<UsuarioViewModel>> ListarTodos(int paginaAtual, int totalPorPagina);

        Task<PaginatedResults<UsuarioViewModel>> FiltrarPorNome(string nome, int paginaAtual, int totalPorPagina);

    }
}
