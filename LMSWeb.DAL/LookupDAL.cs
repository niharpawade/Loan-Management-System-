using LMSWeb.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
namespace LMSWeb.DAL
{
    public class LookupDAL
    {
        public List<QuestionEntity> GetQuestions()
        {
            List<QuestionEntity> questions = new List<QuestionEntity>();
            using (var dbLMSEntities = new LoanManagementSystemEntities())
            {
                using (var sw = new StreamWriter(@"C:\Users\NIHAR-PC\OneDrive\Attachments\log.txt"))
                {
                    dbLMSEntities.Database.Log = sw.WriteLine;
                    var dbQuestions = dbLMSEntities.Questions.ToList();
                    foreach (var dbQuestion in dbQuestions)
                    {
                        QuestionEntity questionEntity = new QuestionEntity();
                        questionEntity.Id = dbQuestion.id;
                        questionEntity.QuestionName = dbQuestion.QuestionName;
                        questions.Add(questionEntity);
                    }
                }
            }
            return questions;
        }
        #region Loan 
        public List<LoanTypeEntity> GetLoanTypes()
        {
            List<LoanTypeEntity> loantypes = new List<LoanTypeEntity>();
            using (var dbLMSEntities = new LoanManagementSystemEntities())
            {
                var dbLoanTypes = dbLMSEntities.tbl_LoanTypes.ToList();
                foreach(var dbLoanType in dbLoanTypes)
                {
                    LoanTypeEntity loanTypeEntity = new LoanTypeEntity();
                    loanTypeEntity.Id = dbLoanType.Id;
                    loanTypeEntity.LoanName = dbLoanType.LoanName;
                    loanTypeEntity.IntrestRate = (double)dbLoanType.IntrestRate;
                    loanTypeEntity.MaxInstallments = (int)dbLoanType.MaxInstallments;
                    loanTypeEntity.MaxAmount = (decimal)dbLoanType.MaxAmount;
                    loantypes.Add(loanTypeEntity);
                }
            }
            return loantypes;
        }
        #endregion

        public CustomerBusinessEntity GetCustomerById(int ID)
        {
            CustomerBusinessEntity customer = new CustomerBusinessEntity();
            try
            {
                using (var dbContext = new LoanManagementSystemEntities())
                {
                   tbl_Customer cust = dbContext.tbl_Customer.Where(c => c.Id == ID).FirstOrDefault();
                    if(cust != null)
                    {
                        customer.ID = cust.Id;
                        customer.Name = cust.Name;
                        customer.PanCard = cust.PANCard;
                        

                    }
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {

            }
            return customer;
           

        }
    }
}
