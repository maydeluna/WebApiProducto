namespace WebApiProducto.DTOs
{
    public class ProductosDTOConEmpresas : ProductosDTO
    {
        public List<EmpresaDTO> Empresas { get; set; }
    }
}
