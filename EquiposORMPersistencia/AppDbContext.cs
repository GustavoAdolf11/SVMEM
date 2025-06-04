using EquiposORM.Dominio;
using Microsoft.EntityFrameworkCore;

namespace EquiposORM.Persistencia;

public class AppDbContext : DbContext
{
    public DbSet<Equipo> Equipos { get; set; }
    public DbSet<Tecnico> Tecnicos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=equipos.db");
    }
}