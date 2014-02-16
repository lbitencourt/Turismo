using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebSurvey.Models
{
    public class Client
    {
        [Key]
        public int IdClient { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Document { get; set; }
        public string Mail { get; set; }
    }
}