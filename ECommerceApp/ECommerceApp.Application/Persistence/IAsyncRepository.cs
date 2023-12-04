using ECommerceApp.Domain.Common;

namespace ECommerceApp.Application.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<Result<T>> UpdateAsync(T entity);
        Task<Result<T>> FindByIdAsync(Guid id);
        Task<Result<IReadOnlyList<T>>> GetAllAsync();
        Task<Result<T>> AddAsync(T entity);
        Task<Result<T>> DeleteAsync(Guid id);
        Task<Result<IReadOnlyList<T>>> GetPagedReponseAsync(int page, int size);
    }
}
