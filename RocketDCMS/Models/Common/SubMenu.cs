using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RamsoftBD.Models.Common
{
    public class SubMenu
    {
        [Key]
        public Guid Id { get; set; }
     
        [MaxLength(100)]
        public string SubMenuName { get; set; }
      
        [MaxLength(100)]
        public string Controller { get; set; }

        [MaxLength(100)]
        public string Action { get; set; }

        [ForeignKey("MainMenu")]
        public String MainMenuId { get; set; }
        public MainMenu MainMenu { get; set; }

    }
}