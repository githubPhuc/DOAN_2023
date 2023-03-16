using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolsApp.App_Start;
using ToolsApp.Authentication;
using ToolsApp.EntityFramework.QUANLYKHO;
using ToolsApp.Models;
using ToolsApp.Utilities;

namespace ToolsApp.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        QUANLYKHOEntities db_ = new QUANLYKHOEntities();
        // GET: Home
        public ActionResult Index(string Id = "")
        {         

            return View();
        }
    }
}