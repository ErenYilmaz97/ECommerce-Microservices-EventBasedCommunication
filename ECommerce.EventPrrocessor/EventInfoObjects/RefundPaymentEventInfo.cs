using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EventPrrocessor.EventInfoObjects
{
    public class RefundPaymentEventInfo : IEventInfoObject
    {
        public int OrderId { get; set; }
    }
}
