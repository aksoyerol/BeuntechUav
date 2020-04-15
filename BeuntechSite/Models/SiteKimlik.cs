using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeuntechSite.Models
{
    [Table("SiteKimlik")]
    public class SiteKimlik
    {
        [Key]
        public int KimlikID { get; set; }

        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Keywords { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(300)]
        public string LogoURL { get; set; }

        [StringLength(250)]
        public string Unvan { get; set; }
    }
}
