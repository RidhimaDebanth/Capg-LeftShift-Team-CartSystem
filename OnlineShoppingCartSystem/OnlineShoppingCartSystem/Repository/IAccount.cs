namespace OnlineShoppingCartSystem.Repository
{
    public interface IAccount <TEntity> where TEntity : class
    {
        Task<TEntity> Insert(TEntity entity);
        Task<TEntity> GetByUserId(int id);
        Task<TEntity> GetByUsername(string username);
        Task DeleteUserAccount(TEntity entity);

        Task Save();
    }
}
