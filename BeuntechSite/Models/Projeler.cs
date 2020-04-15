using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeuntechSite.Models
{
    [Table("Projeler")]
    public class Projeler
    {
        [Key]
        public int ProjeID { get; set; }

        [Required]
        public string Baslik { get; set; }

        
        public string Aciklama { get; set; }

        [StringLength(200)]
        public string ResimURL { get; set; }

    }
}