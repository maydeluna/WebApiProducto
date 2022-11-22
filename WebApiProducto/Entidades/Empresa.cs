using System.ComponentModel.DataAnnotations;
using WebApiProducto.Validaciones;

namespace WebApiProducto.Entidades
{
    public class Empresa
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength:250, ErrorMessage ="El campo {0} solo puede tener hasta 250 caracteres")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }
        public List<EmpresaProductos> EmpresasProductos { get; set; }
    }
}
