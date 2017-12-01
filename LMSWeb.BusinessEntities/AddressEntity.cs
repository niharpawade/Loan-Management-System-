using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSWeb.BusinessEntities
{
   public class AddressEntity
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string District { get; set; }

        public string State { get; set; }

        public string Pincode { get; set; }
    }
}
