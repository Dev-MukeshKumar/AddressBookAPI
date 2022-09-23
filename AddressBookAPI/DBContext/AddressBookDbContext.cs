using AddressBookAPI.Entities.DataSets;
using Microsoft.EntityFrameworkCore;

namespace AddressBookAPI.DBContext
{
    public class AddressBookDbContext: DbContext
    {
        public AddressBookDbContext(DbContextOptions<AddressBookDbContext> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<AddressBook> AddressBooks { get; set; }

        public DbSet<Email> Emails { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Phone> Phones { get; set; }

        public DbSet<Asset> Assets { get; set; }

        public DbSet<RefSet> RefSets { get; set; }

        public DbSet<RefTerm> RefTerms { get; set; }

        public DbSet<RefSetMapping> RefSetMappings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        } 
    }
}
