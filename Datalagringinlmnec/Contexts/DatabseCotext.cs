using Datalagringinlmnec.Entities;
using Microsoft.EntityFrameworkCore;

namespace Datalagringinlmnec.Contexts;

internal class DatabseCotext : DbContext
{
    public DatabseCotext(DbContextOptions<DatabseCotext> options) : base(options)
    {
    }

    public DbSet<AdressEntity> Adresses { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
}
