using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Stok_Takip_Mvc_.net6.Models;

namespace Stok_Takip_Mvc_.net6.Controllers
{
    public class KategoriController : Controller
    {
        KategoriBLL kategori_manager = new KategoriBLL();
        public IActionResult ListCategories()
        {

            if (HttpContext.Session.GetString("IsUserLogged") != "yes")
            {
                return RedirectToAction("Login", "Uye");
            }
            else
            {
                return View(kategori_manager.List());
            }

        }

        public IActionResult DeleteCategory(int id)
        {

            if (HttpContext.Session.GetString("IsUserLogged") != "yes")
            {
                return RedirectToAction("Login", "Uye");
            }
            else
            {
                Kategoritablosu new_category = new Kategoritablosu();
                using (StokTakipVeritabanıContext context = new StokTakipVeritabanıContext())
                {
                    new_category = context.Kategoritablosus.FirstOrDefault(a => a.Kategoriid == id);
                }

                kategori_manager.Delete(new_category);
                return RedirectToAction("ListCategories");

            }
        }

        [HttpGet]
        public IActionResult AddCategory()
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
        public IActionResult AddCategory(Kategoritablosu new_category)
        {
            if (HttpContext.Session.GetString("IsUserLogged") != "yes")
            {
                return RedirectToAction("Login", "Uye");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    kategori_manager.Add(new_category);
                    return RedirectToAction("ListCategories");

                }
                else
                {
                    return View();
                }
            }

        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            if (HttpContext.Session.GetString("IsUserLogged") != "yes")
            {
                return RedirectToAction("Login", "Uye");
            }
            else
            {
                Kategoritablosu new_category = new Kategoritablosu();
                using (StokTakipVeritabanıContext context = new StokTakipVeritabanıContext())
                {
                    new_category = context.Kategoritablosus.FirstOrDefault(a => a.Kategoriid == id);
                }

                return View(new_category);
            }
        }

        [HttpPost]
        public IActionResult EditCategory(Kategoritablosu editing_category)
        {
            if (HttpContext.Session.GetString("IsUserLogged") != "yes")
            {
                return RedirectToAction("Login", "Uye");
            }
            else
            {

                if (ModelState.IsValid)
                {
                    kategori_manager.Edit(editing_category);
                    return RedirectToAction("ListCategories");
                }
                else
                {
                    return View();
                }


            }
        }
    }
}
