using Microsoft.EntityFrameworkCore;
using ProjetoAEC.Models;

namespace ProjetoAEC.Servcos
{

public class DbContexto : DbContext
  {
    public DbContexto(DbContextOptions<DbContexto> options) : base (options) { }

    public DbSet<Candidato> Candidatos { get; set; }
    public DbSet<Profissao> Profissoes { get; set; }
  }
}