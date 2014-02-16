namespace WebSurvey.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebSurvey.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebSurvey.DAL.TurismoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebSurvey.DAL.TurismoContext context)
        {
            var clients = new List<Client>
            {
                new Client {IdClient = 1, Name = "Edson Marques da Silva", Document = "45324560456", Phone = "3187875566", Mail = "edson@email.com" },
                new Client {IdClient = 2, Name = "Carlos Eduardo Freire", Document = "95324860456", Phone = "4194154319", Mail = "carlos@email.com" },
                new Client {IdClient = 3, Name = "Afonso Mello Ambrosio", Document = "74287653129", Phone = "11987681276", Mail = "afonso@email.com" },
                new Client {IdClient = 4, Name = "Lucia Vera Matoso", Document = "84357651565", Phone = "3187193409", Mail = "lucia@email.com" },
                new Client {IdClient = 5, Name = "Antonio Alex Almirante", Document = "54735502157", Phone = "2197201234", Mail = "antonio@email.com" },
                new Client {IdClient = 6, Name = "Julia Almeida dos Santos", Document = "38894572749", Phone = "3191208753", Mail = "julia@email.com" },
                new Client {IdClient = 7, Name = "Felipe Souza Alencar", Document = "63486341405", Phone = "3176136431", Mail = "felipe@email.com" },
                new Client {IdClient = 8, Name = "Tamara Carla da Mata", Document = "80278593526", Phone = "11987843456", Mail = "tamara@email.com" },
                new Client {IdClient = 9, Name = "Veronica Evelyin Nogueira", Document = "61442971894", Phone = "11987843456", Mail = "veronica@email.com" },
                new Client {IdClient = 10, Name = "Saulo Evaristo dos Anjos", Document = "89820675588", Phone = "3187946783", Mail = "saulo@email.com" }
            };
            clients.ForEach(s => context.Clients.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();


            var locations = new List<Location>
            {
                new Location { IdLocation = 1, Name = "Inglaterra" },
                new Location { IdLocation = 2, Name = "EUA" },
                new Location { IdLocation = 3, Name = "Canadá" },
                new Location { IdLocation = 4, Name = "França" },
                new Location { IdLocation = 5, Name = "Egito" },
                new Location { IdLocation = 6, Name = "Alemanha" },
                new Location { IdLocation = 7, Name = "Croácia" },
                new Location { IdLocation = 8, Name = "Antártida" },
                new Location { IdLocation = 9, Name = "Australia" },
                new Location { IdLocation = 10, Name = "Russia" }
            };
            locations.ForEach(s => context.Locations.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var travelHistory = new List<TravelHistory>
            {
                new TravelHistory {IdTravelHistory = 1, IdClient = 1, IdLocation = 1, Date = DateTime.Parse("2013-06-22"), Satisfaction = 7 },
                new TravelHistory {IdTravelHistory = 2, IdClient = 1, IdLocation = 2, Date = DateTime.Parse("2013-08-10"), Satisfaction = null },
                new TravelHistory {IdTravelHistory = 3, IdClient = 1, IdLocation = 5, Date = DateTime.Parse("2013-10-03"), Satisfaction = null },
                new TravelHistory {IdTravelHistory = 4, IdClient = 1, IdLocation = 7, Date = DateTime.Parse("2013-12-01"), Satisfaction = null },
                new TravelHistory {IdTravelHistory = 5, IdClient = 1, IdLocation = 3, Date = DateTime.Parse("2014-01-27"), Satisfaction = null },
                
                new TravelHistory {IdTravelHistory = 6, IdClient = 2, IdLocation = 1, Date = DateTime.Parse("2012-12-04"), Satisfaction = 8 },
                new TravelHistory {IdTravelHistory = 7, IdClient = 2, IdLocation = 3, Date = DateTime.Parse("2013-02-14"), Satisfaction = 1 },
                new TravelHistory {IdTravelHistory = 8, IdClient = 2, IdLocation = 5, Date = DateTime.Parse("2013-04-23"), Satisfaction = 9 },
                new TravelHistory {IdTravelHistory = 9, IdClient = 2, IdLocation = 2, Date = DateTime.Parse("2013-07-11"), Satisfaction = 9 },
                new TravelHistory {IdTravelHistory = 10, IdClient = 2, IdLocation = 10, Date = DateTime.Parse("2013-10-21"), Satisfaction = 1 },
                
                new TravelHistory {IdTravelHistory = 11, IdClient = 3, IdLocation = 2, Date = DateTime.Parse("2011-02-21"), Satisfaction = 9 },
                new TravelHistory {IdTravelHistory = 12, IdClient = 3, IdLocation = 1, Date = DateTime.Parse("2011-10-17"), Satisfaction = 7 },
                new TravelHistory {IdTravelHistory = 13, IdClient = 3, IdLocation = 4, Date = DateTime.Parse("2012-01-07"), Satisfaction = 5 },
                new TravelHistory {IdTravelHistory = 14, IdClient = 3, IdLocation = 5, Date = DateTime.Parse("2012-06-13"), Satisfaction = 3 },
                new TravelHistory {IdTravelHistory = 15, IdClient = 3, IdLocation = 7, Date = DateTime.Parse("2013-12-17"), Satisfaction = 2 },
                
                new TravelHistory {IdTravelHistory = 16, IdClient = 4, IdLocation = 2, Date = DateTime.Parse("2009-02-12"), Satisfaction = 7 },
                new TravelHistory {IdTravelHistory = 17, IdClient = 4, IdLocation = 6, Date = DateTime.Parse("2010-04-30"), Satisfaction = 9 },
                new TravelHistory {IdTravelHistory = 18, IdClient = 4, IdLocation = 9, Date = DateTime.Parse("2011-07-05"), Satisfaction = 6 },
                new TravelHistory {IdTravelHistory = 19, IdClient = 4, IdLocation = 3, Date = DateTime.Parse("2012-09-29"), Satisfaction = 9 },
                new TravelHistory {IdTravelHistory = 20, IdClient = 4, IdLocation = 8, Date = DateTime.Parse("2012-12-25"), Satisfaction = 1 },
                
                new TravelHistory {IdTravelHistory = 21, IdClient = 5, IdLocation = 2, Date = DateTime.Parse("2012-08-15"), Satisfaction = 9 },
                new TravelHistory {IdTravelHistory = 22, IdClient = 5, IdLocation = 10, Date = DateTime.Parse("2012-11-19"), Satisfaction = 4 },
                new TravelHistory {IdTravelHistory = 23, IdClient = 5, IdLocation = 5, Date = DateTime.Parse("2013-01-31"), Satisfaction = 3 },
                new TravelHistory {IdTravelHistory = 24, IdClient = 5, IdLocation = 1, Date = DateTime.Parse("2013-04-12"), Satisfaction = 8 },
                new TravelHistory {IdTravelHistory = 25, IdClient = 5, IdLocation = 3, Date = DateTime.Parse("2013-08-03"), Satisfaction = 8 },

                new TravelHistory {IdTravelHistory = 26, IdClient = 6, IdLocation = 3, Date = DateTime.Parse("2013-01-18"), Satisfaction = 9 },
                new TravelHistory {IdTravelHistory = 27, IdClient = 6, IdLocation = 4, Date = DateTime.Parse("2013-03-09"), Satisfaction = 3 },
                new TravelHistory {IdTravelHistory = 28, IdClient = 6, IdLocation = 2, Date = DateTime.Parse("2013-06-12"), Satisfaction = 9 },
                new TravelHistory {IdTravelHistory = 29, IdClient = 6, IdLocation = 6, Date = DateTime.Parse("2013-08-01"), Satisfaction = 10 },
                new TravelHistory {IdTravelHistory = 30, IdClient = 6, IdLocation = 9, Date = DateTime.Parse("2013-11-27"), Satisfaction = 8 },

                new TravelHistory {IdTravelHistory = 31, IdClient = 7, IdLocation = 1, Date = DateTime.Parse("2012-01-08"), Satisfaction = 3 },
                new TravelHistory {IdTravelHistory = 32, IdClient = 7, IdLocation = 6, Date = DateTime.Parse("2013-04-19"), Satisfaction = 8 },
                new TravelHistory {IdTravelHistory = 33, IdClient = 7, IdLocation = 2, Date = DateTime.Parse("2013-06-21"), Satisfaction = 9 },
                new TravelHistory {IdTravelHistory = 34, IdClient = 7, IdLocation = 4, Date = DateTime.Parse("2013-09-16"), Satisfaction = 3 },
                new TravelHistory {IdTravelHistory = 35, IdClient = 7, IdLocation = 3, Date = DateTime.Parse("2013-12-05"), Satisfaction = 6 },

                new TravelHistory {IdTravelHistory = 36, IdClient = 8, IdLocation = 3, Date = DateTime.Parse("2008-01-28"), Satisfaction = 9 },
                new TravelHistory {IdTravelHistory = 37, IdClient = 8, IdLocation = 5, Date = DateTime.Parse("2009-04-09"), Satisfaction = 2 },
                new TravelHistory {IdTravelHistory = 38, IdClient = 8, IdLocation = 7, Date = DateTime.Parse("2010-06-11"), Satisfaction = 1 },
                new TravelHistory {IdTravelHistory = 39, IdClient = 8, IdLocation = 8, Date = DateTime.Parse("2012-09-26"), Satisfaction = 2 },
                new TravelHistory {IdTravelHistory = 40, IdClient = 8, IdLocation = 10, Date = DateTime.Parse("2013-12-15"), Satisfaction = 3 },

                new TravelHistory {IdTravelHistory = 41, IdClient = 9, IdLocation = 1, Date = DateTime.Parse("2013-01-28"), Satisfaction = 5 },
                new TravelHistory {IdTravelHistory = 42, IdClient = 9, IdLocation = 2, Date = DateTime.Parse("2013-03-09"), Satisfaction = 10 },
                new TravelHistory {IdTravelHistory = 43, IdClient = 9, IdLocation = 4, Date = DateTime.Parse("2013-10-11"), Satisfaction = 3 },
                new TravelHistory {IdTravelHistory = 44, IdClient = 9, IdLocation = 6, Date = DateTime.Parse("2013-11-26"), Satisfaction = 8 },
                new TravelHistory {IdTravelHistory = 45, IdClient = 9, IdLocation = 9, Date = DateTime.Parse("2014-01-05"), Satisfaction = 7 },

                new TravelHistory {IdTravelHistory = 46, IdClient = 10, IdLocation = 3, Date = DateTime.Parse("2012-09-18"), Satisfaction = 5 },
                new TravelHistory {IdTravelHistory = 47, IdClient = 10, IdLocation = 2, Date = DateTime.Parse("2012-12-29"), Satisfaction = 4 },
                new TravelHistory {IdTravelHistory = 48, IdClient = 10, IdLocation = 1, Date = DateTime.Parse("2013-04-12"), Satisfaction = 9 },
                new TravelHistory {IdTravelHistory = 49, IdClient = 10, IdLocation = 7, Date = DateTime.Parse("2013-09-16"), Satisfaction = 1 },
                new TravelHistory {IdTravelHistory = 50, IdClient = 10, IdLocation = 10, Date = DateTime.Parse("2013-12-01"), Satisfaction = 4 }
            };
            travelHistory.ForEach(s => context.TravelHistory.AddOrUpdate(p => p.IdTravelHistory, s));
            context.SaveChanges();

            var admins = new List<SysAdmin>
            {
                new SysAdmin { IdAdmin = 1, Name = "Gerente Xpto", Document = "47774033270", Mail = "gerente@xpto.com"}
            };
            admins.ForEach(s => context.SysAdmin.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
        }
    }
}
