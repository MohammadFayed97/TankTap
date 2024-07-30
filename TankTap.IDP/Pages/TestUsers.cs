// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

using IdentityModel;
using System.Security.Claims;
using System.Text.Json;
using Duende.IdentityServer;
using Duende.IdentityServer.Test;

namespace TankTap.IDP;

public static class TestUsers
{
    public static List<TestUser> Users
    {
        get
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "f982209c-0543-49e9-82eb-1f72dc60fd37",
                    Username = "Amr",
                    Password = "Asd@2030",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Amr Mohammad"),
                        new Claim(JwtClaimTypes.Email, "amr@gmail.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim("roles", "Admin"),
                        new Claim("roles", "Super Admin"),
                    }
                },
                new TestUser
                {
                    SubjectId = "7e94e9a7-1c25-47b2-ab71-4c451bc3872c",
                    Username = "Fayed",
                    Password = "Asd@2030",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Mohammad Fayed"),
                        new Claim(JwtClaimTypes.Email, "fayed@gmail.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim("roles", "Worker"),
                    }
                },
            };
        }
    }
}