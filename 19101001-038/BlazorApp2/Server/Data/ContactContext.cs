using Microsoft.EntityFrameworkCore;
using BlazorApp2.Shared;

namespace BlazorApp2.Server.Data
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {

        }
        public DbSet<ContactUs> contact { get; set; }
    }
}
