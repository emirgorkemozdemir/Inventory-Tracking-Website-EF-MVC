using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stok_Takip_Mvc_.net6.Models
{
    public partial class Kategoritablosu : IDatabaseEntity
    {
        public Kategoritablosu()
        {
            Uruntablosus = new HashSet<Uruntablosu>();
        }

      
        public int Kategoriid { get; set; }

        [Required(ErrorMessage = "Kategori adı boş bırakılamaz")]
        [Display(Name = "Kategori adını giriniz")]
        public string? Kategoriad { get; set; }

        public virtual ICollection<Uruntablosu> Uruntablosus { get; set; }
    }
}
