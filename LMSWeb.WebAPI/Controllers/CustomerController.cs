using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LMSWeb.BusinessEntities;
using LMSWeb.BLL;
namespace LMSWeb.WebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        [CustomAuthorize]
        [HttpPost]
        public bool Save(CustomerBusinessEntity customerEntity)
        {
            bool status = false;
            try
            {
                CustomerBL customerBL = new CustomerBL();
                status = customerBL.Save(customerEntity);
            }
            catch(Exception exp)
            {

            }
            finally
            {

            }

            return status;
        }
    }
}
