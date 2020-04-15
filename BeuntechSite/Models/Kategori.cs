using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeuntechSite.Models
{
    [Table("Kategori")]
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }

        [Required]
        [StringLength(50)]
        public string KategoriAd { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Blog> Blog { get; set; }
    }
}
