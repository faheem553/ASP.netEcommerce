using CRUDinASP.netCoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDinASP.netCoreMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Products1> products1s { get; set; }
    }
}
