using Microsoft.AspNetCore.Http.Features;
using WebApplication3.Interfaces;
using WebApplication3.Models.FilterModels;
using WebApplication3.Services;

internal class Program
{
    static void ConfigureServices(WebApplicationBuilder builder)
    {
        var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

        IServiceCollection services = builder.Services;

        services.AddControllersWithViews();
        services.AddScoped<FilterService>();
        services.AddMemoryCache();

        services.Configure<FormOptions>(options =>
        {
            options.ValueCountLimit = int.MaxValue;
        });


        services.AddHttpClient("localhost", client =>
        {
            client.BaseAddress = new Uri("https://localhost:44336/api");

        });

    }
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder);
        // Add services to the container.
        //builder.Services.AddControllersWithViews();
        //builder.Services.AddScoped<FilterService>();

        //builder.Services.Configure<FormOptions>(options =>
        //{
        //    options.ValueCountLimit = int.MaxValue;
        //});


        //builder.Services.AddHttpClient("localhost", client =>
        //{
        //    client.BaseAddress = new Uri("https://localhost:44336/api");

        //});

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}