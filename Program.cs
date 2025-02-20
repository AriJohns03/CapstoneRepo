using Capstone1.Data;
using Capstone1.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Capstone1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            // Get connection string from appsettings.json
            //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Register Entity Framework Core with SQL Server
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddTransient<IDataAccessLayer, EventListDAL>();

            builder.Services.AddSingleton<DatabaseService>();


            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Event}/{action=Index}"
            );

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.Run();
        }
    }
}