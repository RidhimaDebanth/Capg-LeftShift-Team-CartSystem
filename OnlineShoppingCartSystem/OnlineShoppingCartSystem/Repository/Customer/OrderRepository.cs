using Microsoft.EntityFrameworkCore;
using OnlineShoppingCartSystem.Models;

namespace OnlineShoppingCartSystem.Repository.Customer
{
    public class OrderRepository : IOrder<Orders>
    {
        private readonly OnlineShoppingCartDBContext _dbContext;
        public OrderRepository(OnlineShoppingCartDBContext _dbcontext) => this._dbContext = _dbcontext;

        public async Task<Orders> AddOrder(Orders entity)
        {
            try
            {
                var o = new Orders()
                {
                    Id = entity.Id,
                    UsersId = entity.UsersId,
                    DateOfOrder = entity.DateOfOrder,
                    ModeOfPayment=entity.ModeOfPayment,
                    BillAmount=entity.BillAmount,

                };
               _dbContext.Orders.Add(o);
                await _dbContext.SaveChangesAsync();
                return o;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        #region Get methods
        //retrieving
        public async Task<IEnumerable<Orders>> GetAllOrders()
        {
            try
            {
                //return await _dbContext.Orders.ToListAsync();
                var orders = await _dbContext.Orders.Select(o => new Orders()
                {
                    Id = o.Id,
                    UsersId = o.UsersId,
                    DateOfOrder = o.DateOfOrder,
                    //ProductId = o.ProductId,
                    //ProductName = o.ProductName,
                    //ProductImage = o.ProductImage,
                    //Product = o.Product,
                    ModeOfPayment = o.ModeOfPayment,
                    BillAmount = o.BillAmount,
                }).ToListAsync();
                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Orders>> GetOrdersByUserId(int userid)
        {
            try
            {
                var orders = await _dbContext.Orders.Where(o => o.UsersId == userid).Select(o => new Orders()
                {
                    Id = o.Id,
                    UsersId = o.UsersId,
                    DateOfOrder= o.DateOfOrder,
                    //ProductId = o.ProductId,
                    //ProductName = o.ProductName,
                    //ProductImage = o.ProductImage,
                    //Product = o.Product,
                    ModeOfPayment = o.ModeOfPayment,
                    BillAmount = o.BillAmount,

                }).ToListAsync();
                return orders;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion
       
        
        //public async Task<Orders> InsertOrder(Orders entity)
        //{
        //    var order=new Orders()
        //    {
        //        Id=entity.Id,
        //        UsersId=entity.UsersId,
        //        ProductId=entity.ProductId,
        //        ProductName=entity.ProductName,
        //        ProductImage=entity.ProductImage,
        //        ModeOfPayment=entity.ModeOfPayment,
        //        TotalAmount=entity.TotalAmount,
        //    };
        //    _dbContext.Orders.Add(order);
        //    await _dbContext.SaveChangesAsync();
        //    return order;
        //    //await _dbContext.Orders.AddAsync(entity);
        //    //_dbContext.SaveChanges();
        //    //return entity;
        //}

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
