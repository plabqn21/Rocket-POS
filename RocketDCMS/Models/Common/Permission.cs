using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RamsoftBD.Models.Common
{
    public class Permission
    {

        [Key]
        public Guid Id { get; set; }

        [ForeignKey("CustomRole")]
        public string CustomRoleId { get; set; }
        public CustomRole CustomRole { get; set; }

        [ForeignKey("MainMenu")]
        public string MainMenuId { get; set; }
        public MainMenu MainMenu { get; set; }

        [ForeignKey("SubMenu")]
        public Guid SubMenuId { get; set; }
        public SubMenu SubMenu { get; set; }

        [Required]
        public int Status { get; set; }

    }
}