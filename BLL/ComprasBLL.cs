using EjemploDetalle2022_02.DAL;
using EjemploDetalle2022_02.Models;
using Microsoft.EntityFrameworkCore;

namespace EjemploDetalle2022_02.BLL
{
    public class ComprasBLL
    {
        private Contexto _contexto;
        public ComprasBLL(Contexto contexto)
        {
            _contexto = contexto;
        }
        
        public bool Existe(int id)
        {
            return _contexto.Compras
                .Any(c => c.CompraId == id);
        }

        public bool Guardar(Compras compra)
        {
            if (!Existe(compra.CompraId))
               return this.Insertar(compra);
            else
                return this.Modificar(compra);
        }


        private bool Insertar(Compras compra) {
            _contexto.Compras.Add(compra);

            //sumar el inventario nuevamente
            foreach (var item in compra.Detalle)
            {
                var producto = _contexto.Productos.Find(item.ProductoId);
                producto.Existencia += item.Cantidad;
            }

            _contexto.Compras.Add(compra);
            
            return _contexto.SaveChanges() > 0;
        }
        
        private bool Modificar(Compras compra) {

            //bucar el detalle anterior

            //restar el inventario del detalle anterior

            //borrar los items del detalle anterior
            
            //sumar el inventario nuevamente
            
            _contexto.Entry(compra).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }
        public bool Eliminar(Compras compra)
        {
            _contexto.Entry(compra).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }

        public Compras? Buscar(int compraId)
        {
            return _contexto.Compras
                .Include(c => c.Detalle)
                .Where(c => c.CompraId == compraId)
                .AsNoTracking()
                .SingleOrDefault();
        }
        public List<Compras> GetList()
        {
            return _contexto.Compras.AsNoTracking().ToList();
        }
    }
}
