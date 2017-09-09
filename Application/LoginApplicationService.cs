using Application.Interfaces;
using Domain.Enums;
using Domain.Models;
using Domain.RepositoryInterfaces;
using Domain.SharedKernel.Utils;
using Infra.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repositories;
using System.Threading.Tasks;

namespace Application
{
    /// <summary>
    /// Serviço para realizar o login.
    /// Obs: Devido ao modelo de tenant e a construção do admincontext, 
    /// essa classe talvez precise ser repensada para remover as dependencias com o entity framework
    /// </summary>
    public class LoginApplicationService : ILoginApplicationService
    {
        private IConfigurationRoot _config;
        private readonly ITenantRepository _tenantRepository;

        public LoginApplicationService(
            IConfigurationRoot config, 
            ITenantRepository tenantRepository)
        {
            _config = config;
            _tenantRepository = tenantRepository;
        }

        /// <summary>
        /// Faz o login do usuario
        /// Caso especial: nesse momento não temos connection string configurada.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<Usuario> Login(string email, string password)
        {

            var dominio = email.Split('@')[1];
            // Valida se o dominio está presenta na lista de tenants do sistema, e se o tenant está ativo.
            var tenant = await _tenantRepository.ObterPeloDominio(dominio);
            if(tenant == null 
                || tenant.Status == TenantStatus.Bloqueado 
                || tenant.Status == TenantStatus.AguardandoConfirmacaoRegistro)
            {
                return null;
            }

            #region Construção do repositorio
            // construção do repositorio manualmente:
            // OBS: Isso está criandoo uma dependencia do servico diretamente para o EF e com as
            // implementações concretas do repositorio. Não pode ser assim. Pensar em uma maneira melhor
            // quando for utilizar em produção.
            var cnn = _config.GetConnectionString("Tenant");
            cnn = cnn.Replace("{tenant}", dominio);
            
            var builder = new DbContextOptionsBuilder<AdminContext>();
            builder.UseSqlServer(cnn);
            var ctx = new AdminContext(builder.Options);

            var repo = new UsuarioRepository(ctx);
            #endregion


            var user = await repo.GetByEmail(email);

            // veririfica se a senha está ok
            if (user != null && PasswordHasher.Verify(password, user.Senha))
            {
                return user;
            }

            return null;
        }

    }
}
