using CatalogBook.Repositories.Abstracts;

namespace CatalogBook.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IAuthorRepository _authorRepository;

        private readonly IBookRepository _bookRepository;


        public RepositoryManager(IAuthorRepository authorRepository,
                                    IBookRepository bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }

        public IAuthorRepository AuthorRepository { get { return _authorRepository; } }

        public IBookRepository BookRepository { get { return _bookRepository; } }
    }
}
