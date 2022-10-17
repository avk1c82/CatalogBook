using CatalogBook.Mappers;
using CatalogBook.Models;
using CatalogBook.Repositories.Abstracts;
using CatalogBook.Services.Abstract;

namespace CatalogBook.Services
{
    public class BookService : IBookService
    {
        private readonly IRepositoryManager _repositoryManager;

        public BookService(IRepositoryManager reapositoryManager)
        {
            _repositoryManager = reapositoryManager;
        }

        public async Task<BookModel> AddOrEditAsync(BookModel item)
        {
            var taskResult = await _repositoryManager.BookRepository.AddOrEditAsync(item.ToData());

            return taskResult.ToModel();
        }

        public async Task<List<BookModel>> GetAllAsync()
        {
            var taskResult = await _repositoryManager.BookRepository.GetAllAsync();

            return taskResult.ToModel();
        }

        public async Task<BookModel> GetByIdAsync(Guid Id)
        {
            var taskResult = await _repositoryManager.BookRepository.GetByIdAsync(Id);

            return taskResult.ToModel();
        }

        public async Task<bool> MarkDeleteLabel(BookModel item)
        {
            if (item == null)
            {
                throw new Exception("Не передан объект");
            }

            item.DeleteRecord = !item.DeleteRecord;

            var taskEntityResult = await _repositoryManager.BookRepository.AddOrEditAsync(item.ToData());

            return taskEntityResult.DeleteRecord;
        }

        public async Task<bool> RemoveAsync(BookModel item)
        {
            var taskResult = await _repositoryManager.BookRepository.RemoveAsync(item.ToData());

            return taskResult;
        }
    }
}
