using Microsoft.EntityFrameworkCore;
using Tp04WebAPI.Models;

namespace Tp04WebAPI.Data;

public class AppDbContext : DbContext
{
    public DbSet<Produto> Produtos => Set<Produto>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}