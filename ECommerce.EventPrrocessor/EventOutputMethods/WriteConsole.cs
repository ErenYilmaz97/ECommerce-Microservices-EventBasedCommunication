using ECommerce.EventPrrocessor.EventInfoObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EventPrrocessor.EventOutputMethods
{
    public static class WriteConsole
    {
        public static void WriteNewOrderCreated(NewOrderCreatedEventInfo eventInfo, string consumerName)
        {
            System.Diagnostics.Debug.WriteLine("****************************************************************************");
            System.Diagnostics.Debug.WriteLine($"{consumerName}");
            System.Diagnostics.Debug.WriteLine("Yeni Sipariş Oluşturuldu Eventi Yakalandı.");
            System.Diagnostics.Debug.WriteLine($"Sipariş No : {eventInfo.OrderId}");
            System.Diagnostics.Debug.WriteLine($"Kart Sahibi : {eventInfo.CardOwnerName}");
            System.Diagnostics.Debug.WriteLine($"Kart Numarası : {eventInfo.CardNumber}");
            System.Diagnostics.Debug.WriteLine($"Kart Tarihi : {eventInfo.CardDate}");
            System.Diagnostics.Debug.WriteLine($"Kart Güvenlik Kodu : {eventInfo.CardSecurityCode}");

            foreach (var item in eventInfo.ProductIdsAndQuantities)
            {
                System.Diagnostics.Debug.WriteLine($"Ürün No : {item.Key} / Ürün Adeti : {item.Value}");
            }

            System.Diagnostics.Debug.WriteLine("****************************************************************************");
        }



        public static void WritePaymentReceivedEvent(PaymentReceivedEventInfo eventInfo, string consumerName)
        {
            System.Diagnostics.Debug.WriteLine("****************************************************************************");
            System.Diagnostics.Debug.WriteLine($"{consumerName}");
            System.Diagnostics.Debug.WriteLine("Ödeme Alındı Eventi Yakalandı.");
            System.Diagnostics.Debug.WriteLine($"Sipariş No : {eventInfo.OrderId}");

            foreach (var item in eventInfo.ProductIdsAndQuantities)
            {
                System.Diagnostics.Debug.WriteLine($"Ürün No : {item.Key} / Ürün Adeti : {item.Value}");
            }

            System.Diagnostics.Debug.WriteLine("****************************************************************************");
        }



        public static void WriteStockStatusUpdatedEvent(StockStatusUpdatedEventInfo eventInfo, string consumerName)
        {
            System.Diagnostics.Debug.WriteLine("****************************************************************************");
            System.Diagnostics.Debug.WriteLine($"{consumerName}");
            System.Diagnostics.Debug.WriteLine("Stok Bigisi GÜncellendi Eventi Yakalandı.");
            System.Diagnostics.Debug.WriteLine($"Sipariş No : {eventInfo.OrderId}");
            System.Diagnostics.Debug.WriteLine("****************************************************************************");
        }



        public static void WriteRefundPaymentEvent(RefundPaymentEventInfo eventInfo, string consumerName)
        {
            System.Diagnostics.Debug.WriteLine("****************************************************************************");
            System.Diagnostics.Debug.WriteLine($"{consumerName}");
            System.Diagnostics.Debug.WriteLine("Ödeme İade Eventi Yakalandı.");
            System.Diagnostics.Debug.WriteLine($"Sipariş No : {eventInfo.OrderId}");
            System.Diagnostics.Debug.WriteLine("****************************************************************************");
        }



        public static void WriteCancelOrderEvent(CancelOrderEventInfo eventInfo, string consumerName)
        {
            System.Diagnostics.Debug.WriteLine("****************************************************************************");
            System.Diagnostics.Debug.WriteLine($"{consumerName}");
            System.Diagnostics.Debug.WriteLine("Sipariş İptal Eventi Yakalandı.");
            System.Diagnostics.Debug.WriteLine($"Sipariş No : {eventInfo.OrderId}");
            System.Diagnostics.Debug.WriteLine("****************************************************************************");
        }
    }
}
