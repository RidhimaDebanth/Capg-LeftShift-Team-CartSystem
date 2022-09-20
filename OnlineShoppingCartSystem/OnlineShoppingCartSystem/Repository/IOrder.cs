namespace OnlineShoppingCartSystem.Repository
{
    public interface IOrder <TEntity,TKey> where TEntity : class
    {
        Task<TEntity> InsertOrder(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllOrders();
        Task<TEntity> GetOrderById(int id);
        Task Save();
    }
}
