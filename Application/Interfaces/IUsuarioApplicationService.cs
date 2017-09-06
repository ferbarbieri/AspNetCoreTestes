using Application.Input;
using Application.ViewModels;
using Domain.Models;
using Domain.RepositoryInterfaces;
using Domain.SharedKernel.Queries;
using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IUsuarioApplicationService
    {
        UsuarioViewModel Obter(int id);
        
        void Adicionar(UsuarioInput input);

        void Atualizar(int id, UsuarioInput input);

        void Excluir(int id);

        Usuario Login(string email, string password);

        PaginatedResults<Usuario> ListarTodos(int paginaAtual, int totalPorPagina);

        PaginatedResults<Usuario> FiltrarPorNome(string nome, int paginaAtual, int totalPorPagina);

    }
}
