using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Session18.Users.Infrastructures
{
    public class LocationClaimsProvider : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            if (principal != null && !principal.HasClaim(c =>
            c.Type == ClaimTypes.PostalCode))
            {
                ClaimsIdentity identity = principal.Identity as ClaimsIdentity;
                if (identity != null && identity.IsAuthenticated
                && identity.Name != null)
                {
                    if (identity.Name.ToLower() == "alireza")
                    {
                        identity.AddClaims(new Claim[] {
                        CreateClaim(ClaimTypes.PostalCode, "20500"),
                        CreateClaim(ClaimTypes.StateOrProvince, "Tehran")
                        });
                    }
                    else
                    {
                        identity.AddClaims(new Claim[] {
                        CreateClaim(ClaimTypes.PostalCode, "NY 10036"),
                        CreateClaim(ClaimTypes.StateOrProvince, "NY")
                        });
                    }
                }
            }
            return Task.FromResult(principal);
        }
        private static Claim CreateClaim(string type, string value) =>
        new Claim(type, value, ClaimValueTypes.String, "Human Resource");
    }
}
