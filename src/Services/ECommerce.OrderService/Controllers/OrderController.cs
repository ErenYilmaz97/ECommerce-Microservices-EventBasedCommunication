using ECommerce.EventPrrocessor.Events.OrderServiceEvents;
using ECommerce.OrderService.Entities;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpointProvider;
        private readonly OrderDbContext _context;

        public OrderController(IPublishEndpoint publishEndpointProvider, OrderDbContext context)
        {
            _publishEndpointProvider = publishEndpointProvider;
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> CreateNewOrder(CreateNewOrderRequest request)
        {
            //Sipariş oluşturuldu. NewOrderCreated event fırlatıyoruz.
            var orderItems = new List<OrderItem>()
            {
                new OrderItem(){ProductId = 4, ProductName = "Product1", ProductPrice = 1599.99M, Quantity =1},
                new OrderItem(){ProductId = 5, ProductName = "Product2", ProductPrice = 3999.99M, Quantity =3},
                new OrderItem(){ProductId = 6, ProductName = "Product3", ProductPrice = 9999.99M, Quantity =1}
            };

            var order = new Order()
            {
                UserId = 12312312,
                CreatedDate = DateTime.Now,
                OrderItems = orderItems,
                Status = 1
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            NewOrderCreatedEvent orderCreatedEvent = new()
            {
                EventInfo = new()
                {
                    CardOwnerName = request.CardOwnerName,
                    CardNumber = request.CardNumber,
                    CardDate = request.CardDate,
                    CardSecurityCode = request.CardSecurityCode,

                    OrderId = order.Id,

                    ProductIdsAndQuantities = new Dictionary<int, int>(new List<KeyValuePair<int, int>>() 
                    { 
                        new KeyValuePair<int, int>(4,1),
                        new KeyValuePair<int, int>(5,3),
                        new KeyValuePair<int, int>(6,1),
                    })  
                }
            };


            await _publishEndpointProvider.Publish<NewOrderCreatedEvent>(orderCreatedEvent);

            return Ok("Sipariş Başarıyla Oluşturuldu.");


        }

    }
}
