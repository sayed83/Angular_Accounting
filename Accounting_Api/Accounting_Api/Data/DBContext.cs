using Accounting_Api.Models.Admin;
using Accounting_Api.Models.BankCard;
using Accounting_Api.Models.Inspactions;
using Microsoft.EntityFrameworkCore;

namespace Accounting_Api.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<Company> Companies => Set<Company>();
        public DbSet<InspactionType> InspactionTypes => Set<InspactionType>();
        public DbSet<Inspaction> Inspactions => Set<Inspaction>();
        public DbSet<Status> Statuses => Set<Status>();
        public DbSet<Card> Cards => Set<Card>();
    }
}
