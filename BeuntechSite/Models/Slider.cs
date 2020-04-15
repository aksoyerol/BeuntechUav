using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeuntechSite.Models
{
    [Table("Slider")]
    public class Slider
    {
        [Key]
        public int SliderID { get; set; }

        [DisplayName("SliderBaslik"), StringLength(30, ErrorMessage = "Maksimum 30 karakter olmalıdır !")]
        public string Baslik { get; set; }

        [DisplayName("SliderAciklama"), StringLength(150, ErrorMessage = "Maksimum 150 karakter olmalıdır !")]
        public string Aciklama { get; set; }

        [DisplayName("SliderResim"), StringLength(500)]
        public string ResimURL { get; set; }

    }
}