using Microsoft.EntityFrameworkCore;
using OnlineBankApplication.Models;

namespace OnlineBankApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

    }
}
