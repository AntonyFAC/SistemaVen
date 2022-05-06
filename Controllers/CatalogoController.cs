using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVen.Models;
using SistemaVen.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SistemaVen.util;
using Microsoft.AspNetCore.Http;


namespace SistemaVen.Controllers
{

    public class CatalogoController : Controller
    {
        private readonly ILogger<CatalogoController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CatalogoController(ApplicationDbContext context,
            ILogger<CatalogoController> logger,
            UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
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

        public async Task<IActionResult> Add(int? id){
            var userID = _userManager.GetUserName(User);
            if(userID == null){
                ViewData["Message"] = "Por favor debe loguearse antes de agregar un producto";
                List<Catalogo> catalogos = new List<Catalogo>();
                return View("Index", catalogos);
            }else{
                var catalogo = await _context.DataCatalogos.FindAsync(id);
                Proforma proforma = new Proforma();
                proforma.Producto = catalogo;
                proforma.Precio = catalogo.Precio;
                proforma.Cantidad = 1;
                proforma.UserID = userID;
                _context.Add(proforma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }
    }
}