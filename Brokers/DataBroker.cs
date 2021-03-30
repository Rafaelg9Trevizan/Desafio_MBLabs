using Microsoft.EntityFrameworkCore;
using g9events.Models;

namespace g9events.Api.Brokers
{
    public class DataBroker : DbContext
    {
        public DataBroker(DbContextOptions<DataBroker> options)
            :base(options)
            {
            }

        public DbSet<Institution> Institutions { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<CreditCard> CreditCards { get; set;}

        public DbSet<Event> Events { get; set;}

        public DbSet<Ticket> Tickets { get; set;}
    }
}