using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebSurvey.Models
{
    public class Location
    {
        [Key]
        public int IdLocation { get; set; }
        public string Name { get; set; }
    }
}