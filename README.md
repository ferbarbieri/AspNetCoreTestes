# AspNetCoreTestes

Projeto de demonstração de utilização com o .Net Core 2.

Utiliza:
- DDD
- Simple Injector
- XUnit
- Asp.Net Core 2.0
- Entity Framework Core 2.0
- Web API
- Angular 4
- Multi-tenancy separado em uma database por cliente

## Inicialização do banco de dados:

Para inicializar o projeto, executar no Package Manager:

- Update-Database -Context TenantManagementContext

## Importante

Cada cliente deverá possuir uma database separada com o nome do dominio, por exemplo:
viceri.com.br
bazooca.com.br

O projeto de testes possui um teste _TenantManagementShoud.CreateDatabaseForTenant_
Executar esse teste vai criar os databases por cliente e popular com dados de exemplo.

Após isso, rodar o projeto WebApi. Deverá abrir a documentação do Swagger onde pode-se testar tudo.

Usuarios de exemplo:

admin@bazooca.com.br -> administrador do tenant bazooca
admin@viceri.com.br -> administrado do tenant viceri

senhas: 12345678
