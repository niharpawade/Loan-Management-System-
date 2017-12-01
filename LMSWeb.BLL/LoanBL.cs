using LMSWeb.BusinessEntities;
using LMSWeb.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSWeb.BLL
{
   public  class LoanBL
    {
     public bool Create(LoanBusinessEntity loanBusinessEntity)
        {
            LoanDAL loanDAL = new LoanDAL();
             loanBusinessEntity = GenerateLoanNo(loanBusinessEntity);
            return loanDAL.Save(loanBusinessEntity);            
        }

        public List<LoanBusinessEntity> GetLoans()
        {
            LoanDAL loanDAL = new LoanDAL();
            return loanDAL.GetLoans();
           
        }

        private LoanBusinessEntity GenerateLoanNo(LoanBusinessEntity loanBusinessEntity)
        {
            LoanDAL loanDAL = new LoanDAL();
            return loanDAL.GetLoanNo(loanBusinessEntity);
               
        }

        public LoanBusinessEntity GetCustName(LoanBusinessEntity loanBusinessEntity)
        {
            LoanDAL loanDAL = new LoanDAL();
            return loanDAL.GetCustName(loanBusinessEntity);
        }





    }
}
