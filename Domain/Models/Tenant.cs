using Domain.Enums;
using Domain.SharedKernel.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Tenant : Entity
    {
        public string Nome { get; private set; }
        public string Dominio { get; private set; }
        public TenantStatus Status { get; private set; }
        public TenantType Tipo { get; private set; }
        public string NomeAdministrador { get; private set; }
        public string EmailAdministrador { get; private set; }

        private Tenant()
        {
        }

        public Tenant(string nome, string dominio, string nomeAdministrador, string emailAdministrador)
        {
            new Guard()
                .NotNullOrEmpty("Nome", nome)
                .NotNullOrEmpty("Dominio", dominio)
                .NotNullOrEmpty("Nome do Administrador", nomeAdministrador)
                .ValidEmail("Email do Administrador", emailAdministrador)
                .Validate();

            Nome = nome;
            Dominio = dominio;
            Status = TenantStatus.AguardandoConfirmacaoRegistro;
            Tipo = TenantType.Normal;
            NomeAdministrador = nomeAdministrador;
            EmailAdministrador = emailAdministrador;
        }

        public void AlterarAdministrador(string nome, string email)
        {
            new Guard()
                .NotNullOrEmpty("Nome", nome)
                .ValidEmail("Email", email)
                .Validate();

            NomeAdministrador = nome;
            EmailAdministrador = email;
        }

        public void AlterarPlano(TenantType tipo)
        {
            Tipo = tipo;
        }

        public void Bloquear()
        {
            Status = TenantStatus.Bloqueado;
        }

        public void Desbloquear()
        {
            Status = TenantStatus.Ativo;
        }

        public void EmailConfirmado()
        {
            Status = TenantStatus.Ativo;
        }
    }
}
