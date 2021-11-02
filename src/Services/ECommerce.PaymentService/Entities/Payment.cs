using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.PaymentService.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public int OrderId { get; set; }
        public string CardOwner { get; set; }
        public string CardNumber { get; set; }
        public string CardDate { get; set; }
        public string CardSecurityCode { get; set; }
        public bool IsSuccess { get; set; }
        public int PaymentType { get; set; }  //1-payment 2-refund
    }
}
