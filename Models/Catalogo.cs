using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVen.Models
{
    [Table("t_catalogo")]
    public class Catalogo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("id")]
        public int Id {get; set;}

        public string Nombre {get; set;}
        public string Talla {get; set;}
        public string Descripcion {get; set;}

        public Decimal Precio {get; set;}

        public String ImageName {get; set;}

    }
}