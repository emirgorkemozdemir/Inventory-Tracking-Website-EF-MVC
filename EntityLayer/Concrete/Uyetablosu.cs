using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stok_Takip_Mvc_.net6.Models
{
    public partial class Uyetablosu:IDatabaseEntity
    {
        public int UyeId { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz")]
        [Display(Name = "Kullanıcı adınızı giriniz")]
        public string UyeKullanıcıAdı { get; set; } = null!;

        [Required(ErrorMessage = "Şifre boş bırakılamaz")]
        [Display(Name = "Şifrenizi giriniz")]
        [DataType(DataType.Password)]
        public string UyeSifre { get; set; } = null!;
    }
}
