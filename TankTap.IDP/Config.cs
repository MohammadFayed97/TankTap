using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace TankTap.IDP;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        { 
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            { };

    public static IEnumerable<Client> Clients =>
        new Client[] 
            {
                new Client
                {
                    ClientName = "TankTap-Vue-App",
                    ClientId = "tanktapvueapp",
                    ClientSecrets =
                    [
                        new Secret("secret".Sha256())
                    ],
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes =
                    [
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                    ],
                    RedirectUris = 
                    [
                        "https://localhost:5173/",
                        "https://localhost:5173/callback.html",
                        "https://localhost:5173/silent-renew.html"
                    ],
                    AllowedCorsOrigins = ["https://localhost:5173"],
                    RequireConsent = true,
                }
            };
}