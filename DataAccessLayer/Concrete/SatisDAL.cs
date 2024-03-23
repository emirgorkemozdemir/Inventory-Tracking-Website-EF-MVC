using Microsoft.EntityFrameworkCore;
using Stok_Takip_Mvc_.net6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class SatisDAL : EfRepositoryBase<Satistablosu, StokTakipVeritabanıContext>
    {
        public static List<Satistablosu> ListJoined()
        {

            using (StokTakipVeritabanıContext context = new StokTakipVeritabanıContext())
            {

                var model = context.Satistablosus.Include(m => m.Musteri).Include(m=>m.Urun).ToList();
                return model;
            }

        }
    }
}
