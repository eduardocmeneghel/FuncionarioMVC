using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace FuncionarioMVC;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
        
    }

    public DbSet<Funcionario> Funcionarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Funcionario>().HasKey(p => p.Id);

        base.OnModelCreating(modelBuilder);
    }
}