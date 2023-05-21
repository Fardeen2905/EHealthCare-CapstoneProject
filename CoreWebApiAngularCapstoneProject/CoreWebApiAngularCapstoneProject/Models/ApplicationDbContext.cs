using Microsoft.EntityFrameworkCore;

namespace CoreWebApiAngularCapstoneProject.Models
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Medicine> Medicines { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Cart> Carts { get; set; }

        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseSqlServer("Server=HSC-PG02B5AZ\\SQLEXPRESS;Database=StoredProcedureDB;Integrated Security=true;TrustServerCertificate=true");
         }*/

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
