using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stok_Takip_Mvc_.net6.Models
{
    public partial class Uruntablosu:IDatabaseEntity
    {
        public Uruntablosu()
        {
            Satistablosus = new HashSet<Satistablosu>();
        }

        public int Urunid { get; set; }

        [Required(ErrorMessage = "Ürün adı boş bırakılamaz")]
        [Display(Name = "Ürün adını giriniz")]
        public string? Urunad { get; set; }

        [Required(ErrorMessage = "Kategori boş bırakılamaz")]
        [Display(Name = "Kategori seçiniz")]
        public int? Kategoriid { get; set; }

        [Required(ErrorMessage = "Ürün fiyatı boş bırakılamaz")]
        [Display(Name = "Ürün fiyatı giriniz")]
        public int? Urunfiyat { get; set; }

        [Required(ErrorMessage = "Ürün stoğu boş bırakılamaz")]
        [Display(Name = "Ürün stoğu giriniz")]
        public int? Urunstok { get; set; }

        public virtual Kategoritablosu? Kategori { get; set; }
        public virtual ICollection<Satistablosu> Satistablosus { get; set; }
    }
}
