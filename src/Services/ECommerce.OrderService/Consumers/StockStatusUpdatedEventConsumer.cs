using ECommerce.EventPrrocessor.EventOutputMethods;
using ECommerce.EventPrrocessor.Events.StockServiceEvents;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.OrderService.Consumers
{
    public class StockStatusUpdatedEventConsumer : IConsumer<StockStatusUpdatedEvent>
    {
        public async Task Consume(ConsumeContext<StockStatusUpdatedEvent> context)
        {
            WriteConsole.WriteStockStatusUpdatedEvent(context.Message.EventInfo, "OrderService - StockStatusUpdatedEventConsumer");

            //Siparişi başarılı olarak güncelle
        }
    }
}
