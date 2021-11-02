using ECommerce.EventPrrocessor.Constants;
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
    public class RefundPaymentEventConsumer : IConsumer<RefundPaymentEvent>
    {

        private readonly PaymentDbContext _context;

        public RefundPaymentEventConsumer(PaymentDbContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<RefundPaymentEvent> context)
        {
            WriteConsole.WriteRefundPaymentEvent(context.Message.EventInfo, "PaymentService - RefundPaymentEventConsumer");

            var payment = _context.Payments.FirstOrDefault(x => x.OrderId == context.Message.EventInfo.OrderId);

            Payment paymentRefund = new()
            {
                PaymentDate = DateTime.Now,
                OrderId = payment.OrderId,
                CardOwner = payment.CardOwner,
                CardNumber = payment.CardNumber,
                CardDate = payment.CardDate,
                CardSecurityCode = payment.CardSecurityCode,
                IsSuccess = true,
                PaymentType = 2
            };

            //Ödemeyi iade et
            _context.Payments.Add(paymentRefund);
            _context.SaveChanges();

           
            CancelOrderEvent cancelOrderEvent = new()
            {
                EventInfo = new()
                {
                    OrderId = context.Message.EventInfo.OrderId
                }
            };

            //Siparişi iptal et
            context.Publish<CancelOrderEvent>(cancelOrderEvent);
        }
    }
}
