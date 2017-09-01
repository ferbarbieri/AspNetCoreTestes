using Domain.Models;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class UsuarioCriadoEvent : IDomainEvent
    {
        public Usuario Usuario { get; set; }

        public UsuarioCriadoEvent(Usuario usuario)
        {
            Usuario = usuario;
        }
    }
}
