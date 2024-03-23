using Microsoft.EntityFrameworkCore;
using Stok_Takip_Mvc_.net6.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class UrunDAL : EfRepositoryBase<Uruntablosu, StokTakipVeritabanıContext>
    {
        public static List<Uruntablosu> ListJoined()
        {

            using (StokTakipVeritabanıContext context = new StokTakipVeritabanıContext())
            {

                var model = context.Uruntablosus.Include(m=>m.Kategori).ToList();
                return model;
            }
            
        }
    }
}
