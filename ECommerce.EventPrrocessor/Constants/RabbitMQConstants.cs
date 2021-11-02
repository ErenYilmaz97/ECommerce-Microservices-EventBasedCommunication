using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EventPrrocessor.Constants
{
    public static class RabbitMQConstants
    {
        public static string RabbitMqUri = "rabbitmq://localhost/ECommerceCommunication/";
        public static string UserName = "guest";
        public static string Password = "guest";
        public const string OrderServiceEventQueue = "order-service-events-queue";
        public const string PaymentServiceEventQueue = "payment-service-events-queue";
        public const string StockServiceEventQueue = "stock-service-events-queue";
        public const string NotificationServiceEventQueue = "notification-service-events-queue";
    }
}
