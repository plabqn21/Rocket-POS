using RamsoftBD.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RamsoftBD.ModelView
{
    public class PermissionViewModel:Permission
    {
        
      public  List<Permission> Permissions { get; set; }

    }
}