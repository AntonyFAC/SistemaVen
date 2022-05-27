using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaVen.Models;

namespace SistemaVen.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<SistemaVen.Models.Catalogo> DataCatalogos {get; set;}
    public DbSet<SistemaVen.Models.Proforma> DataProforma { get; set; }

    public DbSet<SistemaVen.Models.Pago> DataPago {get; set;}
}
