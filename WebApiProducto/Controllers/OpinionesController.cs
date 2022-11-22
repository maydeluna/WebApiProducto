﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProducto.DTOs;
using AutoMapper;
using WebApiProducto.Entidades;



namespace WebApiProducto.Controllers
{
    [ApiController]
    [Route("api/productos/{productosId:int}/opiniones")]
    public class OpinionesController : ControllerBase
    {

        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public OpinionesController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<OpinionesDTO>>> Get(int productosId)
        {
            var existe = await dbContext.Productos.AnyAsync(productosDB => productosDB.Id == productosId);

            if (!existe)
            {
                return NotFound();
            }

            var opiniones = await dbContext.Opiniones.Where(opinionesdb => opinionesdb.productosId == productosId).ToListAsync();

            return mapper.Map<List<OpinionesDTO>>(opiniones);
        }


        [HttpPost]
        public async Task<ActionResult> Post(int productosId, OpinionesCreacionDTO opinionesCreacionDTO)
        {
            var existe = await dbContext.Productos.AnyAsync(productosDB => productosDB.Id == productosId);

            if (!existe)
            {
                return NotFound();
            }

            var opinion = mapper.Map<Opiniones>(opinionesCreacionDTO);
            opinion.productosId = productosId;
            dbContext.Add(opinion);
            await dbContext.SaveChangesAsync();
            return Ok();
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(OpinionesCreacionDTO opinionesDto, int id)
        {
            var exist = await dbContext.Opiniones.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }

            var opinion = mapper.Map<Opiniones>(opinionesDto);
            opinion.Id = id;

            dbContext.Update(opinion);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await dbContext.Opiniones.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            dbContext.Remove(new Opiniones()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }

}

