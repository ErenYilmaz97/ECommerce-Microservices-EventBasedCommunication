using ECommerce.EventPrrocessor.EventInfoObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EventPrrocessor.Events.StockServiceEvents
{
    public class StockStatusUpdatedEvent : Event<StockStatusUpdatedEventInfo>
    {
    }
}
