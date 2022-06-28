using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjemploDetalle2022_02.Models
{
    public class Compras
    {
        [Key]
        public int CompraId { get; set; }
        public DateTime Fecha { get; set; }
        public int SuplidorId { get; set; }
        public double Total { get; set; }

        [ForeignKey("CompraId")]
        public List<ComprasDetalle> Detalle { get; set; } = new List<ComprasDetalle>();

    }

    public class ComprasDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public double Cantidad { get; set; }
        public double Costo { get; set; }

    }

    
}
