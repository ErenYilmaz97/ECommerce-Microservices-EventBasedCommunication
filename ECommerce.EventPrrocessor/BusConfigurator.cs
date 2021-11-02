using ECommerce.EventPrrocessor.Constants;
using MassTransit;
using MassTransit.RabbitMqTransport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EventPrrocessor
{
    public static class BusConfigurator
    {
        public static IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator> configAction = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(factory =>
            {
                factory.Host(RabbitMQConstants.RabbitMqUri, cfg =>
                {
                    cfg.Username(RabbitMQConstants.UserName);
                    cfg.Password(RabbitMQConstants.Password);
                });

                configAction?.Invoke(factory);
            });
        }
    }
}
