﻿using Application.Input;
using Domain.Models;
using Domain.RepositoryInterfaces;
using Domain.SharedKernel.Queries;
using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IClienteApplicationService
    {
        Cliente Obter(int id);
        
        void Adicionar(ClienteInput cliente);

        PaginatedResults<Cliente> ListarTodos(int paginaAtual, int totalPorPagina);

        PaginatedResults<Cliente> FiltrarPorNome(string nome, int paginaAtual, int totalPorPagina);

        void Excluir(int id);

        void Atualizar(int id, ClienteInput cliente);
    }
}