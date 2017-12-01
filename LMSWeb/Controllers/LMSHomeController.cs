using LMSWeb.BLL;
using LMSWeb.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMSWeb.Controllers
{
    public class LMSHomeController : Controller
    {
        // GET: LMSHome
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LandingPage()
        {
            return View();
        }


        #region Edit User
        public ActionResult EditUser(int id)
        {
            ViewBag.userid = id;
            return View("CreateUser");
        }
        #endregion

        public ActionResult CreateUser()
        {
            ViewBag.userid = -1;
            return View();
        }



        [HttpPost]
        public JsonResult CreateUser(UserEntity userEntity)
        {
            userEntity.CreatedDate = DateTime.Now;
            UserBL userBL = new UserBL();
            userBL.Save(userEntity);
            string str = "success";
            return Json(str,JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetUsers()
        {
            UserBL userBL = new UserBL();
            List<UserEntity> users = userBL.GetAllUsers();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetUser(int id)
        {
            UserBL userBL = new UserBL();
            UserEntity ouserentity = userBL.Get(id);
            return Json(ouserentity, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchUser()
        {
            return View();
        }

        
        public JsonResult SearchUserData()
        {
            UserBL userBL = new UserBL();
            List<UserEntity> users = userBL.GetAllUsers();
            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}