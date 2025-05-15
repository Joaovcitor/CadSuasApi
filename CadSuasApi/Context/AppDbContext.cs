using CadSuasApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CadSuasApi.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<FichaCadastralPessoal>? FichaCadastralPessoal { get; set; }
    public DbSet<FichaCadastralProfissional>? FichaCadastralProfissional { get; set; }
    public DbSet<Usuario>? Usuario { get; set; }
    
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<FichaCadastralPessoal>()
    //         .HasOne(p => p.FichaCadastralProfissional)
    //         .WithOne(pf => pf.FichaCadastralPessoal)
    //         .HasForeignKey<FichaCadastralProfissional>(pf => pf.FichaCadastralPessoalId);
    //     
    //     modelBuilder.Entity<FichaCadastralPessoal>()
    //         .HasIndex(p => p.Cpf)
    //         .IsUnique();
    // }
}