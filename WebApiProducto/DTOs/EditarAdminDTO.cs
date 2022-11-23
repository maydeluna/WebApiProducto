using System.ComponentModel.DataAnnotations;

namespace WebApiProducto.DTOs
{
    public class EditarAdminDTO
    {
        [Required]
        [EmailAddress]

        public string Email { get; set; }
    }
}
