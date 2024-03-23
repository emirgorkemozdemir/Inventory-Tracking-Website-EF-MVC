using Stok_Takip_Mvc_.net6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class UyeDAL : EfRepositoryBase<Uyetablosu, StokTakipVeritabanıContext>
    {
        public bool LoginMethod(Uyetablosu logging_user)
        {
            using (StokTakipVeritabanıContext context = new StokTakipVeritabanıContext())
            {
                var selected_user = context.Uyetablosus.FirstOrDefault(a => a.UyeKullanıcıAdı == logging_user.UyeKullanıcıAdı && a.UyeSifre == logging_user.UyeSifre);

                if (selected_user!=null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
