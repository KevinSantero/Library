using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Models
{
    public class Editorial
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(100)]
        [Required]
        public string Nombre { get; set; }

        public virtual ICollection<Library> Libros { get; set; }
    }
}
