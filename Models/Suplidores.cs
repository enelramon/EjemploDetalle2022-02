using System.ComponentModel.DataAnnotations;

namespace EjemploDetalle2022_02.Models
{
    public class Suplidores
    {
        [Key]
        public int SuplidorId { get; set; }
        public string Nombres { get; set; }
    }

}
