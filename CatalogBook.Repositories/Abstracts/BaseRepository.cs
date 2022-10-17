using CatalogBook.Data;
using CatalogBook.Data.Abstract;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CatalogBook.Repositories.Abstracts
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseData
    {
        private readonly DataContext _dataContext;

        public BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<T> AddOrEditAsync(T item)
        {
            try
            {
                if(item is null)
                {
                    throw new Exception("Нет элемента для записи или изменения.");
                }

                if (item.ID == default)
                {
                    _dataContext.Entry<T>(item).State = EntityState.Added;
                }
                else
                {
                    _dataContext.Attach<T>(item);
                    _dataContext.Entry<T>(item).State = EntityState.Modified;
                }

                await _dataContext.SaveChangesAsync();

                await _dataContext.DisposeAsync();

                return item;
            }
            catch (SqlException errorSql)
            {
                throw new Exception(errorSql.Message);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                IQueryable<T> queryable = _dataContext.Set<T>();

                IQueryable<T> queryableInclude = GetIncludeProperty(queryable);

                var result = await queryableInclude.ToListAsync();

                await _dataContext.DisposeAsync();

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<T> GetByIdAsync(Guid Id)
        {
            try
            {
                if (Id == null)
                {
                    throw new Exception("Нет Id элемента.");
                }

                if (Id == default)
                {
                    throw new Exception("Не задан Id элемента.");
                }

                IQueryable<T> queryable = (from x in _dataContext.Set<T>() where x.ID == Id select x);

                IQueryable<T> queryableInclude = GetIncludeProperty(queryable);

                var result = await queryableInclude.FirstOrDefaultAsync();

                await _dataContext.DisposeAsync();

                return result;
            }
            catch (SqlException errorSql)
            {
                throw new Exception(errorSql.Message);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }


        public async Task<bool> RemoveAsync(T item)
        {
            try
            {
                if (item == null)
                {
                    throw new Exception("Не задана сущьность для операции удаление.");
                }

                _dataContext.Attach<T>(item);

                var tt = _dataContext.Remove<T>(item);

                int countEntity = await _dataContext.SaveChangesAsync();

                await _dataContext.DisposeAsync();

                if (countEntity > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }


        protected IQueryable<T> GetIncludeProperty(IQueryable<T> queryable)
        {
            try
            {
                var type = typeof(T);

                var properties = type.GetProperties();

                foreach (var property in properties)
                {
                    if (property.GetGetMethod() != null)
                    {
                        var isVirtual = property.GetGetMethod().IsVirtual;

                        if (isVirtual && !(property.Name.Equals("ID") || property.Name.Equals("DeleteRecord")))
                        {
                            queryable = queryable.Include(property.Name);
                        }
                    }
                }

                return queryable;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
