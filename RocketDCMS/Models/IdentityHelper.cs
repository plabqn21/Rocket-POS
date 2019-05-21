using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace RamsoftBD.Models
{
    public static class IdentityHelper
    {

        public static string GetUserBranchId(this IIdentity identity)
        {
            var claimIdent = identity as ClaimsIdentity;
            return claimIdent != null
                && claimIdent.HasClaim(c => c.Type == "BranchId")
                ? claimIdent.FindFirst("BranchId").Value
                : string.Empty;
        }

        public static string GetUserName(this IIdentity identity)
        {
            var claimIdent = identity as ClaimsIdentity;
            return claimIdent != null
                && claimIdent.HasClaim(c => c.Type == "Name")
                ? claimIdent.FindFirst("Name").Value
                : string.Empty;
        }

        public static string GetUserRole(this IIdentity identity)
        {
            var claimIdent = identity as ClaimsIdentity;
            return claimIdent != null
                && claimIdent.HasClaim(c => c.Type == "Role")
                ? claimIdent.FindFirst("Role").Value
                : string.Empty;
        }

        public static string GetUser_Id(this IIdentity identity)
        {
            var claimIdent = identity as ClaimsIdentity;
            return claimIdent != null
                && claimIdent.HasClaim(c => c.Type == "Id")
                ? claimIdent.FindFirst("Id").Value
                : string.Empty;
        }


        public static string GetUser_Email(this IIdentity identity)
        {
            var claimIdent = identity as ClaimsIdentity;
            return claimIdent != null
                && claimIdent.HasClaim(c => c.Type == "Email")
                ? claimIdent.FindFirst("Email").Value
                : string.Empty;
        }
    }
}