using Application.Input;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Events;
using Domain.Models;
using Domain.RepositoryInterfaces;
using Domain.SharedKernel.Exceptions;
using Domain.SharedKernel.Queries;
using Domain.SharedKernel.Utils;
using SharedKernel;
using System;

namespace Application
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private IUsuarioRepository _repo { get; }

        private IMapper _mapper;

        public UsuarioApplicationService(
            IUsuarioRepository repo,
            IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        #region Queries

        public PaginatedResults<Usuario> ListarTodos(int paginaAtual, int totalPorPagina)
        {
            return _repo.GetAll(new PaginationInput(paginaAtual, totalPorPagina));
        }

        public PaginatedResults<Usuario> FiltrarPorNome(string nome, int paginaAtual, int totalPorPagina)
        {
            return _repo.GetAllBy(
                c=>c.Nome.StartsWith(nome),
                new PaginationInput(paginaAtual, totalPorPagina));
        }


        public UsuarioViewModel Obter(int id)
        {
            return _mapper.Map<UsuarioViewModel>(ObterUsuario(id));
        }

        #endregion

        #region Commands

        public void Adicionar(UsuarioInput input)
        {
            if(_repo.GetByEmail(input.Email) != null)
            {
                throw new FieldsValidationException("O Email informado já existe.");
            }

            var usuario = new Usuario(input.Nome, input.Email, input.Senha);
            _repo.Insert(usuario);

            var userEvent = new UsuarioCriadoEvent(usuario);

            DomainEvents.Raise(userEvent);
        }

        public Usuario Login(string email, string password)
        {
            var user = _repo.GetByEmail(email);

            // veririfica se a senha está ok
            if (user != null && PasswordHasher.Verify(password, user.Senha))
            {
                return user;
            }

            return null;
        }

        public void Excluir(int id)
        {
            _repo.Delete(ObterUsuario(id));
        }

        public void Atualizar(int id, UsuarioInput input)
        {
            var usuario = ObterUsuario(id);
            usuario.UpdateInfo(input.Nome, input.Email, input.Senha);
            _repo.Update(usuario);
        }

        #endregion
        
        private Usuario ObterUsuario(int id)
        {
            var usuario = _repo.GetById(id);
            if (usuario == null)
                throw new NotFoundException("Usuario não encontrado", id);

            return usuario;
        }
    }
}
