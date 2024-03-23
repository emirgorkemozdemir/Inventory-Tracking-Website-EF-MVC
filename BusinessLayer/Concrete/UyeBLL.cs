using DataAccessLayer.Concrete;
using Stok_Takip_Mvc_.net6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UyeBLL : ManagerRepository<Uyetablosu, UyeDAL>
    {
        UyeDAL dal = new UyeDAL();
        public bool LoginMethodBLL(Uyetablosu logging_user)
        {
           return dal.LoginMethod(logging_user);
        }
    }
}
