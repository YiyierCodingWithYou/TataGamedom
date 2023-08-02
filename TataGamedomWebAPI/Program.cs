using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TataGamedom_FrontEnd.Models.Infra.OrderInfra;
using TataGamedom_FrontEnd.Models.Interfaces;
using TataGamedomWebAPI.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.Cookies; // 引入 CookieAuthenticationDefaults 命名空間


namespace TataGamedomWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            .LogTo(Console.WriteLine, LogLevel.Information));

            string MyAllowOrigins = "AllowAny";
            builder.Services.AddCors(options => {
                options.AddPolicy(
                    name: MyAllowOrigins, policy => policy.WithOrigins("*").WithHeaders("*").WithMethods("*")
                );
            });

            builder.Services.AddControllers();

            builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

			// Add authentication
			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
			{
				// 未登入時會自動導到這個網址
				options.LoginPath = new PathString("/api/Login/NoLogin");
			});


			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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