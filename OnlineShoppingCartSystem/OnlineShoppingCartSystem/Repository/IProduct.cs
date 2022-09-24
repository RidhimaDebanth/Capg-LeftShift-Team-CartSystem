namespace OnlineShoppingCartSystem.Repository
{
    public interface IProduct<TEntity>where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>>GetByName(string name);
        Task<IEnumerable<TEntity>>GetByCategoryId(int id);
        Task<TEntity> Insert(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Delete(TEntity entity);
        Task Save();
    }
}
