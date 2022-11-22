using System.ComponentModel.DataAnnotations;
using WebApiProducto.Validaciones;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiProducto.Entidades
{
    public class EmpresaProductos
    {
        public int Orden { get; set; }
        public int ProductosId { get; set; }
        public int EmpresaId { get; set; }
        public Productos Productos { get; set; }
        public Empresa Empresa { get; set; }
    }
}
