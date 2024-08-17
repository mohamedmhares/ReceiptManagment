using Core.Shared;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReceiptManagment.Core.Receipt;
using System.Reflection;

namespace Infrastructure.Peresistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        public DbSet<Item> Item { get; set; }
        public DbSet<Receipt> Receipt { get; set; }
        public DbSet<ReceiptItem> ReceiptItem { get; set; }

        
        
        

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntityWithDeleted>())
            {
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.IsDeleted = true;
                        break;
                  
                    default:
                        break;
             
                }

            }


            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //DataSeeder.Seed(builder);
            
            base.OnModelCreating(builder);
        }
    }
}
