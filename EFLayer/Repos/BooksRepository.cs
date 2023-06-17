using Core.Interfaces;
using Core.Models;

namespace EFLayer.Repos
{
    public class BooksRepository : BaseRepository<Book>, IBooksRepository
    {
        private readonly ApplicationDBContext _context;

        public BooksRepository(ApplicationDBContext context)
            : base(context) { }

        public IEnumerable<Book> SpecialMethod()
        {
            throw new NotImplementedException();
        }
    }
}
