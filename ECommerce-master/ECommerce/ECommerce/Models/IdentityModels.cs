using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ECommerce.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public  DbSet<AdminUser> AdminUsers { get; set; }
        public  DbSet<Archieve> Archieves { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public  DbSet<Category> Categories { get; set; }
        public  DbSet<City> Cities { get; set; }
        public  DbSet<CloseType> CloseTypes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public  DbSet<Condition> Conditions { get; set; }
        public  DbSet<Country> Countries { get; set; }
        public DbSet<LogInHistory> LogInHistories { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductClose> ProductCloses { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductLike> ProductLikes { get; set; }
        public DbSet<ProductRating> ProductRatings { get; set; }
        public DbSet<ProductVerified> ProductVerifieds { get; set; }
        public DbSet<Users> Userses { get; set; }
        public DbSet<UserVerified> UserVerifieds { get; set; }

        //public DbSet<VwNonVerifieds> VwNonVerifiedses { get; set; }
        //public DbSet<VwVerifieds> VwVerifieds { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected void onModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove(new PluralizingTableNameConvention());
        }

        public System.Data.Entity.DbSet<ECommerce.Models.LoginModel> LoginModels { get; set; }


    }
}