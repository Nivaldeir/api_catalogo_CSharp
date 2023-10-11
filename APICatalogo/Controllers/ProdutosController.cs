using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
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

        //GET
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var produtos = _context.Products.AsNoTracking().ToList();
            if (produtos is null)
            {
                return NotFound("Produts não encontrados");
            }
            return produtos;
        }
        [HttpGet("{id:int}",Name ="ObterProduto")]
        public ActionResult<Product>Get(int id)
        {
            var product = _context.Products.FirstOrDefault( p => p.ProductId == id);
            if(product is null)
            {
                return NotFound("Produto não encontrado...");
            }
            return product;
        }
        [HttpPost]
        public ActionResult Post(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ObterProduto", new { id = product.ProductId }, product);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Product product) 
        {
            if(id != product.ProductId)
            {
                return BadRequest("Error");
            }
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(product);
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _context.Products.FirstOrDefault(p => p.ProductId == id);
            //var produto = _context.Products.find(id);

            if (produto is null) { return NotFound("Produto não localizado"); }
            _context .Products.Remove(produto);
            _context .SaveChanges();    
            return Ok();
        }
    }

}