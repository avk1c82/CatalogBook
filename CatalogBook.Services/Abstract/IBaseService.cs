using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogBook.Services.Abstract
{
    public interface IBaseService<T>
    {
        public Task<T> AddOrEditAsync(T item);

        public Task<List<T>> GetAllAsync();

        public Task<T> GetByIdAsync(Guid id);

        public Task<bool> MarkDeleteLabel(T item);

        public Task<bool> RemoveAsync(T item);
    }
}
