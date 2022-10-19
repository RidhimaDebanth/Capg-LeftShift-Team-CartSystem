namespace OnlineShoppingCartSystem.Repository
{
    public interface IOrder <TEntity> where TEntity : class
    {
        //Task<TEntity> InsertOrder(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllOrders();
        Task<IEnumerable<TEntity>> GetOrdersByUserId(int userid);
        Task<TEntity> AddOrder(TEntity entity);
        Task Save();
    }
}
