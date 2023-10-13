using ApiCatalogo.Context;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Mvc;

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
            return _context.Categorias.ToList();
        }

        [HttpGet("{id}", Name = "GetCategoria")]
        public ActionResult<Categoria> findById (int id)
        {
            var searchProduto = _context.Categorias.Find(id);

            if (searchProduto == null)
            {
                return NotFound("Produto não encontado");
            }

            return Ok(searchProduto);
        }

        [HttpPost]
        public ActionResult<Categoria> Post([FromBody] Categoria categoria)
        {
            if (categoria is null)
            {
                return BadRequest();
            }

            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return CreatedAtRoute("GetCategoria", new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        public ActionResult<Categoria> Put(int id, [FromBody] Categoria categoria)
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

        [HttpDelete("{id}")]
        public ActionResult<Categoria> Delete(int id)
        {
            var searchCategoria = _context.Categorias.Find(id);

            if (searchCategoria is null)
            {
                return NotFound("Produto não localizado");
            }

            _context.Remove(searchCategoria);
            _context.SaveChanges();

            return Ok("Deletado com sucesso");
        }
    }
}
