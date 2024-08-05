using Holding.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace Holding.Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options), IUnitOfWork
{
   public DbSet<Company.Domain.Company.Entities.Holding> Holdings { get; set; }
   
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      optionsBuilder.UseInMemoryDatabase(databaseName: "FakeDatabase");
   }

   public async Task<bool> Commit()
   {
      return await base.SaveChangesAsync() > 0;
   }
}