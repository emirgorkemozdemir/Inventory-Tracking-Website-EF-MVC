using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stok_Takip_Mvc_.net6.Models
{
    public partial class Satistablosu :IDatabaseEntity
    {
        public int Satisid { get; set; }

        [Required(ErrorMessage = "Ürün boş bırakılamaz")]
        [Display(Name = "Ürün seçiniz")]
        public int? Urunid { get; set; }

        [Required(ErrorMessage = "Müşteri boş bırakılamaz")]
        [Display(Name = "Müşteri seçiniz")]
        public int? Musteriid { get; set; }


        [Required(ErrorMessage = "Satış adedi boş bırakılamaz")]
        [Display(Name = "Satış adedi giriniz")]
        public int? Satisadet { get; set; }


        [Required(ErrorMessage = "Satış fiyatı boş bırakılamaz")]
        [Display(Name = "Satış fiyatı giriniz")]
        public int? Satisfiyat { get; set; }

        public virtual Musteritablosu? Musteri { get; set; }
        public virtual Uruntablosu? Urun { get; set; }
    }
}
