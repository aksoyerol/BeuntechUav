using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeuntechSite.Models
{
    [Table("Takim")]
    public class Takim
    {
        [Key]
        public int UyeID { get; set; }

        [Required]
        [StringLength(90)]
        public string AdSoyad { get; set; }

        [Required]
        [StringLength(90)]
        public string Bolum { get; set; }

        [Required]
        [StringLength(300)]
        public string Aciklama { get; set; }

        [Required]
        [StringLength(250)]
        public string UzmanlikAlani { get; set; }

        [Required]
        [StringLength(150)]
        public string Gorev { get; set; }

        [Required]
        [StringLength(200)]
        public string ResimURL { get; set; }

        [DisplayName("Görüş")]
        public string Opinion { get; set; }

        [DisplayName("Görüş Aktif mi ?")]
        public bool IsOpinionActive { get; set; }

        [Required]
        [StringLength(200)]
        public string LinkedIN { get; set; }

        [StringLength(150)]
        public string Instagram { get; set; }

        [StringLength(16)]
        public string Telefon { get; set; }
    }
}