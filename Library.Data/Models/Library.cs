using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Models
{
    public class Library
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(500)]
        [Required]
        public string Titulo { get; set; }
        
        [Required]
        public int EditorialId { get; set; }
       
        [Required]
        public DateTime Fecha { get; set; }
        public float Costo { get; set; }

        [Required]
        public float PreciosSugerido { get; set; }

        [Required]
        public string Autor { get; set; }

        public virtual Editorial Editorial { get; set; }
    }
}
