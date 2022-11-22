using WebApiProducto.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace WebApiProducto.DTOs
{
    public class EmpresaCreacionDTO
    {
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(maximumLength:25, ErrorMessage ="El campo es invalido")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }
    }
}
