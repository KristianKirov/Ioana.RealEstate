using Ioana.RealEstate.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Ioana.RealEstate.Extensions.Authentication
{
    public static class PrincipalExtensions
    {
        public static bool IsAdmin(this IPrincipal principal)
        {
            return principal.IsInRole(Constants.AdminRoleName) || principal.IsInRole(Constants.SuperAdminRoleName);
        }
    }
}