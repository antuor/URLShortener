using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace URL_Shortener.Models
{
    [Table("URLs")]
    public class URLs
    {
        [Key]
        [Required]
        [StringLength(10)]
        public String shortUrl { get; set; }

        [Required]
        [StringLength(60)]
        public String sourceUrl { get; set; }
    }
}
