using Application.ViewModels;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
