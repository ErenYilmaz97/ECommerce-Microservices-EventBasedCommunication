using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EventPrrocessor.EventInfoObjects
{
    public class PaymentReceivedEventInfo : IEventInfoObject
    {
        //Payment received eventi ile birlikte taşınacak olan bilgiler

        //Order completed işlemi için
        public int OrderId { get; set; }

        //Stock işlemi için
        public Dictionary<int, int> ProductIdsAndQuantities { get; set; }
    }
}
