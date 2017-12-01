using LMSWeb.BusinessEntities;
using LMSWeb.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSWeb.BLL
{
    public class CustomerBL
    {
        public List<CustomerBusinessEntity> Search()
        {
            CustomerDAL ocustomerDAL = new CustomerDAL();
            return ocustomerDAL.List();
        }
        public bool Save(CustomerBusinessEntity customer)
        {
            CustomerDAL ocustomerDAL = new CustomerDAL();
            return ocustomerDAL.Save(customer);
        }
    }
}
