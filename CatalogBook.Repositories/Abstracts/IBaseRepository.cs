namespace CatalogBook.Repositories.Abstracts
{
    public interface IBaseRepository<T>
    {
        public Task<T> AddOrEditAsync(T? item);

        public Task<List<T>> GetAllAsync();

        public Task<T> GetByIdAsync(Guid Id);

        public Task<bool> RemoveAsync(T item);

        //public Task<bool> MarkDeleteon(Guid Id);
    }
}
