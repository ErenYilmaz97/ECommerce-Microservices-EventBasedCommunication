using ECommerce.EventPrrocessor.EventOutputMethods;
using ECommerce.EventPrrocessor.Events.OrderServiceEvents;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.OrderService.Consumers
{
    public class CancelOrderEventConsumer : IConsumer<CancelOrderEvent>
    {
        private readonly OrderDbContext _context;

        public CancelOrderEventConsumer(OrderDbContext context)
        {
            _context = context;
        }


        public async Task Consume(ConsumeContext<CancelOrderEvent> context)
        {
            WriteConsole.WriteCancelOrderEvent(context.Message.EventInfo, "OrderService - CancelOrderEventConsumer");

            var order = _context.Orders.FirstOrDefault(x => x.Id == context.Message.EventInfo.OrderId);
            order.Status = 3;

            _context.SaveChanges();
        }
    }
}
