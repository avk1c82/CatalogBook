using CatalogBook.Data;
using CatalogBook.Repositories.Abstracts;

namespace CatalogBook.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
