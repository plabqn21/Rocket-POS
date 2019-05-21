using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RamsoftBD.Models.Common
{
    public class MenuViewModel
    {

        public string MainMenuName { get; set; }
        public string MainMenuId { get; set; }
        public string SubMenuName { get; set; }
        public Guid SubMenuId { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }

    }
}