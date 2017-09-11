using Domain.SharedKernel.Validation;
using System;

namespace Infra.TenantGenerator.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando a criação de tenants");
            Console.WriteLine("==============================");
            Console.WriteLine("");
            Console.Write("Insira o nome do Tenant (dominio): ");
            var tenant = "";
            do
            {
                tenant = Console.ReadLine();

                if (!new Guard().ValidDomain("Dominio", tenant).Check())
                {
                    Console.Write("Domínio inválido. Tente novamente (deixe em branco para sair) :");
                    continue;
                }

                try
                {
                    new TenantDatabaseGenerator(tenant).GenerateTenantDatabase(true);
                    Console.WriteLine("Executado com sucesso");
                    break;
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            } while (string.Empty != tenant);

            Console.WriteLine("Fim do processo. Pressione uma tecla para continuar...");
            Console.ReadLine();


        }
    }
}
