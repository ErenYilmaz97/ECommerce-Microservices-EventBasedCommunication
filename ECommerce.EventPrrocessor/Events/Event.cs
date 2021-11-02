using ECommerce.EventPrrocessor.EventInfoObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EventPrrocessor.Events
{
    public abstract class Event<TEventInfo> : IEvent<TEventInfo> where TEventInfo : IEventInfoObject
    {
        public TEventInfo EventInfo { get; set; }
    }
}
