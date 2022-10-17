using CatalogBook.Mappers;
using CatalogBook.Models;
using CatalogBook.Repositories.Abstracts;
using CatalogBook.Services.Abstract;

namespace CatalogBook.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepositoryManager _repositoryManager;


        public AuthorService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<AuthorModel> AddOrEditAsync(AuthorModel item)
        {
            var taskResult = await _repositoryManager.AuthorRepository.AddOrEditAsync(item.ToData());

            return taskResult.ToModel();
        }

        public async Task<List<AuthorModel>> GetAllAsync()
        {
            var taskResult = await _repositoryManager.AuthorRepository.GetAllAsync();

            return taskResult.ToModel();
        }

        public async Task<AuthorModel> GetByIdAsync(Guid Id)
        {
            var taskResult = await _repositoryManager.AuthorRepository.GetByIdAsync(Id);

            return taskResult.ToModel();
        }

        public async Task<bool> MarkDeleteLabel(AuthorModel item)
        {
            if(item == null)
            {
                throw new Exception("Не передан объект");
            }

            item.DeleteRecord = !item.DeleteRecord;

            var taskEntityResult = await _repositoryManager.AuthorRepository.AddOrEditAsync(item.ToData());

            return taskEntityResult.DeleteRecord;            
        }

        public async Task<bool> RemoveAsync(AuthorModel item)
        {
            var taskResult = await _repositoryManager.AuthorRepository.RemoveAsync(item.ToData());

            return taskResult;
        }
    }
}
