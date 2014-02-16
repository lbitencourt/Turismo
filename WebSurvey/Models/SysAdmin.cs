using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSurvey.Models
{
    public class SysAdmin
    {
        [Key]
        public int IdAdmin { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Mail { get; set; }
    }
}