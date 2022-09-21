using Microsoft.EntityFrameworkCore;
using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Repository.Account;
using OnlineShoppingCartSystem.Repository.AdminCategory;
using OnlineShoppingCartSystem.Repository.AdminProduct;
using OnlineShoppingCartSystem.Repository.Customer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<OnlineShoppingCartDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectTeam"));
});

//Adding Services to the contatiner

builder.Services.AddScoped<IAccount<Users,int>, RegisterRepository>();
builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddScoped<ICart<Product,int>, CartRepository>();
builder.Services.AddScoped<ICheckout<Users>, CheckoutRepository>();
builder.Services.AddScoped<IOrder<Orders,int>, OrderRepository>();

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
