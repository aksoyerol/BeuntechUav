using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [StringLength(16), DisplayName("Telefon")]
        public string Tel { get; set; }

        [StringLength(16)]
        public string Whatsapp { get; set; }

        [StringLength(20),DisplayName("LinkedIn")]
        public string LinkedIn { get; set; }

        [StringLength(16)]
        public string Facebook { get; set; }

        [StringLength(20),DisplayName("E-Posta")]
        public string EMail { get; set; }

        [StringLength(16)]
        public string Instagram { get; set; }
        
    }
}