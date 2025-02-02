﻿using IdentityServer4.Models;
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
            },
            new ApiResource("ResourceCargo")
            {
                Scopes = {"CargoFullPermission","CargoReadPermission"}
            },
            new ApiResource("ResourceBasket")
            {
                Scopes = {"BasketFullPermission","BasketReadPermission"}
            },
            new ApiResource("ResourceComment")
            {
                Scopes = {"CommentFullPermission","CommentReadPermission"}
            },            
            new ApiResource("ResourcePayment")
            {
                Scopes = { "PaymentFullPermission", "PaymentReadPermission" }
            },           
            new ApiResource("ResourceImages")
            {
                Scopes = { "ImagesFullPermission", "ImagesReadPermission" }
            },
            new ApiResource("ResourceOcelot")
            {
                Scopes = { "OcelotFullPermission", "OcelotReadPermission" }
            }, 
            new ApiResource("ResourceMessage")
            {
                Scopes = { "MessageFullPermission", "MessageReadPermission" }
            },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
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
            new ApiScope("OrderReadPermission", "Read permission to order API"),
            new ApiScope("CargoFullPermission", "Full permission to cargo API"),
            new ApiScope("CargoReadPermission", "Read permission to cargo API"),
            new ApiScope("BasketFullPermission", "Full permission to basket API"),
            new ApiScope("BasketReadPermission", "Read permission to basket API"),
            new ApiScope("CommentFullPermission", "Full permission to comment API"),
            new ApiScope("CommentReadPermission", "Read permission to comment API"),            
            new ApiScope("PaymentFullPermission", "Full permission to payment API"),
            new ApiScope("PaymentReadPermission", "Read permission to payment API"),            
            new ApiScope("ImagesFullPermission", "Full permission to images API"),
            new ApiScope("ImagesReadPermission", "Read permission to images API"),            
            new ApiScope("OcelotFullPermission", "Full permission to ocelot API"),
            new ApiScope("OcelotReadPermission", "Read permission to ocelot API"),      
            new ApiScope("MessageFullPermission", "Full permission to message API"),
            new ApiScope("MessageReadPermission", "Read permission to message API"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
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
                AllowedScopes = { "DiscountFullPermission" , "CatalogFullPermission" , 
                    "OcelotFullPermission", "CommentFullPermission" ,"BasketFullPermission"}
            },

            //Manager
            new Client
            {
                ClientId = "MultiShopManagerId",
                ClientName = "Multi Shop Manager",
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                AllowedScopes = {"OrderFullPermission", "DiscountFullPermission",
                    "CatalogFullPermission","CargoFullPermission","BasketFullPermission","CommentFullPermission",
                    "PaymentFullPermission","ImagesFullPermission","OcelotFullPermission","MessageFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }
            },

            //Admin
            new Client
            {
                ClientId = "MultiShopAdminId",
                ClientName = "Multi Shop Admin User",
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                AllowedScopes =
                {
                    "OrderFullPermission", "DiscountFullPermission", 
                    "CatalogFullPermission","CargoFullPermission","BasketFullPermission","CommentFullPermission",
                    "PaymentFullPermission","ImagesFullPermission","OcelotFullPermission","MessageFullPermission",
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