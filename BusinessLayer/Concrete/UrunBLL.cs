using DataAccessLayer.Concrete;
using Stok_Takip_Mvc_.net6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UrunBLL : ManagerRepository<Uruntablosu,UrunDAL>
    {
        public List<Uruntablosu> ListJoinedBLL()
        {
            return UrunDAL.ListJoined();
        }
    }
}
