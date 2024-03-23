using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Stok_Takip_Mvc_.net6.ExtraClasses;
using Stok_Takip_Mvc_.net6.Models;

namespace Stok_Takip_Mvc_.net6.Controllers
{
    public class UyeController : Controller
    {
        UyeBLL uyeManager = new UyeBLL();

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Uyetablosu new_user)
        {
            new_user.UyeSifre = Sha256Converter.ComputeSha256Hash(new_user.UyeSifre);
            uyeManager.Add(new_user);
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Uyetablosu new_user)
        {
            new_user.UyeSifre=Sha256Converter.ComputeSha256Hash(new_user.UyeSifre);
            if (uyeManager.LoginMethodBLL(new_user))
            {
                HttpContext.Session.SetString("IsUserLogged", "yes");
                HttpContext.Session.SetString("LoggedUsername", new_user.UyeKullanıcıAdı);
                return RedirectToAction("ListCategories", "Kategori");

            }
            else
            {
                return RedirectToAction("Register");
            }
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login", "User");
        }
    }
}
