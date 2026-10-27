//Imports EF Core types such as DbContext and DbSet
using Microsoft.EntityFrameworkCore;
//Makes your domain model classes available in this file
using VisitorTracker.Models;
namespace VisitorTracker.Data
{
    public class ApplicationDbContext : DbContext // Represents the database context inheriting EF Core's base class
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) // Constructor that accepts options and passes them to the base class
        {
        }
      
        public DbSet<Visitor> Visitors { get; set; } // Represents the Visitors table in the database
        public DbSet<Employee> Employees { get; set; } // Represents the Employees table in the database
        public DbSet<Visit> Visits { get; set; } // Represents the Visits table in the database
    }
}
