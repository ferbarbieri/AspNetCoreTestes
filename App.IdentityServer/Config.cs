using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.IdentityServer
{
    public class Config
    {
        // scopes define the API resources in your system
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("DemoWebApi", "Demo Web Api")
            };
        }

        // client want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("IdentityWebApiSecret".Sha256())
                    },
                    AllowedScopes = { "DemoWebApi" }
                }
            };
        }
    }
}
