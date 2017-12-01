using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMSWeb.BusinessEntities;
using LMSWeb.BLL;

namespace LMSWeb.Controllers
{
    public class CustomerController : Controller
    {
        #region Customer Create
        // GET: Customer
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(CustomerBusinessEntity customerEntity)
        {

            string str = "success";
            DateTime dt = customerEntity.DOB;

            CustomerBL customerBL = new CustomerBL();
            customerBL.Save(customerEntity);
            //WebAPIHelper oWebAPIHelper = new WebAPIHelper();
            //bool result = oWebAPIHelper.SaveCustomer(customerEntity);

            return Json(str, JsonRequestBehavior.AllowGet);
        }
        #endregion
        public ActionResult Search()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult SearchCustomers()
        {
            CustomerBL customerBL = new CustomerBL();

            List<CustomerBusinessEntity> customers = customerBL.Search();
            return Json(customers, JsonRequestBehavior.AllowGet);
        }
    }
}