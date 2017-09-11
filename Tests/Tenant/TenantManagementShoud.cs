using Domain.SharedKernel.Exceptions;
using Domain.SharedKernel.Validation;
using Infra.TenantGenerator;
using Xunit;

namespace Tests.Tenant
{
    public class TenantManagementShoud
    {
        [Trait("TenantManagement","")]
        [Theory]
        [InlineData("viceri.com.br")]
        [InlineData("bazooca.com.br")]
        public void CreateDatabaseForTenant(string tenantName)
        {
            var gen = new TenantDatabaseGenerator(tenantName);
            gen.GenerateTenantDatabase(true);
        }
        
    }
}
