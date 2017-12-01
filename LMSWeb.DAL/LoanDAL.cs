using LMSWeb.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSWeb.DAL
{
    public  class LoanDAL
    {
        public bool Save(LoanBusinessEntity loanBusinessEntity)
        {
            tbl_Loan Dbloan;
            if(loanBusinessEntity.Id == -1)
            {
                Dbloan= new tbl_Loan();
            }
            else
            {
                Dbloan = GetLoan(loanBusinessEntity.Id);
            }
            AssignValues(ref Dbloan, ref loanBusinessEntity);
            using (var dbContext = new LoanManagementSystemEntities())
            {
                dbContext.tbl_Loan.Add(Dbloan);
                dbContext.SaveChanges();
            }


                return true;

        }
        private void AssignValues(ref tbl_Loan Dbloan , ref LoanBusinessEntity loanBusinessEntity)
        {
            Dbloan.LoanNo = loanBusinessEntity.LoanNo;
            Dbloan.LoanTypeId = loanBusinessEntity.LoanTypeId;
            Dbloan.Nominee = loanBusinessEntity.Nominee;
            Dbloan.NoOfInstallaments = loanBusinessEntity.NoOfInstallments;
            Dbloan.interestrate = (Double)loanBusinessEntity.intrestrate;
            Dbloan.NomineeRelationShip = loanBusinessEntity.NomineeRelationShip;
            Dbloan.CustomerId = loanBusinessEntity.CustomerId;
          
            Dbloan.Amount = (decimal)loanBusinessEntity.Amount;
            



        }
        private tbl_Loan GetLoan(int ID)
        {
            var dbloan = new tbl_Loan();
            using (var dbContext = new LoanManagementSystemEntities())
            {
                dbloan = dbContext.tbl_Loan.Where(loan => loan.Id == ID).FirstOrDefault();
                return dbloan;
            }

                



        }
        public List<LoanBusinessEntity> GetLoans()
        {
            List<LoanBusinessEntity> loans = new List<LoanBusinessEntity>();
            try
            {
                using (var dbContext = new LoanManagementSystemEntities())
                {
                    var dbLoanObj = dbContext.tbl_Loan.ToList();

                    foreach (var loan in dbLoanObj)
                    {
                        LoanBusinessEntity loanBusinessEntity = new LoanBusinessEntity();
                        loanBusinessEntity.Id = loan.Id;
                        loanBusinessEntity.LoanNo = loan.LoanNo;
                        loanBusinessEntity.LoanStatus = loan.LoanStatus;
                        loanBusinessEntity.LoanTypeId =loan.LoanTypeId;
                       
                        loanBusinessEntity.Amount = (double)loan.Amount;
                        
                        loanBusinessEntity.CustomerId = (int)loan.CustomerId;
                        loans.Add(loanBusinessEntity);
                    }

                }
            }
            catch
            {
                throw;
            }
            finally
            {

            }
            return loans;


               
        }
        public LoanBusinessEntity GetLoanNo(LoanBusinessEntity loanBusinessEntity)
        {
            int counts;
            string last = "";
            tbl_Loan lastloan;
            using (var count = new LoanManagementSystemEntities())
            {
                counts =  count.tbl_Loan.Count();
            }
            if(counts == 0)
            {
                last = "L000001";
            }
            else
            {
                using (var dbContext = new LoanManagementSystemEntities())
                {                   
                         var lnk =  dbContext.tbl_Loan.OrderByDescending(x => x.LoanNo).Take(1);
                        lastloan =  lnk.First();                  
                        last = lastloan.LoanNo;

                }
                //int number = Convert.ToInt32(last.Substring(1)) + 1;
                int number = int.Parse(last.Substring(1));
                number += 1;

                string symbol = last.Substring(0, 1);
                last = symbol + number.ToString("D6"); /////great formating solution 
            }
            
            loanBusinessEntity.LoanNo = last;
            return loanBusinessEntity;
                        
        }
        public LoanBusinessEntity GetCustName(LoanBusinessEntity loanBusinessEntity)
        {
            
            try
            {
                using (var dbContext = new LoanManagementSystemEntities())
                {
                    tbl_Customer cust = dbContext.tbl_Customer.Where(c => c.Id == loanBusinessEntity.CustomerId).FirstOrDefault();
                    if (cust != null)
                    {
                        loanBusinessEntity.CustomerName = cust.Name;

                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return loanBusinessEntity;
        }
    }
}
