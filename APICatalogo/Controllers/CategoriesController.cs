using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("product")]
        public ActionResult<IEnumerable<Categorie>> GetCategoriesProduct()
        {
            try
            {
                //Desempenho
                //return _context.Categories.Include(p=>p.Products).ToList();
                //return _context.Categories.Take(10).ToList();  
                return _context.Categories.Include(p => p.Products).Where(c => c.CategorieId <= 5).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Ocorreu um problema ao tratar a sua solicitação");
            }
          
        }
        [HttpGet]
        public ActionResult<IEnumerable<Categorie>> Get()
        {
            var categories = _context.Categories.AsNoTracking().ToList();
            if (categories is null)
            {
                return NotFound("Produts não encontrados");
            }
            return categories;
        }
        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categorie> Get(int id)
        {
            var categories = _context.Categories.FirstOrDefault(c => c.CategorieId == id);
            if(categories is null)
            {
                return NotFound();
            }
            return categories;
        }
        [HttpPost]
        public ActionResult<Categorie> Post(Categorie categorie)
        {
            _context.Categories.Add(categorie);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ObterCategoria", new { id = categorie.CategorieId }, categorie);
        }
        [HttpPut("{id:int}")]
        public ActionResult<Categorie> Put(int id, Categorie categorie)
        {
            if (id != categorie.CategorieId)
            {
                return BadRequest("Error");
            }
            _context.Entry(categorie).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(categorie);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categories = _context.Categories.FirstOrDefault(c => c.CategorieId== id);
            //var categories = _context.Categories.find(id);
            if (categories is null) { return NotFound("Categoria não localizado"); }
            _context.Categories.Remove(categories);
            _context.SaveChanges();
            return Ok();
        }
    }
}
