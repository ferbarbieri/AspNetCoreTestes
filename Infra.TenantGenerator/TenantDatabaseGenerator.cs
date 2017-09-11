using Domain.Models;
using Infra.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.TenantGenerator
{
    public class TenantDatabaseGenerator
    {
        private readonly AdminContext _adminContext;
        private readonly LojaContext _lojaContext;
        private readonly TenantManagementContext _tenantContext;

        private readonly string _tenantName;

        public TenantDatabaseGenerator(string tenantName)
        {
            if (string.IsNullOrEmpty(tenantName))
                throw new ArgumentException("TenantName deve ser informado", "tenantName");

            _tenantName = tenantName.Trim();

            var cnnString = $"Server = (localdb)\\mssqllocaldb; Database = {tenantName}; Trusted_Connection = True;";

            // Opções de criação
            var adminOptions = new DbContextOptionsBuilder<AdminContext>()
                .UseSqlServer(cnnString)
                .Options;

            var lojaOptions = new DbContextOptionsBuilder<LojaContext>()
                .UseSqlServer(cnnString)
                .Options;

            // Contextos
            _adminContext = new AdminContext(adminOptions);
            _lojaContext = new LojaContext(lojaOptions);


            // Inicializa o Contexto de Gerenciamento de Tenant
            var tenantCnnString = $"Server = (localdb)\\mssqllocaldb; Database = AspNetCoreTestes; Trusted_Connection = True;";
            var tenantOptions = new DbContextOptionsBuilder<TenantManagementContext>()
                .UseSqlServer(tenantCnnString)
                .Options;

            // Contextos
            _tenantContext = new TenantManagementContext(tenantOptions);
        }

        public void GenerateTenantDatabase(bool generateDemoData = false)
        {
            // Migrações
            _adminContext.Database.Migrate();
            _lojaContext.Database.Migrate();

            if (generateDemoData)
                SeedDemoData();
        }

        private void SeedDemoData()
        {
            SeedAdmin();
            SeedLoja();
        }

        private void SeedLoja()
        {
            // Não carrega se já existirem clientes nesse banco.
            if (_lojaContext.Clientes.Any())
                return;

            #region Clientes

            var maria = new Cliente("Maria");
            var joao = new Cliente("Joao");
            var fernando = new Cliente("Fernando");
            _lojaContext.Clientes.Add(maria);
            _lojaContext.Clientes.Add(joao);
            _lojaContext.Clientes.Add(fernando);

            #endregion

            #region Produtos

            var batedeira = new Produto("Batedeira", 80.54m);
            var liquidificador = new Produto("Liquidificador", 70.99m);
            var microondas = new Produto("Microondas", 250.5m);

            _lojaContext.Produto.Add(batedeira);
            _lojaContext.Produto.Add(liquidificador);
            _lojaContext.Produto.Add(microondas);

            #endregion

            #region Pedidos 

            var itensMaria = new List<ItensPedidoDTO> {
                new ItensPedidoDTO(batedeira, 2),
                new ItensPedidoDTO(liquidificador, 3)
            };
            var pedidoMaria = new Pedido(maria, itensMaria);

            var itensJoao = new List<ItensPedidoDTO> {
                new ItensPedidoDTO(batedeira, 2),
                new ItensPedidoDTO(microondas, 1)
            };
            var pedidoJoao = new Pedido(joao, itensJoao);

            var itensFernando = new List<ItensPedidoDTO> {
                new ItensPedidoDTO(microondas, 1)
            };
            var pedidoFernando = new Pedido(fernando, itensFernando);

            _lojaContext.Pedidos.Add(pedidoMaria);
            _lojaContext.Pedidos.Add(pedidoJoao);
            _lojaContext.Pedidos.Add(pedidoFernando);

            #endregion

            _lojaContext.SaveChanges();
        }

        private void SeedAdmin()
        {
            // Deve existir um registro do tenant no contexto de tenants
            if(!_tenantContext.Tenants.Any(c=>c.Dominio == _tenantName))
            {
                var tenant = new Tenant(_tenantName.Split('.')[0], _tenantName, "Admin", "admin@" + _tenantName);
                tenant.EmailConfirmado();

                _tenantContext.Tenants.Add(tenant);
                    
                _tenantContext.SaveChanges();
            }

            // Se já tiver algum registro na tabela de usuario, vou considerar que os dados já foram carregados.
            if (_adminContext.Usuarios.Any())
                return;

            // Deve existir um usuário administrador
            var usuario = new Usuario("Admin", "admin@" + _tenantName, "12345678");
            usuario.PromoverParaAdministrador();
            _adminContext.Usuarios.Add(usuario);

            // Cria dois usuarios comuns:
            var maria = new Usuario("Maria", "maria@" + _tenantName, "12345678");
            var fernando = new Usuario("Fernando", "fernando@" + _tenantName, "12345678");
            _adminContext.Usuarios.Add(maria);
            _adminContext.Usuarios.Add(fernando);

            // Salva tudo em uma transação
            _adminContext.SaveChanges();
        }
    }
}
