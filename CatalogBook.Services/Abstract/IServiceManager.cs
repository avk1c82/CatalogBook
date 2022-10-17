namespace CatalogBook.Services.Abstract
{
    public interface IServiceManager
    {
        public IAuthorService AuthorService { get; }

        public IBookService BookService { get; }
    }
}
