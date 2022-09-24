using Microsoft.EntityFrameworkCore;
using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Repository.Account;
using OnlineShoppingCartSystem.Repository.AdminCategory;
using OnlineShoppingCartSystem.Repository.AdminProduct;
using OnlineShoppingCartSystem.Repository.Customer;
using OnlineShoppingCartSystem.Services.Account;
using OnlineShoppingCartSystem.Services.Admin;
using OnlineShoppingCartSystem.Services.Customer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<OnlineShoppingCartDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectTeam"));
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




//Adding Services to the contatiner

builder.Services.AddScoped<IAccount<Users>, RegisterRepository>();
builder.Services.AddScoped<RegisterService, RegisterService>();
builder.Services.AddScoped<ICategory<Category>, CategoryRepository>();
builder.Services.AddScoped<CategoryService, CategoryService>();
builder.Services.AddScoped<IProduct<Product>, ProductRepository>();
builder.Services.AddScoped<ProductService, ProductService>();
builder.Services.AddScoped<ICart<Product, int>, CartRepository>();
builder.Services.AddScoped<CartService, CartService >();
builder.Services.AddScoped<ICheckout<Users>, CheckoutRepository>();
builder.Services.AddScoped<CheckoutService, CheckoutService>();
builder.Services.AddScoped<IOrder<Orders>, OrderRepository>();
builder.Services.AddScoped<OrderService, OrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
