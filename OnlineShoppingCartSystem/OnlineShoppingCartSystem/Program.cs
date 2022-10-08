using FluentAssertions.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.SqlServer.Management.SqlParser.Metadata;
using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Repository.Account;
using OnlineShoppingCartSystem.Repository.Admin;
using OnlineShoppingCartSystem.Repository.Customer;
using OnlineShoppingCartSystem.Services.Account;
using OnlineShoppingCartSystem.Services.Admin;
using OnlineShoppingCartSystem.Services.Customer;
using System.Text;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<OnlineShoppingCartDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectTeam"));
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<OnlineShoppingCartDBContext>()
    .AddDefaultTokenProviders();


builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
     .AddJwtBearer(option =>
     {
        // var key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]);
         option.SaveToken = true;
         option.RequireHttpsMetadata = false;
         option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
         {
             ValidateIssuer= true,
             ValidateAudience = true,
             ValidAudience = builder.Configuration["JWT:Audience"],
             ValidIssuer = builder.Configuration["JWT:Issuer"],
             IssuerSigningKey = new 
             SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))

         };

     });
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
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
//builder.Services.AddScoped<LoginRepository ,LoginRepository>();
//builder.Services.AddScoped<LoginService, LoginService>();


builder.Services.AddCors((setup) =>
{
    setup.AddPolicy("default", (options) =>
    {
        options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("default"); 
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

