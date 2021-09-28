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
        public String ShortUrl { get; set; }

        [Url(ErrorMessage = "Неподходящий формат ссылки")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [StringLength(100)]
        public String SourceUrl { get; set; }
    }
}
