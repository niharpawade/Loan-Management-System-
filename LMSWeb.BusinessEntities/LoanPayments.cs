using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSWeb.BusinessEntities
{
   public  class LoanPayments
    {
        int Id { get; set; }
        int LoanId { get; set; }
        string PaymentMethod { get; set; }
        decimal Amount { get; set; }
        DateTime PaidDate { get; set; }
        char PaidStatus { get; set; }

    }
}
