using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSurvey.DAL;

namespace WebSurvey.Lib
{
    public class LocationTable
    {
        private TurismoContext db = new TurismoContext();

        public string name { get; set; }
        public LocationTable(int id)
        {
            name = db.Locations.Where(b => b.IdLocation == id).FirstOrDefault().Name;
        }


        public static string ReturnName(int id)
        {
            LocationTable location = new LocationTable(id);
            return location.name;
        }


    }
}