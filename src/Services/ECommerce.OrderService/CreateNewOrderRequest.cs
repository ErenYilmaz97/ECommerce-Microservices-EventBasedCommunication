using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.OrderService
{
    public class CreateNewOrderRequest
    {
        //Kart Bilgileri
        public string CardOwnerName { get; set; }
        public string CardNumber { get; set; }
        public string CardDate { get; set; }
        public string CardSecurityCode { get; set; }
    }
}
