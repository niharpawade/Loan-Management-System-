using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMSWeb.BusinessEntities;

namespace LMSWeb.DAL
{
    public class CustomerDAL
    {

        public List<CustomerBusinessEntity> List()
        {
            List<CustomerBusinessEntity> customers = new List<CustomerBusinessEntity>();
            try
            {
                using (var dbContext = new LoanManagementSystemEntities())
                {
                    var dbCustomers = dbContext.tbl_Customer.ToList();
                  customers=  dbCustomers.Select(db => new CustomerBusinessEntity()
                    {
                        ID=db.Id,
                        Name=db.Name,
                        AnnualIncome=(double)db.AnnualIncome,
                        PanCard=db.PANCard
                    }).ToList();
                }
            }
            catch
            {

            }
            finally
            {

            }

            return customers;
        }

        public bool Save(CustomerBusinessEntity customer)
        {
            tbl_Customer dbCustomer;
            if (customer.ID == -1)
            {
                dbCustomer = new tbl_Customer();
            }
            else
            {
                dbCustomer = Get(customer.ID);
            }
            AssignValueToDBCustomer(ref dbCustomer, ref customer);
            using (var dbContext = new LoanManagementSystemEntities())
            {
                dbContext.tbl_Customer.Add(dbCustomer);
                dbContext.SaveChanges();
            }

                return true;
        }

        private void AssignValueToDBCustomer(ref tbl_Customer dbCustomer, ref CustomerBusinessEntity custmorEntity)
        {
            dbCustomer.Name = custmorEntity.Name;
            dbCustomer.AdhaarNo = custmorEntity.Adhaarno;
            dbCustomer.MobileNo = custmorEntity.MobileNo;
            dbCustomer.PANCard = custmorEntity.PanCard;
            dbCustomer.DOB = custmorEntity.DOB;
            dbCustomer.Gender = custmorEntity.Gender;
            dbCustomer.AnnualIncome = (decimal)custmorEntity.AnnualIncome;


            // Present Address
            tbl_Address presentAddress = new tbl_Address();
            presentAddress.Address1 = custmorEntity.PresentAddress.Address1;
            presentAddress.Address2 = custmorEntity.PresentAddress.Address2;
            presentAddress.City = custmorEntity.PresentAddress.City;
            presentAddress.State = custmorEntity.PresentAddress.State;
            presentAddress.District = custmorEntity.PresentAddress.District;
            presentAddress.PINCode = custmorEntity.PresentAddress.Pincode;

            dbCustomer.PresentAddress = presentAddress;

        }

        private tbl_Customer Get(int id)
        {
            tbl_Customer dbcust;
            using (var dbContext = new LoanManagementSystemEntities())
            {
                dbcust = dbContext.
                          tbl_Customer.
                          Where(cust => cust.Id == id).FirstOrDefault();
            }
            return dbcust;
        }




    }
}
