using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TataGamedom.Controllers
{
    public class PostsCommentsController : Controller
    {
        // GET: PostsComments
        public ActionResult Index()
        {
            return View();
        }
    }
}