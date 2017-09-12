using Application.Input;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Events;
using Domain.Models;
using Domain.RepositoryInterfaces;
using Domain.SharedKernel.Exceptions;
using Domain.SharedKernel.Queries;
using Microsoft.Extensions.Configuration;
using SharedKernel;
using System.Threading.Tasks;

namespace Application
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private IUsuarioRepository _repo { get; }

        private readonly IMapper _mapper;
        private readonly IConfigurationRoot _config;
        private readonly UserInfo _userInfo;

        public UsuarioApplicationService(
            IUsuarioRepository repo,
            IMapper mapper,
            IConfigurationRoot config,
            UserInfo userInfo)
        {
            _repo = repo;
            _mapper = mapper;
            _config = config;
            _userInfo = userInfo;
        }

        #region Queries

        public async Task<PaginatedResults<UsuarioViewModel>> ListarTodos(int paginaAtual, int totalPorPagina)
        {
            return _mapper.Map<PaginatedResults<UsuarioViewModel>>(
                await _repo.GetAll(new PaginationInput(paginaAtual, totalPorPagina)));
        }

        public async Task<PaginatedResults<UsuarioViewModel>> FiltrarPorNome(string nome, int paginaAtual, int totalPorPagina)
        {
            return _mapper.Map<PaginatedResults<UsuarioViewModel>>(
                await _repo.GetAllBy(c=>c.Nome.StartsWith(nome), new PaginationInput(paginaAtual, totalPorPagina)));
        }
        
        public async Task<UsuarioViewModel> Obter(int id)
        {
            return _mapper.Map<UsuarioViewModel>(
                await ObterUsuario(id));
        }

        #endregion

        #region Commands

        public async Task<UsuarioViewModel> Adicionar(UsuarioInput input)
        {
            if(input.Email.Split('@')[1] != _userInfo.Tenant)
            {
                throw new FieldsValidationException($"O Email informado não pertence ao domínio ({_userInfo.Tenant}).");
            }

            if(await _repo.GetByEmail(input.Email) != null)
            {
                throw new FieldsValidationException("O Email informado já existe.");
            }

            var usuario = new Usuario(input.Nome, input.Email, input.Senha);
            await _repo.Insert(usuario);

            var userEvent = new UsuarioCriadoEvent(usuario);

            DomainEvents.Raise(userEvent);
            return _mapper.Map<UsuarioViewModel>(usuario);
        }
        
        public async Task Excluir(int id)
        {
            await _repo.Delete(await ObterUsuario(id));
        }

        public async Task Atualizar(int id, UsuarioInput input)
        {
            var usuario = await ObterUsuario(id);
            usuario.UpdateInfo(input.Nome, input.Email, input.Senha);
            await _repo.Update(usuario);
        }

        #endregion
        
        private async Task<Usuario> ObterUsuario(int id)
        {
            var usuario = await _repo.GetById(id);
            if (usuario == null)
                throw new NotFoundException("Usuario não encontrado", id);

            return usuario;
        }
    }
}
