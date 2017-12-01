using LMSWeb.BLL;
using LMSWeb.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMSWeb.Controllers
{
    public class LoanController : Controller
    {
        // GET: Loan
        public ActionResult Index()
        {
            return View();


        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(LoanBusinessEntity loanBusinessEntity)
        {
            loanBusinessEntity.Id = -1;
            string str = "Success";
            LoanBL loanBL = new LoanBL();
            bool status = loanBL.Create(loanBusinessEntity);
            return Json(str, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SearchLoan()
        {
            LoanBL loanBL = new LoanBL();
            IList<LoanBusinessEntity> loans = loanBL.GetLoans();
            List<LoanBusinessEntity> loansnew = new List<LoanBusinessEntity>(); 
            foreach(LoanBusinessEntity loan in loans)
            {

                LoanBusinessEntity ob = GetCustName(loan);
                loansnew.Add(ob);
            }
            return Json(loansnew, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditLoan(int id)
        {
            ViewBag.LoanId = id;
            return View("Create");
        }
        public LoanBusinessEntity GetCustName(LoanBusinessEntity loanBusinessEntity)
        {

            LoanBL loanBL = new LoanBL();

            return loanBL.GetCustName(loanBusinessEntity);
        }
    }
}