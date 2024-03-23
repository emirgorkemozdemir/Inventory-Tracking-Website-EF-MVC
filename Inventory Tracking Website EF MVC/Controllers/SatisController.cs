using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stok_Takip_Mvc_.net6.Models;

namespace Stok_Takip_Mvc_.net6.Controllers
{
    public class SatisController : Controller
    {
        SatisBLL satisManager = new SatisBLL();
        public ActionResult ListSelling()
        {
            if (HttpContext.Session.GetString("IsUserLogged") != "yes")
            {
                return RedirectToAction("Login", "Uye");
            }
            else
            {
                return View(satisManager.ListJoinedBLL());
            }

        }

        public ActionResult DeleteSelling(int id)
        {
            if (HttpContext.Session.GetString("IsUserLogged") != "yes")
            {
                return RedirectToAction("Login", "Uye");
            }
            else
            {
                Satistablosu new_selling = new Satistablosu();
                using (StokTakipVeritabanıContext context = new StokTakipVeritabanıContext())
                {
                    new_selling = context.Satistablosus.FirstOrDefault(a => a.Satisid == id);
                }

                satisManager.Delete(new_selling);

                return RedirectToAction("ListSelling");

            }
        }

        [HttpGet]
        public ActionResult AddSelling()
        {
            if (HttpContext.Session.GetString("IsUserLogged") != "yes")
            {
                return RedirectToAction("Login", "Uye");
            }
            else
            {
                using (StokTakipVeritabanıContext context = new StokTakipVeritabanıContext())
                {
                    var temp_product_list = context.Uruntablosus.ToList();
                    List<SelectListItem> select_items_dropdown = (from c in temp_product_list select new SelectListItem { Text = c.Urunad, Value = c.Urunid.ToString() }).ToList();
                    ViewBag.products = select_items_dropdown;

                    var temp_customer_list = context.Musteritablosus.ToList();
                    List<SelectListItem> select_items_dropdown2 = (from c in temp_customer_list select new SelectListItem { Text = c.Musteriad + " " + c.Musterisoyad, Value = c.Musteriid.ToString() }).ToList();
                    ViewBag.customers = select_items_dropdown2;

                    return View();
                }
            }
        }

        [HttpPost]
        public ActionResult AddSelling(Satistablosu new_selling)
        {
            if (HttpContext.Session.GetString("IsUserLogged") != "yes")
            {
                return RedirectToAction("Login", "Uye");
            }
            else
            {

                if (ModelState.IsValid)
                {
                    satisManager.Add(new_selling);
                    return RedirectToAction("ListSelling");
                }
                else
                {
                    return View();
                }


            }
        }

        [HttpGet]
        public ActionResult EditSelling(int id)
        {
            if (HttpContext.Session.GetString("IsUserLogged") != "yes")
            {
                return RedirectToAction("Login", "Uye");
            }
            else
            {
                using (StokTakipVeritabanıContext context = new StokTakipVeritabanıContext())
                {
                    var temp_product_list = context.Uruntablosus.ToList();
                    List<SelectListItem> select_items_dropdown = (from c in temp_product_list select new SelectListItem { Text = c.Urunad, Value = c.Urunid.ToString() }).ToList();
                    ViewBag.products = select_items_dropdown;

                    var temp_customer_list = context.Musteritablosus.ToList();
                    List<SelectListItem> select_items_dropdown2 = (from c in temp_customer_list select new SelectListItem { Text = c.Musteriad + " " + c.Musterisoyad, Value = c.Musteriid.ToString() }).ToList();
                    ViewBag.customers = select_items_dropdown2;

                    var selected_selling = context.Satistablosus.Find(id);

                    return View(selected_selling);
                }
            }
        }

        [HttpPost]
        public ActionResult EditSelling(Satistablosu new_selling)
        {
            if (HttpContext.Session.GetString("IsUserLogged") != "yes")
            {
                return RedirectToAction("Login", "Uye");
            }
            else
            {
              
                    if (ModelState.IsValid)
                    {
                    satisManager.Edit(new_selling);
                        return RedirectToAction("ListSelling");
                    }
                    else
                    {
                        return View();
                    }

                }
            }
        }

    }


