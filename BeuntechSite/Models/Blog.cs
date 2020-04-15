using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeuntechSite.Models
{
    [Table("Blog")]
    public partial class Blog
    {
        [Key]
        public int BlogID { get; set; }

        [Required]
        [StringLength(150)]
        public string Baslik { get; set; }

        [Required]
        public string Icerik { get; set; }

        public string ResimURL { get; set; }

        public int KategoriID { get; set; }

        public Kategori Kategori { get; set; }

        public DateTime? tarih { get; set; }
    }
}