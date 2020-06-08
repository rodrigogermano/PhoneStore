using PhoneStore.Infra.DataAccess.Contexts;
using PhoneStory.Domain.Interfaces.UnitOfWork;

namespace PhoneStore.Infra.DataAccess.Transactions
{
    public class Uow : IUow
    {
        private readonly PhoneStoreContext _context;

        public Uow(PhoneStoreContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
