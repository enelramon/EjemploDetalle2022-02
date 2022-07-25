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

        public void GenerarPdf(IJSRuntime iJSRuntime)
        {
            Productos productos =new Productos();
            productos.Descripcion = "Pinza";
            RptResult rptResult = new RptResult();
            iJSRuntime.InvokeAsync<Productos>(
                "saveAsFile",
                "Producto_Result.pdf",
                Convert.ToBase64String(rptResult.Report(productos))
            );
            }

    }

}
