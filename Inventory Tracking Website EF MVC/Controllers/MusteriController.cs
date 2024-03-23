using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Stok_Takip_Mvc_.net6.Models;

namespace Stok_Takip_Mvc_.net6.Controllers
{
    public class MusteriController : Controller
    {
        MusteriBLL musteriManager = new MusteriBLL();
        public IActionResult ListCustomers()
        {
            if (HttpContext.Session.GetString("IsUserLogged") != "yes")
            {
                return RedirectToAction("Login", "Uye");
            }
            else
            {

                return View(musteriManager.List());

            }

        }

        public IActionResult DeleteCustomer(int id)
        {
            if (HttpContext.Session.GetString("IsUserLogged") != "yes")
            {
                return RedirectToAction("Login", "Uye");
            }
            else
            {
                Musteritablosu new_customer = new Musteritablosu();
                using (StokTakipVeritabanıContext context = new StokTakipVeritabanıContext())
                {
                    new_customer = context.Musteritablosus.FirstOrDefault(a => a.Musteriid == id);
                }

                musteriManager.Delete(new_customer);
                return RedirectToAction("ListCustomers");
            }
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            if (HttpContext.Session.GetString("IsUserLogged") != "yes")
            {
                return RedirectToAction("Login", "Uye");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddCustomer(Musteritablosu new_customer)
        {
            if (HttpContext.Session.GetString("IsUserLogged") != "yes")
            {
                return RedirectToAction("Login", "Uye");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    musteriManager.Add(new_customer);
                    return RedirectToAction("ListCustomers");

                }
                else
                {
                    return View();
                }

            }
        }

        [HttpGet]
        public IActionResult EditCustomer(int id)
        {
            if (HttpContext.Session.GetString("IsUserLogged") != "yes")
            {
                return RedirectToAction("Login", "Uye");
            }
            else
            {

                Musteritablosu new_customer = new Musteritablosu();
                using (StokTakipVeritabanıContext context = new StokTakipVeritabanıContext())
                {
                    new_customer = context.Musteritablosus.FirstOrDefault(a => a.Musteriid == id);
                }

                return View(new_customer);

            }
        }

        [HttpPost]
        public IActionResult EditCustomer(Musteritablosu new_customer)
        {
            if (HttpContext.Session.GetString("IsUserLogged") != "yes")
            {
                return RedirectToAction("Login", "Uye");
            }
            else
            {
                musteriManager.Edit(new_customer);
                return RedirectToAction("ListCustomers");


            }
        }
    }
}
