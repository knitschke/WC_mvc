using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WC_mvc.Models;

namespace WC_mvc.Controllers
{
    
    public class HomeController : Controller
    {
        static int n = 0;

        public ActionResult Index()
        {

            n++;
            WorldCupDbEntities db = new WorldCupDbEntities();

            if (db.Countries.SingleOrDefault(x => x.Country_Id == n) != null)
            {
                Country Ct = db.Countries.SingleOrDefault(x=>x.Country_Id == n);
                CountryListModel lm = new CountryListModel();
                lm.Country_Id = Ct.Country_Id;
                lm.Name = Ct.Name;


                if (db.Scorers.FirstOrDefault(x => x.Country_Id == n) != null)
                {
                    foreach (Scorer xx in db.Scorers)
                    {
                        if (xx.Country_Id == n)
                        {

                            lm.Scorer_Id.Add(xx.Scorer_Id);
                            lm.Surname.Add(xx.Surname);
                            lm.counter++;
                        }
                    }
                }
                


                return View(lm);
            }
            else if (db.Countries.First()!=null)
            {
                Country Ct = db.Countries.First();
                CountryListModel lm = new CountryListModel();
                lm.Country_Id = Ct.Country_Id;
                lm.Name = Ct.Name;
                n = Ct.Country_Id;

                if (db.Scorers.FirstOrDefault(x => x.Country_Id == n) != null)
                {
                    foreach (Scorer xx in db.Scorers)
                    {
                        if (xx.Country_Id == n)
                        {

                            lm.Scorer_Id.Add(xx.Scorer_Id);
                            lm.Surname.Add(xx.Surname);
                            lm.counter++;
                        }
                    }
                }


                return View(lm);
            }
            else return View();
        }

        public ActionResult DBChanges()
        {
            return View();
        }
    }
}