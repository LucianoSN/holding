using Holding.Company.Domain.Division.Entities;
using Holding.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace Holding.Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<Company.Domain.Company.Entities.Holding> Holdings { get; set; }
    public DbSet<Company.Domain.Company.Entities.Company> Companies { get; set; }

    public DbSet<Group> Groups { get; set; }
    public DbSet<SubGroup> SubGroups { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company.Domain.Company.Entities.Company>().OwnsOne(x => x.Address);
        modelBuilder.Entity<Company.Domain.Company.Entities.Company>().OwnsOne(x => x.Contact);

        modelBuilder
            .Entity<Group>()
            .HasMany(x => x.SubGroups)
            .WithOne(x => x.Group)
            .HasForeignKey(x => x.GroupId);
    }

    public async Task<bool> Commit()
    {
        return await base.SaveChangesAsync() > 0;
    }
}
