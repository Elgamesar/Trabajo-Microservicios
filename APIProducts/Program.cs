using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MSProductApplication.Interfaces.IRepositories;
using MSProductApplication.Interfaces.IServices;
using MSProductApplication.Services;
using MSProductApplication.Validators;
using MSProductDomain.Entities;
using MSProductInfra.Data;
using MSProductInfra.Repositories;

namespace APIProducts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ProductDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IValidator<Product>, ProductValidator>();
            builder.Services.AddScoped<ProductValidator>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}