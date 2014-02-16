using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebSurvey.DAL;
using WebSurvey.Models;

namespace WebSurvey.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private TurismoContext db = new TurismoContext();

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string returnUrl)
        {
            if (ModelState.IsValid && ValidateUser(model))
            {
                return RedirectToLocal(returnUrl);
            }
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "As informções de Email ou CPF estão incorretas.");
            return View(model);
        }

        //
        // POST: /Account/LogOff

        public ActionResult LogOff()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Index()
        {
            if (Session["User"] != null)
            {
                Client client = new Client();
                dynamic user = Session["User"];
                client = user;
                return View(client);
            }
            else
            {
                Session.Clear();
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult History()
        {
            if (Session["User"] != null || Session["UserType"] != "User")
            {
                dynamic user = Session["User"];
                int id = user.IdClient;

                List<TravelHistory> travelHistories = new List<TravelHistory>();
                travelHistories = db.TravelHistory.Where(b => b.IdClient == id).ToList();

                return View(travelHistories);
            }
            else
            {
                Session.Clear();
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult HistoryDetail(int id)
        {
            TravelHistory travelHistory = new TravelHistory();
            travelHistory = db.TravelHistory.Where(b => b.IdTravelHistory == id).FirstOrDefault();
            return View(travelHistory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HistorySave(TravelHistory travelHistory)
        {
            if (ModelState.IsValid && (travelHistory.Satisfaction > 0 && travelHistory.Satisfaction <= 10))
            {
                db.Entry(travelHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("History");
            }
            else if (ModelState.IsValid && travelHistory.Satisfaction > 10)
            {
                ViewBag.Message = "Seu índice de satisfação tem que ser um número entre 1 e 10.";
                travelHistory.Satisfaction = null;
                return View("HistoryDetail", travelHistory);
            }
            else
            {
                ViewBag.Message = "Você não digitou nenhum valor em sua nota.";
                travelHistory.Satisfaction = null;
                return View("HistoryDetail", travelHistory);
            }
        }

        public ActionResult TopTravels()
        {
            string Role = Session["UserType"].ToString();

            if (Role.Equals("Admin"))
            {
                List<TravelHistory> travelHistory = new List<TravelHistory>();
                travelHistory = db.TravelHistory.ToList();

                List<int> Locations = new List<int>();
                Locations = travelHistory.Select(cl => cl.IdLocation).Distinct().ToList();

                List<TravelStat> travelStats = new List<TravelStat>();

                foreach (var item in Locations)
                {
                    TravelStat travelItem = new TravelStat();
                    travelItem.IdLocation = item;
                    travelItem.Votes = travelHistory.Where(b => b.IdLocation == item).Sum(x => x.Satisfaction);
                    travelItem.Incidences = travelHistory.Where(b => b.IdLocation == item).Count();
                    travelItem.Medium = (decimal)travelItem.Votes / (decimal)travelItem.Incidences;
                    travelStats.Add(travelItem);
                }

                var ascendingQuery = (from data in travelStats
                                      orderby data.Medium descending
                                      select data).Take(5);

                List<TravelStat> topTravels = new List<TravelStat>();

                topTravels = ascendingQuery.ToList<TravelStat>();

                return View(topTravels);
            }
            else
            {
                return View("Index");
            }

        }

        public ActionResult BottomTravels()
        {
            string Role = Session["UserType"].ToString();

            if (Role.Equals("Admin"))
            {
                List<TravelHistory> travelHistory = new List<TravelHistory>();
                travelHistory = db.TravelHistory.ToList();

                List<int> Locations = new List<int>();
                Locations = travelHistory.Select(cl => cl.IdLocation).Distinct().ToList();

                List<TravelStat> travelStats = new List<TravelStat>();

                foreach (var item in Locations)
                {
                    TravelStat travelItem = new TravelStat();
                    travelItem.IdLocation = item;
                    travelItem.Votes = travelHistory.Where(b => b.IdLocation == item).Sum(x => x.Satisfaction);
                    travelItem.Incidences = travelHistory.Where(b => b.IdLocation == item).Count();
                    travelItem.Medium = (decimal)travelItem.Votes / (decimal)travelItem.Incidences;
                    travelStats.Add(travelItem);
                }

                var ascendingQuery = (from data in travelStats
                                      orderby data.Medium ascending
                                      select data).Take(5);

                List<TravelStat> bottomTravels = new List<TravelStat>();

                bottomTravels = ascendingQuery.ToList<TravelStat>();

                return View(bottomTravels);
            }
            else
            {
                return View("Index");
            }
        }

        public bool ValidateUser(Login model)
        {
            dynamic user;

            model.Document = RemoveSpecialCharacters(model.Document);


            user = db.Clients.Where(b => b.Mail == model.Mail && b.Document == model.Document).FirstOrDefault();
            Session["UserType"] = "User";

            if (user == null)
            {
                user = db.SysAdmin.Where(b => b.Mail == model.Mail && b.Document == model.Document).FirstOrDefault();
                Session["UserType"] = "Admin";
            }

            if (user != null)
            {
                Session["User"] = user;
                FormsAuthentication.SetAuthCookie(model.Mail, model.RememberMe);
                return true;
            }
            else
            {
                return false;
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public static string RemoveSpecialCharacters(string input)
        {
            Regex r = new Regex("(?:[^a-z0-9 ]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            return r.Replace(input, String.Empty);
        }

    }
}
