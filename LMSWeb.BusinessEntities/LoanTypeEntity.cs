using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSWeb.BusinessEntities
{
   public  class LoanTypeEntity
    {
        public int Id { get; set; }
        public string LoanName { get; set; }
        public double IntrestRate { get; set; }
        public int MaxInstallments { get; set; }
        public decimal MaxAmount { get; set; }




    }
}
