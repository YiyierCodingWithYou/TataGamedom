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
			RecurringJob.AddOrUpdate(() => UpdateNewsScheduleDate(), "*/30 * * * * *"); // 設定每30秒觸發一次
		}

		public void UpdateNewsScheduleDate()
		{
			

		DateTime currentTime = DateTime.Now;

			// 從資料庫中取得需要更新的資料
			var newsList = db.News.Where(n => n.ScheduleDate < currentTime && n.ActiveFlag == false).ToList();

			foreach (var news in newsList)
			{
				// 更新ACTIVEFLAG欄位為1
				news.ActiveFlag = true;
			}

			// 儲存變更至資料庫
			db.SaveChanges();
		}
	}

}
