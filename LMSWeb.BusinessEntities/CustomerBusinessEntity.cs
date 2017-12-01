using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSWeb.BusinessEntities
{
    public class CustomerBusinessEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Adhaarno { get; set; }
        public string MobileNo { get; set; }

        public string PanCard { get; set; }

        public DateTime DOB { get; set; }

        public string Gender { get; set; }
        public double AnnualIncome { get; set; }

        public  AddressEntity PresentAddress { get; set; }
    }
}
