using Domain.Models;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class UsuarioAlterouEmailEvent : IDomainEvent
    {
        public Usuario Usuario { get; set; }

        public UsuarioAlterouEmailEvent(Usuario usuario)
        {
            Usuario = usuario;
        }
    }
}
