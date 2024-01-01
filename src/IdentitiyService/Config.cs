using Duende.IdentityServer.Models;
using static Duende.IdentityServer.Models.IdentityResources;

namespace IdentitiyService1
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("scope1"),
                new ApiScope("scope2"),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "m2m.client",
                    ClientName = "Client Credentials Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("testcat") },

                    AllowedScopes = { "scope1" }
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("testcat") },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "https://localhost:8081/identity/signin-oidc", "http://127.0.0.1/sample-wpf-app" },
                    FrontChannelLogoutUri = "https://localhost:8081/identity/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:8081/identity/signout-callback-oidc", "http://127.0.0.1/sample-wpf-app" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "qmedia.api", "offline_access" }
                },

                 // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "interactive.public",
                    ClientName = "Interactive client (Code with PKCE)",

                    RedirectUris = { "http://127.0.0.1/sample-wpf-app" },
                    PostLogoutRedirectUris = { "http://127.0.0.1/sample-wpf-app" },

                    RequireClientSecret = false,

                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes = { "openid", "profile", "offline_access", "email", "api", "api.scope1", "api.scope2", "scope2" },

                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    RefreshTokenExpiration = TokenExpiration.Sliding
                },
            };
    }
}
