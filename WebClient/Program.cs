using Blazored.Toast;
using Blazored.Toast.Services;
using WebClient.Components;
using WebClient.Data;
using WebClient.Services;

namespace WebClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpClient<IOrderApiService, OrderApiService>(client =>
            {
                var apiBase = builder.Configuration["ApiBaseUrl"];
                client.BaseAddress = new Uri(!string.IsNullOrWhiteSpace(apiBase) ? apiBase : "https://localhost:8200/");
            });
            builder.Services.AddHttpClient<IProductApiService, ProductApiService>(client =>
            {
                var apiBase = builder.Configuration["ApiBaseUrl"];
                client.BaseAddress = new Uri(!string.IsNullOrWhiteSpace(apiBase) ? apiBase : "https://localhost:8000/");
            });
            builder.Services.AddHttpClient<ICustomerApiService, CustomerApiService>(client =>
            {
                var apiBase = builder.Configuration["ApiBaseUrl"];
                client.BaseAddress = new Uri(!string.IsNullOrWhiteSpace(apiBase) ? apiBase : "https://localhost:8100/");
            });

            builder.Services.AddTransient<DataGeneratorCustomer>();
            builder.Services.AddTransient<DataGeneratorProduct>();

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}