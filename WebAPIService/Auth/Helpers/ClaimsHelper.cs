using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace WebAPIService.Auth.Helpers
{
    public static class ClaimsHelper
    {
        public static string GetIdUser(this IPrincipal user)
        {
            return GetClaim(user, "Id");
        }
        public static string GetUsername(this IPrincipal user)
        {
            return GetClaim(user, "UserName");
        }
        public static List<string> GetUserRoles(this ClaimsIdentity identity)
        {
            return identity.Claims
                    .Where(c => c.Type == ClaimTypes.Role)
                    .Select(c => c.Value)
                    .ToList();
        }
        private static string GetClaim(IPrincipal user, string key)
        {
            ClaimsIdentity claimsIdentity = user.Identity as ClaimsIdentity;
            var claim = claimsIdentity.Claims.Where(c => c.Type == key).FirstOrDefault();

            if (claim != null)
            {
                return claim.Value;
            }
            else
            {
                return null;
            }
        }
    }


}