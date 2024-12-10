using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
         {
            new ApiResource("ResourceCatalog")
            {
                Scopes = {"CatalogFullPermission","CatalogReadPermission"}
            },
            new ApiResource("ResourceDiscount")
            {
                Scopes = {"DiscountFullPermission","DiscountReadPermission"}
            },
            new ApiResource("ResourceOrder")
            {
                Scopes = {"OrderFullPermission","OrderReadPermission"}
            }
         };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
         {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
         };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission", "Full permission to catalog API"),
            new ApiScope("CatalogReadPermission", "Read permission to catalog API"),
            new ApiScope("DiscountFullPermission", "Full permission to discount API"),
            new ApiScope("DiscountReadPermission", "Read permission to discount API"),
            new ApiScope("OrderFullPermission", "Full permission to order API"),
            new ApiScope("OrderReadPermission", "Read permission to order API")
        };


        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client
            {
                ClientId = "MultiShopVisitorId",
                ClientName = "Multi Shop Visitor User",
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = {"CatalogReadPermission"}
            },

            //Manager
            new Client
            {
                ClientId = "MultiShopManagerId",
                ClientName = "Multi Shop Manager",
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = {"DiscountFullPermission", "CatalogFullPermission" }
            },

            //Admin
            new Client
            {
                ClientId = "MultiShopAdminId",
                ClientName = "Multi Shop Admin User",
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes =
                {
                    "OrderFullPermission", "DiscountFullPermission", "CatalogFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime = 600
            }
        };
    }
}