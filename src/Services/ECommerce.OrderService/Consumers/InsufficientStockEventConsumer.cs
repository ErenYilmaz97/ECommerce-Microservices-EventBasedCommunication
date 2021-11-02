using ECommerce.EventPrrocessor.Events.StockServiceEvents;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.OrderService.Consumers
{
    public class InsufficientStockEventConsumer : IConsumer<InsufficientStockEvent>
    {
        public async Task Consume(ConsumeContext<InsufficientStockEvent> context)
        {
            //Ürün stoklarının olmaması durumu. Siparişi iptal et, ödemeyi iade et
        }
    }
}
