using ECommerce.PaymentService.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.PaymentService
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> dbContextOptions):base(dbContextOptions)
        {

        }


        public DbSet<Payment> Payments { get; set; }
    }
}
