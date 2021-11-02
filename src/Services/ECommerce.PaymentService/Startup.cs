using ECommerce.EventPrrocessor.Constants;
using ECommerce.PaymentService.Consumers;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.PaymentService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<PaymentDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));
            services.AddControllers();

            services.AddMassTransit(x =>

            {
                x.AddConsumer<NewOrderCreatedEventConsumer>();
                x.AddConsumer<RefundPaymentEventConsumer>();


                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(RabbitMQConstants.RabbitMqUri, host =>
                    {
                        host.Username(RabbitMQConstants.UserName);
                        host.Password(RabbitMQConstants.Password);
                    });

                    cfg.ReceiveEndpoint(RabbitMQConstants.PaymentServiceEventQueue, e =>
                    {
                        e.ConfigureConsumer<RefundPaymentEventConsumer>(context);
                        e.ConfigureConsumer<NewOrderCreatedEventConsumer>(context);
                    });
                });
            });

            services.AddMassTransitHostedService();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ECommerce.PaymentService", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ECommerce.PaymentService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
