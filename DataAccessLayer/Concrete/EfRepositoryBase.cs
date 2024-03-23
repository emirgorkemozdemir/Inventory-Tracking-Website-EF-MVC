using DataAccessLayer.Abstract;
using EntityLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using Stok_Takip_Mvc_.net6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class EfRepositoryBase<Tentity, Tcontext> : IEntityDal<Tentity> where Tentity : class, IDatabaseEntity, new()
      where Tcontext : StokTakipVeritabanıContext, new()
    {
        public void Add(Tentity tempEntity)
        {
            //2019103030 using statement usage
            using (Tcontext context = new Tcontext())
            {
                var addEntity = context.Entry(tempEntity);

                addEntity.State = EntityState.Added;

                context.SaveChanges();
            }
        }

        public void Delete(Tentity tempEntity)
        {
            //2019103030 using statement usage
            using (Tcontext context = new Tcontext())
            {
                 
                context.Entry(tempEntity).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        public void Edit(Tentity temp_entity)
        {
            using (Tcontext context = new Tcontext())
            {
                var tempItem = context.Entry(temp_entity);
                tempItem.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<Tentity> List()
        {
         
            using (Tcontext context = new Tcontext())
            {
                return context.Set<Tentity>().ToList();
            }
        }
    }
}
