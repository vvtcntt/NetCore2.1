using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NetCore.Extensions
{
    public static class IdentityExtensions
    {
        public static string getSpecificClaim(this ClaimsPrincipal claimsPrincipal, string claimsType)
        {
            var claims = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == claimsType);
            return (claims != null) ? claims.Value : string.Empty;
        }
    }
}
