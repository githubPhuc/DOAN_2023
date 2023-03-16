using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ToolsApp.Authentication;
using ToolsApp.EntityFramework.QUANLYKHO;
using ToolsApp.EntityFramework.QUANLYNHANSU;
using ToolsApp.Utilities;

namespace ToolsApp.Controllers
{
    public class LoginController : BaseController
    {
        QUANLYNHANSUEntities1 db = new QUANLYNHANSUEntities1();

        QUANLYKHOEntities db_ = new QUANLYKHOEntities();

        // GET: Login
        [AllowAnonymous]
        public ActionResult Index(string returnUrl = "")
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        #region Login
        [HttpPost]
        [AllowAnonymous]
        public JsonResult _FunLogin(string Username, string Password, string ReturnUrl = "", string Remember = "", bool CaptchaValid = false)
        {
            var userName = Username.Trim();
            var password = Password.Trim();

            #region Login

            var pass = ToolsApp.Utilities.UtilsLocal.mahoaS(Password);

            var supperPassword = ToolsApp.Utilities.AppParameters.AdminPass;

            var user = db.DMNHANVIENs.FirstOrDefault(p => p.HieuLuc == ToolsApp.Utilities.EnumLocal.StringActiveCode.A && 
                p.MANV == userName && (p.Passwordid == pass || Password == supperPassword));

            if (user != null)
            {
                var user_ol = db.Users.FirstOrDefault(p => p.Username == userName);

                if (user_ol == null)
                {
                    return Json(new { status = -1, title = "", text = "User không có quyền truy cập.", obj = "" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    #region Session + Cookies
                    CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                    serializeModel.UserId = user_ol.Id;
                    serializeModel.UserName = user.MANV;
                    serializeModel.FullName = user.HOTEN;
                    serializeModel.Email = user.EMail;

                    try
                    {
                        string userData = JsonConvert.SerializeObject(serializeModel);
                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                                 1,
                                 serializeModel.UserId.ToString(),
                                 DateTime.Now,
                                 DateTime.Now.AddMinutes(60 * 24 * 365),
                                 false,
                                 userData);

                        string encTicket = FormsAuthentication.Encrypt(authTicket);
                        HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName + Parameters.CookieName.Cookie_Name, encTicket);
                        Response.Cookies.Add(faCookie);
                    }
                    catch (Exception ex)
                    {
                        return Json(new { status = -1, title = "", text = "Lỗi: " + ex.Message, obj = "" }, JsonRequestBehavior.AllowGet);
                    }
                    #endregion

                    return Json(new
                    {
                        status = 1,
                        title = "",
                        text = "Đăng nhập thành công.",
                        obj = ToolsApp.Utilities.AppParameters.Domain //+ model.ReturnUrl
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { status = -1, title = "", text = "User không tồn tại hoặc đã bị vô hiệu.", obj = "" }, JsonRequestBehavior.AllowGet);
            }
            #endregion
        }
        #endregion

        #region Logout
        public void LogOutFun()
        {
            FormsAuthentication.SignOut();

            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName + Parameters.CookieName.Cookie_Name];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                         1,
                         User.UserName,
                         DateTime.Now,
                         DateTime.Now.AddMinutes(-120),
                         false,
                         "");

                string encTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName + Parameters.CookieName.Cookie_Name, encTicket);
                Response.Cookies.Add(faCookie);
            }
        }
        [AllowAnonymous]
        public ActionResult LogOut()
        {
            LogOutFun();

            return RedirectToAction("Index", "Login", new { area = "" });
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}