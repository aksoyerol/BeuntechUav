using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeuntechSite.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan"), StringLength(50), DisplayName("Başlık")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan"),StringLength(100),DisplayName("Açıklama")]
        public string Text { get; set; }

        [StringLength(25),DisplayName("Resim")]
        public string ImageUrl { get; set; }

        [DisplayName("Soru Aktif")]
        public bool IsQuestion { get; set; }

        [DisplayName("ResimAktif")]
        public bool IsImageActive { get; set; }
    }
}