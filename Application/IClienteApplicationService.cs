using Domain.Models;
using Domain.RepositoryInterfaces;
using Domain.SharedKernel.Queries;
using System;
using System.Collections.Generic;

namespace Application
{
    public interface IClienteApplicationService
    {
        Cliente Obter(int id);
        
        void Adicionar(string nome);

        PaginatedResults<Cliente> ListarTodos(int paginaAtual, int totalPorPagina);

        PaginatedResults<Cliente> FiltrarPorNome(string nome, int paginaAtual, int itensPorPagina);

        void Excluir(int id);

        void Atualizar(int id, string novoNome);
    }
}
