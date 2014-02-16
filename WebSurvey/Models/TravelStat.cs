using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSurvey.Models
{
    public class TravelStat
    {
        public int IdLocation { get; set; }
        public int? Votes { get; set; }
        public int Incidences { get; set; }
        public decimal? Medium { get; set; }
    }
}