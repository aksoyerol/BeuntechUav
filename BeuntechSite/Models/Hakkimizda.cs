using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeuntechSite.Models
{
    [Table("Hakkimizda")]
    public class Hakkimizda
    {
        [Key]
        public int HakkimizdaID { get; set; }

        public string ResimUrl { get; set; }
      
        public string Baslik { get; set; }

        [Required]
        public string Aciklama { get; set; }
    }
}