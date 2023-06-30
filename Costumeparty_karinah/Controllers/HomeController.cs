using Costumeparty_karinah.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Costumeparty_karinah.Controllers
{
    public class HomeController : Controller
    {

      private Disfraces[] disfracesData =
          {    

            new Disfraces{Name="Juanes", Theme="Carnaval", IsAccompanied=true, Disfraz=Disfraz.Vampiros},
            new Disfraces{Name="Carolina", Theme="Halloween", IsAccompanied=true, Disfraz=Disfraz.Bruja},
            new Disfraces { Name = "Maria", Theme = "Halloween", IsAccompanied = false, Disfraz = Disfraz.Zombies },
            new Disfraces { Name = "Joe", Theme = "Payasos", IsAccompanied = false, Disfraz = Disfraz.Otro },
            new Disfraces { Name = "Pedro", Theme = "Carnaval", IsAccompanied = true, Disfraz = Disfraz.Otro },
            new Disfraces { Name = "Oscar", Theme = "Halloween", IsAccompanied = false, Disfraz = Disfraz.Zombies },

         };
        // GET: People
        public ActionResult GetDisfraces(string selectedDisfraz = "All")
        {
            return View((object)selectedDisfraz);
        }
        public ActionResult GetDisfracesData(string selectedDisfraz = "All")
        {
            IEnumerable<Disfraces> data = disfracesData;
            if (selectedDisfraz != "All")
            {
                Disfraz selected = (Disfraz)Enum.Parse(typeof(Disfraz), selectedDisfraz);
                data = disfracesData.Where(d => d.Disfraz == selected);
            }
            if (Request.IsAjaxRequest())
            {
                var formattedData = data.Select(d => new
                {
                    Name = d.Name,  
                    Theme = d.Theme,
                    IsAccompanied = d.IsAccompanied,
                    Disfraz = d.Disfraz.ToString()
                });
                return Json(formattedData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return PartialView(data);
            }

        }
    }
}