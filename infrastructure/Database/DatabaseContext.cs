using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Web.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        
    }

    public DbSet<PhoneModel> Phones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PhoneModel>().HasKey(model => model.Id);
        modelBuilder.Entity<PhoneModel>().HasQueryFilter(model => model.DeletedAt == null);
        modelBuilder.Entity<PhoneModel>().Property(x => x.PhoneName).IsRequired();
        modelBuilder.Entity<PhoneModel>().Property(x => x.Company).IsRequired();
        modelBuilder.Entity<PhoneModel>().Property(x => x.Price).IsRequired();
        modelBuilder.Entity<PhoneModel>().Property(x => x.ProductYear).IsRequired();
    }
}