using ECommerce.EventPrrocessor.EventOutputMethods;
using ECommerce.EventPrrocessor.Events.OrderServiceEvents;
using ECommerce.EventPrrocessor.Events.PaymentServiceEvents;
using ECommerce.PaymentService.Entities;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.PaymentService.Consumers
{
    public class NewOrderCreatedEventConsumer : IConsumer<NewOrderCreatedEvent>
    {
        private readonly PaymentDbContext _context;

        public NewOrderCreatedEventConsumer(PaymentDbContext context)
        {
            _context = context;
        }


        public async Task Consume(ConsumeContext<NewOrderCreatedEvent> context)
        {
            WriteConsole.WriteNewOrderCreated(context.Message.EventInfo, "PaymentService - NewOrderCreatedEventConsumer");

            //Yeni Oluşturulan Sipariş için, ödeme işlemi gerçekleştirilir.
            //İşlem tamamlandıktan sonra, PaymentReceived eventi fırlatıyoruz.

            Payment payment = new()
            {
                PaymentDate = DateTime.Now,
                OrderId = context.Message.EventInfo.OrderId,
                CardOwner = context.Message.EventInfo.CardOwnerName,
                CardNumber = context.Message.EventInfo.CardNumber,
                CardDate = context.Message.EventInfo.CardDate,
                CardSecurityCode = context.Message.EventInfo.CardSecurityCode,
                IsSuccess = true,
                PaymentType = 1
            };

            _context.Payments.Add(payment);
            _context.SaveChanges();

            PaymentReceivedEvent paymentReceivedEvent = new()
            {
                EventInfo = new()
                {
                    OrderId = context.Message.EventInfo.OrderId,
                    ProductIdsAndQuantities = context.Message.EventInfo.ProductIdsAndQuantities
                }
            };

            context.Publish<PaymentReceivedEvent>(paymentReceivedEvent);


        }
    }
}
