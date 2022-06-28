using EjemploDetalle2022_02.DAL;
using EjemploDetalle2022_02.Models;
using Microsoft.EntityFrameworkCore;

namespace EjemploDetalle2022_02.BLL
{
    public class ProductosBLL
    {
        private Contexto _contexto;

        public ProductosBLL( Contexto contexto)
        {
            _contexto = contexto;
        }

        public Productos? Buscar(int id)
        {
            return _contexto.Productos
                .Where(p => p.ProductoId == id)
                .AsNoTracking()
                .SingleOrDefault();
        }

        public List<Productos> GetList()
        {
            return _contexto.Productos
                .AsNoTracking()
                .ToList();
        }
    }
}
