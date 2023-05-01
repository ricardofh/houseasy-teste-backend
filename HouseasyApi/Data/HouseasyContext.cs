using HouseasyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseasyApi.Data
{
    public class HouseasyContext : DbContext 
    {
        public HouseasyContext(DbContextOptions<HouseasyContext> opts) : base(opts) { 
        
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Ocupation> Ocupation { get; set; }


    }
}
