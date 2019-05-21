using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RamsoftBD.Models.Common
{
    public class MainMenu
    {
        [Key]
        [MaxLength(100)]
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string MainMenuName { get; set; }
    }
}