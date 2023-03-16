using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToolsApp.Authentication
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public string Function { get; set; }
        public string UsersConfigKey { get; set; }
        public string RolesConfigKey { get; set; }
        protected virtual CustomPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as CustomPrincipal; }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                using (var _db = new ToolsApp.EntityFramework.QUANLYNHANSU.QUANLYNHANSUEntities1())
                {
                    var user_fun = _db.Users.FirstOrDefault(p => p.Username == CurrentUser.UserName);

                    #region User Not Page
                    if (user_fun == null)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Home/Index");
                    }
                    #endregion

                    var page = user_fun.User_Page.FirstOrDefault(p => p.Page.Controler + "/" + p.Page.Action == Function);

                    #region User Not Page
                    if (page == null)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Home/Index");
                    }
                    #endregion
                }
            }
            else
            {
                filterContext.HttpContext.Response.Redirect("~/Login/Index");
            }
        }
    }
}