using ECommerce.EventPrrocessor.Constants;
using ECommerce.EventPrrocessor.EventOutputMethods;
using ECommerce.EventPrrocessor.Events.PaymentServiceEvents;
using ECommerce.EventPrrocessor.Events.StockServiceEvents;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.NotificationService.Consumers
{
    public class StockStatusUpdatedEventConsumer : IConsumer<StockStatusUpdatedEvent>
    {
        public async Task Consume(ConsumeContext<StockStatusUpdatedEvent> context)
        {
                     
           WriteConsole.WriteStockStatusUpdatedEvent(context.Message.EventInfo, "NotificationService - StockStatusUpdatedEventConsumer");
        }
    }
}
