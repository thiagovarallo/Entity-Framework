using ApiCatalogo.Context;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> GetAll ()
        {
            try
            {
                var produtos = _context.Produtos.ToList();
                if (produtos is null)
                {
                    return NotFound("Produto não encontrado");
                }

                return produtos;
            } catch (Exception ex) 
            { 
                return StatusCode(500, ex.Message); 
            }
        }

        [HttpGet("/{id}", Name="ObterProduto")]
        public ActionResult<Produto> findById (int id)
        {
            try
            {
                Produto? produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

                if (produto is null)
                {
                    return NotFound("Produto não encontrado");
                }

                return produto;
            } catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Produto> create (Produto produto)
        {
            try
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();

                return new CreatedAtRouteResult("ObterProduto", new { id = produto.Id });
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Produto> Put(int id, [FromBody] Produto produto)
        {
            try
            {
                if (produto == null || id != produto.Id)
                {
                    return BadRequest("Dados inválidos");
                }

                var existingProduto = _context.Produtos.Find(id);

                if (existingProduto == null)
                {
                    return NotFound("Produto não encontrado");
                }

                _context.Entry(existingProduto).CurrentValues.SetValues(produto);
                _context.SaveChanges();

                return Ok(existingProduto);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("/{id}")]
        public ActionResult<Produto> Delete(int id)
        {
            try
            {
                var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);

                if (produto is null)
                {
                    return NotFound("Produto não localizado");
                }

                _context.Produtos.Remove(produto);
                _context.SaveChanges();

                return Ok(produto);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
