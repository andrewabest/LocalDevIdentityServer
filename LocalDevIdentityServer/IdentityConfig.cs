using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace DockerIdentityServer
{
    public static class IdentityConfig
    {
        private const string ApiResourceName = "api";

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource(ApiResourceName, "My Protected API")
            };
        }

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
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { ApiResourceName }
                },

                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { ApiResourceName }
                },

                new Client
                {
                    ClientId = "roclient.public",
                    ClientName = "roclient.public",
                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowOfflineAccess = true,
                    AllowedScopes = new List<string>
                    {
                        ApiResourceName,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                    }
                },
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "andrew",
                    Password = "password"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "tanya",
                    Password = "password"
                }
            };
        }
    }
}