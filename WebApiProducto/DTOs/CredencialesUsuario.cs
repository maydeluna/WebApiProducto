using System.ComponentModel.DataAnnotations;

namespace WebApiProducto.DTOs
{
    public class CredencialesUsuario
    {
        [Required]
        [EmailAddress]

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
