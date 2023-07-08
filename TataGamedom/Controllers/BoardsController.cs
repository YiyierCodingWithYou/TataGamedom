using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TataGamedom.Controllers
{
	public class BoardsController : Controller
	{
		// GET: Boards
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Boards()
		{
			return View();
		}
		public ActionResult PostsComments()
		{
			return View();
		}
		public ActionResult Moderators()
		{
			return View();
		}
		public ActionResult Applications()
		{
			return View();
		}
		public ActionResult Reports()
		{
			return View();
		}
		public ActionResult Buckets()
		{
			return View();
		}
	}
}