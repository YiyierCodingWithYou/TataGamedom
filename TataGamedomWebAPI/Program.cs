using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TataGamedomWebAPI.Application;
using TataGamedomWebAPI.Infrastructure;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Infrastructure.TaTaGamedom_Persistence;
using Microsoft.AspNetCore.Authentication.Cookies; // 引入 CookieAuthenticationDefaults 命名空間


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

            app.UseCors();

            app.UseHttpsRedirection();

			app.UseRouting();

			// 設定身份驗證
			app.UseAuthentication();

			app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}