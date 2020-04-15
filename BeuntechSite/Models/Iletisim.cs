using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeuntechSite.Models
{
    [Table("Iletisim")]
    public class Iletisim
    {
        [Key]
        public int IletisimID { get; set; }

        [Required]
        [StringLength(200)]
        public string Adres { get; set; }

        [StringLength(16)]
        public string Tel { get; set; }

        [StringLength(16)]
        public string Whatsapp { get; set; }

        [StringLength(16)]
        public string Facebook { get; set; }

        [StringLength(16)]
        public string Instagram { get; set; }
        
    }
}