using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Features.Products.Commands.CreateProduct;
using Shop.Application.Interfaces;
using Shop.Infrastructure.Data;
using Shop.Infrastructure.Repositories;
using Shop.Application.Features.User.Helper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ShopQueryDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("QueryDBConnection")));

//Add service to the container
//#region redisconfig
builder.Services.AddStackExchangeRedisCache(option =>
{ 
    option.Configuration = builder.Configuration.GetValue<string>("CashSetting:RedisUrl");
});
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShopDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOtpRedisRepository,OtpRedisRepository>();
builder.Services.AddScoped<IUserQueryRepository, UserQueryRepository>();
builder.Services.AddScoped<IUserCommandRepository, UserCommandRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddMediatR(
    typeof(CreateProductHandler).Assembly);

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", policy =>
    {
        policy
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

Auth.Extensions.AddJwt(builder.Services, builder.Configuration);



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("ReactPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();