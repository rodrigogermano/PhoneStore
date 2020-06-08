using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PhoneStore.Infra.DataAccess.Mappings;
using PhoneStory.Domain.Entities;

namespace PhoneStore.Infra.DataAccess.Contexts
{
    public class PhoneStoreContext : DbContext
    {
        private readonly ILoggerFactory _logger;
        public PhoneStoreContext(
            DbContextOptions<PhoneStoreContext> options
            ,ILoggerFactory logger
            )
        : base(options)
        {
            _logger = logger;
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {                        
            builder.ApplyConfiguration(new ProductMap());            
            builder.ApplyConfiguration(new CellPhoneMap());
            builder.ApplyConfiguration(new AccessoryMap());
        }
    }
}
