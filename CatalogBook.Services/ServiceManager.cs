using CatalogBook.Services.Abstract;

namespace CatalogBook.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IAuthorService _authorService;

        private readonly IBookService _bookService;

        public ServiceManager(IAuthorService authorService, IBookService bookService)
        {
            _authorService = authorService;
            _bookService = bookService;
        }

        public IAuthorService AuthorService { get { return _authorService; } }

        public IBookService BookService { get { return _bookService; } }
    }
}
