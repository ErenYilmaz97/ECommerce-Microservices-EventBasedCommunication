using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EventPrrocessor.EventInfoObjects
{
    public class CancelOrderEventInfo : IEventInfoObject
    {
        public int OrderId { get; set; }
    }
}
