using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebSurvey.Models
{
    public class TravelHistory
    {
        [Key]
        public int IdTravelHistory { get; set; }
        public int IdLocation { get; set; }
        public DateTime Date { get; set; }
        public int? Satisfaction { get; set; }
        public int IdClient { get; set; }
    }
}