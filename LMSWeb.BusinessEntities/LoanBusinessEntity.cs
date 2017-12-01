using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSWeb.BusinessEntities
{
    public class LoanBusinessEntity
    {
       public  int Id { get; set; }
       public string LoanNo { get; set; }
        public int CustomerId { get; set; }
        public string LoanStatus { get; set; }
        public int? LoanTypeId { get; set; }
        public double Amount { get; set; }
        public DateTime AppliedDate { get; set; }
        public DateTime ActivationDate { get; set; }
        public decimal intrestrate { get; set; }
        public int NoOfInstallments { get; set; }
        public int PaidInstallments { get; set; }
        public string Nominee { get; set; }
        public int NomineeAddressId { get; set; }
        public string NomineeRelationShip { get; set; }
        public string CustomerName { get; set; }







    }
}
