using Application.ViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappings
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            //Adicionar todos os mapeamentos aqui.
            CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}
