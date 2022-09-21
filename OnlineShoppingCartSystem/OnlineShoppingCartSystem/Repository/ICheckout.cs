using OnlineShoppingCartSystem.Models;

namespace OnlineShoppingCartSystem.Repository
{
    public interface ICheckout<TEntity>where TEntity : class
    {
        Task<TEntity> UpdateDetails(TEntity entity);
        Task Save();
        
    }
}
