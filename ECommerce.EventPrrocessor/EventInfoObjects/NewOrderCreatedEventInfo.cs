using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EventPrrocessor.EventInfoObjects
{
    public class NewOrderCreatedEventInfo : IEventInfoObject
    {
        //Order completed işlemi için
        public int OrderId { get; set; }

        //New order created eventi ile birlikte taşınacak olan bilgiler
        public string CardOwnerName { get; set; }
        public string CardNumber { get; set; }
        public string CardDate { get; set; }
        public string CardSecurityCode { get; set; }

        //Stock işlemi için
        public Dictionary<int,int> ProductIdsAndQuantities { get; set; }
    }
}
