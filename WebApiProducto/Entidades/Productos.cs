using System.ComponentModel.DataAnnotations;
using WebApiProducto.Validaciones;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiProducto.Entidades
{
    public class Productos 
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 250, ErrorMessage = "El campo {0} solo puede tener hasta 250 caracteres")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }
        public List<Opiniones> Opiniones{ get; set; }
        public List<EmpresaProductos> EmpresaProductos { get; set; }

    
    }
}
