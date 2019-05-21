using RamsoftBD.Models;
using RamsoftBD.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RamsoftBD.ModelView
{
    public class SubMenuViewModel
    {
        [Key]
        public Guid Id { get; set; }
     
       

        [ForeignKey("MainMenu")]
        [Required]
        public String MainMenuId { get; set; }
        public MainMenu MainMenu { get; set; }

        [MaxLength(100)]
        public string SubMenuName { get; set; }

        [ForeignKey("Role")]
        [Required]
        public String RoleId { get; set; }
        public CustomRole Role { get; set; }
        [Required]
        public int? Status { get; set; }
    }
}