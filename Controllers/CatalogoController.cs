using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVen.Models;
using SistemaVen.Data;
using Microsoft.EntityFrameworkCore;
namespace SistemaVen.Controllers
{

    public class CatalogoController : Controller
    {
        private readonly ILogger<CatalogoController> _logger;
        private readonly ApplicationDbContext _context;

        public CatalogoController(ApplicationDbContext context,
            ILogger<CatalogoController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(string? searchString)
        {
            var catalogos = from o in _context.DataCatalogos select o;
            if(!String.IsNullOrEmpty(searchString)){
                catalogos = catalogos.Where(s => s.Nombre.Contains(searchString));
            }
            return View(await catalogos.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            Catalogo objCatalog = await _context.DataCatalogos.FindAsync(id);
            if(objCatalog == null){
                return NotFound();
            }
            return View(objCatalog);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}