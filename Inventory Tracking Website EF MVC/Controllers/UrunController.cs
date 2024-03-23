using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stok_Takip_Mvc_.net6.Models;

namespace Stok_Takip_Mvc_.net6.Controllers
{
    public class UrunController : Controller
    {
        UrunBLL urunManager = new UrunBLL();

        [HttpGet]
        public IActionResult ListProducts()
        {

            if (HttpContext.Session.GetString("IsUserLogged") != "yes")
            {
                return RedirectToAction("Login", "Uye");
            }
            else
            {
                
                return View(urunManager.ListJoinedBLL());

            }

        }

        public ActionResult DeleteProduct(int id)
        {

            if (HttpContext.Session.GetString("IsUserLogged") != "yes")
            {
                return RedirectToAction("Login", "Uye");
            }
            else
            {
                Uruntablosu new_product = new Uruntablosu();
                using (StokTakipVeritabanıContext context = new StokTakipVeritabanıContext())
                {
                    new_product = context.Uruntablosus.FirstOrDefault(a => a.Urunid == id);
                }

                urunManager.Delete(new_product);
                return RedirectToAction("ListProducts");

            }
        }

        [HttpGet]
        public ActionResult AddProduct()
        {

            if (HttpContext.Session.GetString("IsUserLogged") != "yes")
            {
                return RedirectToAction("Login", "Uye");
            }
            else
            {
                using (StokTakipVeritabanıContext context = new StokTakipVeritabanıContext())
                {
                    var temp_categ_list = context.Kategoritablosus.ToList();
                    List<SelectListItem> select_items_dropdown = (from c in temp_categ_list select new SelectListItem { Text = c.Kategoriad, Value = c.Kategoriid.ToString() }).ToList();
                    ViewBag.categories = select_items_dropdown;
                    return View();
                }
            }

        }

        [HttpPost]
        public ActionResult AddProduct(Uruntablosu new_product)
        {

            if (HttpContext.Session.GetString("IsUserLogged") != "yes")
            {
                return RedirectToAction("Login", "Uye");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                else
                {
                    urunManager.Add(new_product);
                    return RedirectToAction("ListProducts");

                }

            }
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {

            if (HttpContext.Session.GetString("IsUserLogged") != "yes")
            {
                return RedirectToAction("Login", "Uye");
            }
            else
            {
                using (StokTakipVeritabanıContext context = new StokTakipVeritabanıContext())
                {
                    var temp_categ_list = context.Kategoritablosus.ToList();
                    List<SelectListItem> select_items_dropdown = (from c in temp_categ_list select new SelectListItem { Text = c.Kategoriad, Value = c.Kategoriid.ToString() }).ToList();
                    ViewBag.categories = select_items_dropdown;

                    Uruntablosu new_product = new Uruntablosu();

                    new_product = context.Uruntablosus.FirstOrDefault(a => a.Urunid == id);

                    return View(new_product);
                }
            }
        }

        [HttpPost]
        public ActionResult EditProduct(Uruntablosu new_product)
        {

            if (HttpContext.Session.GetString("IsUserLogged") != "yes")
            {
                return RedirectToAction("Login", "Uye");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    urunManager.Edit(new_product);
                    return RedirectToAction("ListProducts");

                }
                else
                {
                    return View();
                }
            }
        }
    }
}
