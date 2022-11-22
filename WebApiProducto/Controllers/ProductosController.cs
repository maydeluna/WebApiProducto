using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProducto.Entidades;
using Microsoft.AspNetCore.Http;
using WebApiProducto.DTOs;
using AutoMapper;

namespace WebApiProducto.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public ProductosController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpGet("/listadoProductos")]
        public async Task<ActionResult<List<Productos>>> GetAll()
        {
            return await dbContext.Productos.ToListAsync();
        }
        [HttpGet("{id:int}", Name = "obtenerProductos")]
        public async Task<ActionResult<ProductosDTOConEmpresas>> GetById(int id)
        {
            var productos = await dbContext.Productos
                .Include(empresaDB => empresaDB.EmpresaProductos)
                .ThenInclude(empresaProductosDB => empresaProductosDB.Empresa)
                .Include(servicioDB => servicioDB.Opiniones)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (productos == null)
            {
                return NotFound();
            }

            productos.EmpresaProductos = productos.EmpresaProductos.OrderBy(x => x.Orden).ToList();

            return mapper.Map<ProductosDTOConEmpresas>(productos);
        }


        [HttpPost]
        public async Task<ActionResult> Post(ProductosCreacionDTO productosCreacionDTO)
        {
            if (productosCreacionDTO.EmpresasIds == null)
            {
                return BadRequest("No se puede iniciar");
            }

            var empresaid = await dbContext.Empresas.Where(empresaBD => productosCreacionDTO.EmpresasIds.Contains(empresaBD.Id)).Select(x => x.Id).ToListAsync();

            if (productosCreacionDTO.EmpresasIds.Count != empresaid.Count)
            {
                return BadRequest("No hay empresa");
            }

            var productos = mapper.Map<Productos>(productosCreacionDTO);



            dbContext.Add(productos);
            await dbContext.SaveChangesAsync();
            var productosDTO = mapper.Map<ProductosDTO>(productos);

            return CreatedAtRoute("obtenerProductos", new { id = productos.Id }, productosDTO);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(ProductosCreacionDTO productosDto, int id)
        {
            var exist = await dbContext.Productos.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }

            var productos = mapper.Map<Productos>(productosDto);
            productos.Id = id;

            dbContext.Update(productos);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await dbContext.Productos.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            dbContext.Remove(new Productos()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }



    }
}
