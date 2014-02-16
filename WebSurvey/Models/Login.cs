using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSurvey.Models
{
    public class Login
    {
        [Required]
        [Display(Name = "Email")]
        public string Mail { get; set; }
        
        [Required]
        [Display(Name = "CPF")]
        public string Document { get; set; }

        [Display(Name = "Permanecer Conectado?")]
        public bool RememberMe { get; set; }


    }
}