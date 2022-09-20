namespace OnlineShoppingCartSystem.Repository
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(TKey id);
        Task<TEntity> GetByName(TKey name);
        Task<TEntity> Insert(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Delete(TEntity entity);
        Task Save();

    }
    
}
