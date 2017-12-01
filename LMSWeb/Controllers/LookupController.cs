using LMSWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMSWeb.BLL;
using LMSWeb.BusinessEntities;

namespace LMSWeb.Controllers
{
    public class LookupController : Controller
    {
        [HttpGet]
        public JsonResult GetQuestions()
        {
            LookupBL lookupBL = new LookupBL();
            IList<QuestionEntity> questions = lookupBL.GetQuestions();
            return Json(questions, JsonRequestBehavior.AllowGet);
            
        }

        // GET: Lookup
        public JsonResult GetRoles()
        {
            // Admin
            RoleModel adminModel = new RoleModel() { Id="A",Name="Admin" };
            // Customer
            RoleModel customerModel = new RoleModel() { Id = "C", Name = "Customer" };
            // User
            RoleModel userModel = new RoleModel() { Id = "U", Name = "User" };

            List<RoleModel> roles = new List<RoleModel>();
            roles.Add(adminModel);
            roles.Add(customerModel);
            roles.Add(userModel);

            return Json(roles,JsonRequestBehavior.AllowGet);
        }

        #region Loan Binding
        [HttpGet]
        public JsonResult GetLoanTypes()
        {
            LookupBL lookupBL = new LookupBL();
            IList<LoanTypeEntity> loantypes = lookupBL.GetLoanTypes();
            return Json(loantypes, JsonRequestBehavior.AllowGet);

        }
       [HttpGet]
       public JsonResult GetTodayDate()
        {
            DateTime todaydate = DateTime.Now;
            return Json(todaydate, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetCustomerById(CustomerBusinessEntity customerBusinessEntity)
        {
            LookupBL lookupBL = new LookupBL();
            var cust = lookupBL.GetCustomerById(customerBusinessEntity.ID);
            return Json(cust, JsonRequestBehavior.AllowGet);
        }
       


        #endregion
    }
}