using System.ComponentModel.DataAnnotations;
using Microsoft.JSInterop;

namespace EjemploDetalle2022_02.Models
{
    public class Productos
    {

        [Key]
        public int ProductoId { get; set; }
        public string? Descripcion { get; set; }
        public double Precio { get; set; }
        public double Costo { get; set; }
        public double Existencia { get; set; }
    }
}
