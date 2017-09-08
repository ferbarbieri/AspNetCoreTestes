using Application.Input;
using Application.ViewModels;
using Domain.Models;
using Domain.SharedKernel.Queries;

namespace Application.Interfaces
{
    public interface IUsuarioApplicationService
    {
        UsuarioViewModel Obter(int id);
        
        void Adicionar(UsuarioInput input);

        void Atualizar(int id, UsuarioInput input);

        void Excluir(int id);
        
        PaginatedResults<Usuario> ListarTodos(int paginaAtual, int totalPorPagina);

        PaginatedResults<Usuario> FiltrarPorNome(string nome, int paginaAtual, int totalPorPagina);

    }
}
