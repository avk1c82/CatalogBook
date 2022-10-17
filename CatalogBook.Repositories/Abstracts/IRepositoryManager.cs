namespace CatalogBook.Repositories.Abstracts
{
    public interface IRepositoryManager
    {
        public IAuthorRepository AuthorRepository { get; }

        public IBookRepository BookRepository { get; }
    }
}
