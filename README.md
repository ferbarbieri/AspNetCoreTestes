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

- Update-Database -Context AdminContext
- Update-Database -Context LojaContext
- Update-Database -Context TenantManagementContext

## Importante

Deve existir um database central, que controla os Tenants, essa database também conterá os dados comuns utilizados para todos os tenants, informações de cobrança do sistema, notícias, etc.

Cada cliente deverá possuir uma database separada com o nome do dominio, por exemplo:
viceri.com.br
bazooca.com.br

Assim, após executar as migrations, deve-se duplicar o banco de dados manualmente para que cada cliente possa fazer login e utilizar as informações do seu proprio banco de dados.
Esse processo será automatizado futuramente atravez de um JOB quando o cliente se registrar na aplicação.
