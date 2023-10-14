using ApiCatalogo.Context;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriaController (AppDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Categoria> Get ()
        {
            try
            {
                return _context.Categorias.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                return (IEnumerable<Categoria>)StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetCategoria")]
        public ActionResult<Categoria> findById (int id)
        {
            try
            {
                var searchProduto = _context.Categorias.Find(id);

                if (searchProduto == null)
                {
                    return NotFound("Produto não encontado");
                }

                return Ok(searchProduto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Categoria> Post([FromBody] Categoria categoria)
        {
            try
            {
                if (categoria is null)
                {
                    return BadRequest();
                }

                _context.Categorias.Add(categoria);
                _context.SaveChanges();

                return CreatedAtRoute("GetCategoria", new { id = categoria.Id }, categoria);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Categoria> Put(int id, [FromBody] Categoria categoria)
        {
            try
            {
                if (categoria == null || id != categoria.Id)
                {
                    return NoContent();
                }

                var existeProduto = _context.Categorias.Find(id);

                if (existeProduto is null)
                {
                    return BadRequest("Categoria não localizada");
                }

                _context.Entry(existeProduto).CurrentValues.SetValues(categoria);
                _context.SaveChanges();

                return Ok(existeProduto);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Categoria> Delete(int id)
        {
            try
            {
                var searchCategoria = _context.Categorias.Find(id);

                if (searchCategoria is null)
                {
                    return NotFound("Produto não localizado");
                }

                _context.Remove(searchCategoria);
                _context.SaveChanges();

                return Ok("Deletado com sucesso");
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
