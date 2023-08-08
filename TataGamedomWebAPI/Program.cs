using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TataGamedomWebAPI.Application;
using TataGamedomWebAPI.Infrastructure;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Infrastructure.TaTaGamedom_Persistence;
using Microsoft.AspNetCore.Authentication.Cookies; // 引入 CookieAuthenticationDefaults 命名空間
using Microsoft.Extensions.FileProviders;
using TataGamedomWebAPI.Infrastructure.RealTimeServices;

namespace TataGamedomWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //DbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            .LogTo(Console.WriteLine, LogLevel.Information));

            //CORS
            string MyAllowOrigins = "AllowAny";
            builder.Services.AddCors(options => {
                options.AddPolicy(
                    name: MyAllowOrigins, policy => policy.WithOrigins("*").WithHeaders("*").WithMethods("*")
                );
            });

            //Repository, Tools, Third-Party Service
            builder.Services.AddApplicationServices();
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddInfrastructureServices(builder.Configuration);


            builder.Services.AddControllers();

			// Add authentication
			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
			{
				// 未登入時會自動導到這個網址
				options.LoginPath = new PathString("/api/Login/NoLogin");
                //options.ExpireTimeSpan = TimeSpan.FromDays(1);
                //options.Cookie.Domain = "http://localhost:3000";
                //options.Cookie.HttpOnly = true;
            });


            builder.Services.AddEndpointsApiExplorer();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

			app.UseRouting();

            app.UseCors();

            //Files
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Files")),
                RequestPath = "/Files"
            });

            // 設定身份驗證
            app.UseAuthentication();

			app.UseAuthorization();

            //SignalR
            app.MapHub<ChatHub>("/RealTimeServices/ChatHub");

            app.MapControllers();

            app.Run();
        }
    }
}