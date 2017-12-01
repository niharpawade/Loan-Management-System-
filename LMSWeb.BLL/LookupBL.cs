using LMSWeb.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMSWeb.DAL;

namespace LMSWeb.BLL
{
    public class LookupBL
    {
        public List<QuestionEntity> GetQuestions()
        {
            LookupDAL lookupDAL = new LookupDAL();
            return lookupDAL.GetQuestions();
        }

        #region Loan 



        public List<LoanTypeEntity> GetLoanTypes()
        {
            LookupDAL lookupDAL = new LookupDAL();
            return lookupDAL.GetLoanTypes();
        }

        public CustomerBusinessEntity GetCustomerById(int ID)
        {
            LookupDAL lookupDAL = new LookupDAL();
            return lookupDAL.GetCustomerById(ID);


        }
#endregion
    }
}
