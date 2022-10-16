using Microsoft.EntityFrameworkCore;
using OnlineShoppingCartSystem.Models;
using System.Collections.Generic;

namespace OnlineShoppingCartSystem.Repository.Admin
{
    public class ProductRepository : IProduct<Product>
    {
        private readonly OnlineShoppingCartDBContext context;
        public ProductRepository(OnlineShoppingCartDBContext context) => this.context = context;

       
        
        #region Insert a product
        //Adding a product 
        public async Task<Product> Insert(Product entity)
        {
            try
            {
                var p = new Product()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    ProductDescription = entity.ProductDescription,
                    Price = entity.Price,
                    ProductImage = entity.ProductImage,
                    CategoryId = entity.CategoryId,

                };
                context.Products.Add(p);
                await context.SaveChangesAsync();
                return p;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            //await context.Products.AddAsync(entity);
            //context.SaveChanges();
            //return entity;
        }
        #endregion

      
        #region Get methods
        //Retrieving data

        public async Task<IEnumerable<Product>> GetAll()
        {
            try
            {
                var products = await context.Products.Select(p => new Product()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ProductDescription = p.ProductDescription,
                    Price = p.Price,
                    ProductImage = p.ProductImage,
                    CategoryId = p.CategoryId,
                    Category = p.Category
                }).ToListAsync();
                return products;
                //return await context.Products.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Product> GetById(int id)
        {
            try
            {
                var product = await context.Products.Where(p => p.Id == id).Select(p => new Product()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ProductDescription = p.ProductDescription,
                    Price = p.Price,
                    ProductImage = p.ProductImage,
                    CategoryId = p.CategoryId
                }).FirstOrDefaultAsync();
                return product;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Product> >GetByName(string name)
        {
            try
            {
                var product = await context.Products.Where(p => p.Name == name).Select(p => new Product()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ProductDescription = p.ProductDescription,
                    Price = p.Price,
                    ProductImage = p.ProductImage,
                    CategoryId = p.CategoryId,
                    Category = p.Category
                }).ToListAsync();
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<Product>> GetByCategoryId(int categoryId)
        {
            try
            {
                var product = await context.Products.Where(p => p.CategoryId == categoryId).Select(p => new Product()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ProductDescription = p.ProductDescription,
                    Price = p.Price,
                    ProductImage = p.ProductImage,
                    CategoryId = p.CategoryId,
                    Category = p.Category
                }).ToListAsync();
                return product;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        #endregion


        #region Update product
        //Modifying a product
        public async Task<Product> Update(Product entity)
        {
            try
            {
                //throw new NotImplementedException();
                var product = await context.Products.FirstOrDefaultAsync(p => p.Id == entity.Id);
                if (product != null)
                {
                    product.Name = entity.Name;
                    product.ProductDescription = entity.ProductDescription;
                    product.Price = entity.Price;
                    product.ProductImage = entity.ProductImage;
                    product.CategoryId = entity.CategoryId;
                    context.SaveChanges();


                }
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

      
        #region Delete a product
        //removing a product
        public async Task Delete(int id)
        {
            try
            {
                var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    context.Remove(product);
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion
       
        
        public async Task Save()
        {

            await context.SaveChangesAsync();
        }

    }
}

