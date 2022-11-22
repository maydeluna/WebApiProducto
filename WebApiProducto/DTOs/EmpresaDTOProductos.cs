using WebApiProducto.Entidades;

namespace WebApiProducto.DTOs
{
    public class EmpresaDTOProductos : EmpresaDTO
    {
        public List<EmpresaProductos> Productos { get; set; }
    }
}
