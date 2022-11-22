using WebApiProducto.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace WebApiProducto.DTOs
{
    public class ProductosCreacionDTO
    {
        [PrimeraLetraMayuscula]
        [StringLength(maximumLength: 250)]
        public string Nombre { get; set; }
        public List<int> EmpresasIds { get; set; }
    }
}
