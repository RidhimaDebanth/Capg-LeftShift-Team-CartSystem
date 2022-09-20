namespace OnlineShoppingCartSystem.Repository
{
    public interface ICart <TEntity,TKey>where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetCart();
        
        Task Save();
    }
}
