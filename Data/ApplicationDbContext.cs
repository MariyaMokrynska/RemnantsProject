using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RemnantsProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        //table
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<SurfaceType> SurfaceTypes { get; set; }
        public DbSet<Slab> Slabs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(new User[] { new User {Id=1, PhoneNumber = "407-111-1111", Password = "1111", FirstName = "Mariya", LastName = "Mokrynska", Role = Data.Roles.ADMIN} });
        }
    }
}