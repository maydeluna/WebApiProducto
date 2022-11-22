using System.ComponentModel.DataAnnotations;
using WebApiProducto.Validaciones;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApiProducto.Entidades
{
    public class Opiniones
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public int productosId { get; set; }
        public Productos Productos { get; set; }
    }
}
