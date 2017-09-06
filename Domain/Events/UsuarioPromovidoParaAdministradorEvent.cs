﻿using Domain.Models;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class UsuarioPromovidoParaAdministradorEvent : IDomainEvent
    {
        public Usuario Usuario { get; set; }

        public UsuarioPromovidoParaAdministradorEvent(Usuario usuario)
        {
            Usuario = usuario;
        }
    }
}