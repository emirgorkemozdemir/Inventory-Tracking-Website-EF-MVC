using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stok_Takip_Mvc_.net6.Models
{
    public partial class Musteritablosu:IDatabaseEntity
    {
        public Musteritablosu()
        {
            Satistablosus = new HashSet<Satistablosu>();
        }

        public int Musteriid { get; set; }

        [Required(ErrorMessage = "Müşteri adı boş bırakılamaz")]
        [Display(Name = "Müşteri adını giriniz")]
        public string? Musteriad { get; set; }

        [Required(ErrorMessage = "Müşteri soyadı boş bırakılamaz")]
        [Display(Name = "Müşteri soyadını giriniz")]
        public string? Musterisoyad { get; set; }

        public virtual ICollection<Satistablosu> Satistablosus { get; set; }
    }
}
