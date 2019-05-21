using RamsoftBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RamsoftBD.ModelView
{
    public class CustomRoleViewModel: CustomRole
    {
        public List<CustomRole> CustomRoles { get; set; }
    }
}