namespace WebApiProducto.DTOs
{
    public class ProductosDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<OpinionesDTO> Opiniones { get; set; }
    }
}
