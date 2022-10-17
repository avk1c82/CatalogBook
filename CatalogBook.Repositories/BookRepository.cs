using CatalogBook.Data;
using CatalogBook.Repositories.Abstracts;

namespace CatalogBook.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
