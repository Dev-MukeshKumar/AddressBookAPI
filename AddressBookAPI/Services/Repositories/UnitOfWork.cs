using AddressBookAPI.Context;

namespace AddressBookAPI.Services.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AddressBookDbContext _context;

        public UnitOfWork(AddressBookDbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
