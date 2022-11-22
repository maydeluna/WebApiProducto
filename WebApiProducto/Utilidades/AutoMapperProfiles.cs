using WebApiProducto.DTOs;
using WebApiProducto.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.WebUtilities;


namespace WebApiProducto.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<EmpresaCreacionDTO, Empresa>();
            CreateMap<Empresa, EmpresaDTO>();
            CreateMap<Empresa, EmpresaDTOProductos>().ForMember(EmpresaDTO => EmpresaDTO.Productos, opciones => opciones.MapFrom(MapEmpresaDTOProductos));

            CreateMap<ProductosCreacionDTO, Productos>().ForMember(Productos => Productos.EmpresaProductos, opciones => opciones.MapFrom(MapEmpresaProductos));

            CreateMap<Productos, ProductosDTO>();
            CreateMap<Productos, ProductosDTOConEmpresas>().ForMember(ProductosDTO => ProductosDTO.Empresas, opciones => opciones.MapFrom(MapProductosDTOEmpresa));

            CreateMap<OpinionesCreacionDTO, Opiniones>();
            CreateMap<Opiniones, OpinionesDTO>();
        }

        private List<ProductosDTO> MapEmpresaDTOProductos(Empresa empresa, EmpresaDTO empresaDTO)
        {
            var resultado = new List<ProductosDTO>();
            if(empresa.EmpresasProductos == null)
            {
                return resultado;
            }

            foreach( var empresaProductos in empresa.EmpresasProductos)
            {
                resultado.Add(new ProductosDTO()
                {
                    Id = empresaProductos.ProductosId,
                    Nombre = empresaProductos.Productos.Nombre
                });
            }
            return resultado;
        }

       
        private List<EmpresaDTO> MapProductosDTOEmpresa(Productos productos, ProductosDTO productosDTO)
        {
            var resultado = new List<EmpresaDTO>();
            if(productos.EmpresaProductos == null)
            {
                return resultado;
            }

            foreach( var empresaProductos in productos.EmpresaProductos)
            {
                resultado.Add(new EmpresaDTO()
                {
                    Id = empresaProductos.EmpresaId,
                    Nombre = empresaProductos.Productos.Nombre
                }); ;
            }
            return resultado;
        }

        private List<EmpresaProductos> MapEmpresaProductos(ProductosCreacionDTO productosCreacionDTO, Productos productos)
        {
            var resultado = new List<EmpresaProductos>();
            if (productosCreacionDTO.EmpresasIds == null)
            {
                return resultado;
            }

            foreach (var empresaid in productosCreacionDTO.EmpresasIds)
            {
                resultado.Add(new EmpresaProductos()
                {
                    EmpresaId = empresaid
                });
            }
            return resultado;
        }



    }
}
