using ECommerce.EventPrrocessor.EventOutputMethods;
using ECommerce.EventPrrocessor.Events.PaymentServiceEvents;
using ECommerce.EventPrrocessor.Events.StockServiceEvents;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.StockService.Consumers
{
    public class PaymentReceivedEventConsumer : IConsumer<PaymentReceivedEvent>
    {
        private readonly ProductDbContext _context;

        public PaymentReceivedEventConsumer(ProductDbContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<PaymentReceivedEvent> context)
        {
            WriteConsole.WritePaymentReceivedEvent(context.Message.EventInfo, "StockService - PaymentReceivedEventConsumer");

            //Gelen ürün bilgilerine göre stok güncellemeleri yapılır.
            //Stok güncelleme işlemi başarılı sonuçlanırsa, StockStatusUpdated eventi fırlatılır.
            //Eğer Stokta olmayan bir ürün geldiyse, müşteri stokta olmayan ürünü sipariş etmiş demektir.
            //Ödeme iadesi yapılır, sipariş iptal edilir.

            try
            {
                foreach (var item in context.Message.EventInfo.ProductIdsAndQuantities)
                {
                    var product = _context.Product.FirstOrDefault(x => x.Id == item.Key);

                    if (product == null || product.Stock <= 0)
                        throw new ApplicationException();

                    product.Stock = product.Stock - item.Value;   
                }

                _context.SaveChanges();

                StockStatusUpdatedEvent stockStatusUpdatedEvent = new()
                {
                    EventInfo = new()
                    {
                        OrderId = context.Message.EventInfo.OrderId
                    }
                };

                context.Publish<StockStatusUpdatedEvent>(stockStatusUpdatedEvent);
            }
            catch (Exception)
            {
                //Stok güncelleme işlemi başarısız. Ödemeyi iade et siparişi iptal et
                RefundPaymentEvent refundPaymentEvent = new()
                {
                    EventInfo = new()
                    {
                        OrderId = context.Message.EventInfo.OrderId
                    }
                };

                context.Publish<RefundPaymentEvent>(refundPaymentEvent);
            }
            
        }
    }
}
