using METRO.digital.Models;
using Microsoft.EntityFrameworkCore;

namespace METRO.digital.Repositories;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {
        
    }

    public DbSet<Basket> Baskets { get; set; }
}