using Application.ViewModels;
using AutoMapper;
using Domain.Models;
using Domain.SharedKernel.Queries;

namespace Application.Mappings
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            //Adicionar todos os mapeamentos aqui.
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<PaginatedResults<Usuario>, PaginatedResults<UsuarioViewModel>>();
        }
    }
}
