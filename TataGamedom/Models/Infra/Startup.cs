using Hangfire;
using Microsoft.Owin;
using Owin;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TataGamedom.Models.EFModels;

[assembly: OwinStartup(typeof(TataGamedom.Models.Infra.Startup))]

namespace TataGamedom.Models.Infra
{

	public class Startup
	{
		private AppDbContext db = new AppDbContext();
		public void Configuration(IAppBuilder app)
		{
			// 設定Hangfire使用SQL Server儲存後端
			GlobalConfiguration.Configuration.UseSqlServerStorage("AppDbContext");

			// 啟動Hangfire服務
			app.UseHangfireServer();

			// 啟用Hangfire儀表板，並設定路由結構和授權策略
			app.UseHangfireDashboard("/hangfire", new DashboardOptions
			{
				// 設定授權策略，可自行調整
				//Authorization = new[] { new HangfireAuthorizationFilter() }
			});

			//是我啦用法
			//RecurringJob.AddOrUpdate(() => 你寫的Method(), Cron.Daily(12, 0)); // 設定每天中午12點觸發

			//RecurringJob.AddOrUpdate(() => UpdateNewsScheduleDate(), Cron.Daily(12, 0)); // 設定每天中午12點觸發
			//RecurringJob.AddOrUpdate(() => UpdateNewsScheduleDate(), "*/3 * * * *"); // 設定每3分鐘觸發一次
			//RecurringJob.AddOrUpdate(() => UpdateNewsScheduleDate(), "*/30 * * * * *"); // 設定每30秒觸發一次
			//RecurringJob.AddOrUpdate(() => UpdateNewsScheduleDate(), "*/30 * * * * *"); // 設定每30秒觸發一次
			//RecurringJob.AddOrUpdate(() => UpdateCouponsScheduleDate(),Cron.Daily(16,0));//有時差問題，要每天定時的要-8小時
			RecurringJob.AddOrUpdate(() => UpdateCouponsScheduleDate(), "*/5 * * * * *");//有時差問題，要每天定時的要-8小時

		}

		public void UpdateCouponsScheduleDate()
		{
			DateTime dateTime = DateTime.Now;
			var couponList = db.Coupons.Where(c => c.StartTime <= dateTime && c.EndTime > dateTime && c.ModifiedTime==null).ToList();
			foreach ( var c in couponList )
			{
				c.ActiveFlag = true;
			}
			db.SaveChanges();
		}

		public void UpdateNewsScheduleDate()
		{
			DateTime currentTime = DateTime.Now;

			var newsList = db.News
				.Where(n => n.ScheduleDate < currentTime && n.DeleteDatetime == null)
				.ToList();

			foreach (var news in newsList)
			{
				news.ActiveFlag = true;
			}

			db.SaveChanges();
		}


	}

}
