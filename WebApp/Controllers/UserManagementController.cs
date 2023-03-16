using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolsApp.App_Start;
using ToolsApp.Authentication;
    using ToolsApp.EntityFramework.QUANLYNHANSU;

using ToolsApp.Models;
using ToolsApp.Utilities;

namespace ToolsApp.Areas.Admin.Controllers
{
    [Authorize]
    [CustomAuthorize(Function = "UserManagement/Index")]
    public class UserManagementController : BaseController
    {
        QUANLYNHANSUEntities1 db_ = new QUANLYNHANSUEntities1();

     
        // GET: UserManagement
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _GetList()
        {
            var List = db_.Users.Where(p => p.isDelete == null || p.isDelete == false).OrderBy(p => p.SalesRepCode).ToList();

            var lst = List.Select(p => p.Username).ToList();

            ViewBag.List = List;
            return PartialView( new UserViewModel());
        }
        public ActionResult _Insert(int Id)
        {
            var users = db_.Users.Select(p => p.Username).ToList();

            var Active = EnumLocal.StringActiveCode.A;

            #region Load user from DKSH db
            var allUsers = db_.DMNHANVIENs.Where(p => p.HieuLuc == Active &&
                !users.Contains(p.MANV)
            ).ToList();
            #endregion

            ViewBag.allUsers = allUsers;

            #region Load role
            var roles = db_.Roles.ToList();
            ViewBag.roles = roles;
            #endregion

            #region Load page
            var pages = db_.Pages.ToList();
            ViewBag.pages = pages;
            #endregion            

            return PartialView(new UserViewModel { Id = 0 });
        }
        public ActionResult _Edit(int Id)
        {
            var model = db_.Users.FirstOrDefault(p => p.Id == Id);

            #region Load role
            var roles = db_.Roles.ToList();
            ViewBag.roles = roles;
            #endregion

            #region Load page
            var pages = db_.Pages.ToList();
            ViewBag.pages = pages;
            #endregion                                    

            return PartialView(model);
        }
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult _InsertFun(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    #region item
                    var user = db_.DMNHANVIENs.FirstOrDefault(p => p.MANV == model.Username);
                    if (user != null)
                    {
                        var model_copy = Mapper.MapFrom(model);
                        model_copy.Fullname = user.HOTEN;
                        model_copy.Email = user.EMail;
                        model_copy.DatetimeCreate = DateTime.Now;
                        model_copy.UserCreate = User.UserName;
                        model_copy.UserFullnameCreate = User.FullName;
                        model_copy.DatetimeUpdate = DateTime.Now;
                        model_copy.UserUpdate = User.UserName;
                        model_copy.UserFullnameUpdate = User.FullName;

                        #region Add page
                        if (model.Pages != null && model.Pages.Length > 0)
                        {
                            model_copy.User_Page = new List<User_Page>();

                            var Pages = model.Pages.Split(',');

                            foreach (var item in Pages)
                            {
                                var data = new User_Page
                                {
                                    PageId = int.Parse(item),
                                    DatetimeCreate = DateTime.Now,
                                    UserCreate = User.UserName,
                                    UserFullnameCreate = User.FullName,
                                    DatetimeUpdate = DateTime.Now,
                                    UserUpdate = User.UserName,
                                    UserFullnameUpdate = User.FullName
                                };

                                model_copy.User_Page.Add(data);
                            }
                        }
                        #endregion

                        #region Add role
                        if (model.Roles != null && model.Roles.Length > 0)
                        {
                            model_copy.User_Role = new List<User_Role>();

                            var Roles = model.Roles.Split(',');

                            foreach (var item in Roles)
                            {
                                var data = new User_Role
                                {
                                    RoleId = int.Parse(item),
                                    DatetimeCreate = DateTime.Now,
                                    UserCreate = User.UserName,
                                    UserFullnameCreate = User.FullName,
                                    DatetimeUpdate = DateTime.Now,
                                    UserUpdate = User.UserName,
                                    UserFullnameUpdate = User.FullName
                                };

                                model_copy.User_Role.Add(data);
                            }
                        }
                        #endregion                        

                        db_.Users.Add(model_copy);
                        db_.SaveChanges();

                        return Json(new { status = 1, title = "", text = "Created.", obj = "" }, JsonRequestBehavior.AllowGet);
                    }
                    #endregion

                    return Json(new { status = -1, title = "", text = "User not exsist!", obj = "" }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(new { status = -1, title = "", text = ex.Message, obj = "" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));

                return Json(new { status = -1, title = "", text = "Error: " + message, obj = "" }, JsonRequestBehavior.AllowGet);
            }
        }
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult _EditFun(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var item = db_.Users.FirstOrDefault(p => p.Id == model.Id);
                    item.DatetimeUpdate = DateTime.Now;
                    item.UserUpdate = User.UserName;
                    item.UserFullnameUpdate = User.FullName;

                    #region Page
                    #region Del
                    if (item.User_Page != null && item.User_Page.Count > 0)
                    {
                        var list = item.User_Page.ToList();
                        foreach (var data in list)
                        {
                            db_.User_Page.Remove(data);
                        }
                    }
                    #endregion

                    #region Add
                    if (model.Pages != null && model.Pages.Length > 0)
                    {
                        var Pages = model.Pages.Split(',');

                        foreach (var item_ in Pages)
                        {
                            var data = new User_Page
                            {
                                PageId = int.Parse(item_),
                                DatetimeCreate = DateTime.Now,
                                UserCreate = User.UserName,
                                UserFullnameCreate = User.FullName,
                                DatetimeUpdate = DateTime.Now,
                                UserUpdate = User.UserName,
                                UserFullnameUpdate = User.FullName
                            };

                            item.User_Page.Add(data);
                        }
                    }
                    #endregion
                    #endregion

                    #region Role
                    #region Del
                    if (item.User_Role != null && item.User_Role.Count > 0)
                    {
                        var list = item.User_Role.ToList();
                        foreach (var data in list)
                        {
                            db_.User_Role.Remove(data);
                        }
                    }
                    #endregion

                    #region Add
                    if (model.Roles != null && model.Roles.Length > 0)
                    {
                        var Roles = model.Roles.Split(',');

                        foreach (var item_ in Roles)
                        {
                            var data = new User_Role
                            {
                                RoleId = int.Parse(item_),
                                DatetimeCreate = DateTime.Now,
                                UserCreate = User.UserName,
                                UserFullnameCreate = User.FullName,
                                DatetimeUpdate = DateTime.Now,
                                UserUpdate = User.UserName,
                                UserFullnameUpdate = User.FullName
                            };

                            item.User_Role.Add(data);
                        }
                    }
                    #endregion
                    #endregion                                                            

                    db_.Entry(item).State = EntityState.Modified;
                    db_.SaveChanges();
                    return Json(new { status = 1, title = "", text = "Updated.", obj = "" }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(new { status = -1, title = "", text = ex.Message, obj = "" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));

                return Json(new { status = -1, title = "", text = "Error: " + message, obj = "" }, JsonRequestBehavior.AllowGet);
            }
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult _DeleteFun(int Id)
        {
            try
            {
                var item = db_.Users.FirstOrDefault(p => p.Id == Id);

                item.isDelete = true;
                item.DatetimeUpdate = DateTime.Now;
                item.UserUpdate = User.UserName;
                item.UserFullnameUpdate = User.FullName;
                db_.Entry(item).State = EntityState.Modified;
                db_.SaveChanges();
                return Json(new { status = 1, title = "", text = "Deleted.", obj = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = -1, title = "", text = ex.Message, obj = "" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}