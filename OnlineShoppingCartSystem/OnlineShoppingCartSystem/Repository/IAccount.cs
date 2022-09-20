namespace OnlineShoppingCartSystem.Repository
{
    public interface IAccount <TEntity, TKey> where TEntity : class
    {
        Task<TEntity> Insert(TEntity entity);
        Task<TEntity> GetByUserId(TKey id);

        Task Save();
    }
}
