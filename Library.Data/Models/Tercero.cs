
using System;
using System.ComponentModel.DataAnnotations;

namespace TecnicalTestPersonas.Data.Models
{
    public class Tercero
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(15)]
        [Required]
        public string Documento { get; set; }

        [MaxLength(100)]
        [Required]
        public string Nombre { get; set; }

        [MaxLength(100)]
        [Required]
        public string Apellido { get; set; }


        //[MaxLength(100)]
        //[Required]
        //public DateTime FechaNacimiento { get; set; }


        [MaxLength(100)]
        public string CorreoElectronico1 { get; set; }

        [MaxLength(100)]
        public string CorreoElectronico2 { get; set; }



        [MaxLength(15)] 
        public string Tel1 { get; set; }

        [MaxLength(15)]
        public string Tel2{ get; set; }



        [MaxLength(500)]
        public string Direccion1 { get; set; }

        [MaxLength(500)]
        public string Direccion2 { get; set; }

    }
}
