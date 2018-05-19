using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using BookMng.Models;
using System.Collections.Generic;

namespace BookMng.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public bool Gender { get; set; }

        public bool Administrator { get; set; }

        public virtual List<Book> Books { get; set; }

        public virtual List<Remark> Remarks { get; set; }

        public virtual List<Borrow> Borrows { get; set; }
        public string Account { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // 请注意，authenticationType 必须与 CookieAuthenticationOptions.AuthenticationType 中定义的相应项匹配
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // 在此处添加自定义用户声明
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasOptional(o => o.ApplicationUser).WithMany(p => p.Books);
            modelBuilder.Entity<Book>().HasMany(o => o.Borrows).WithRequired(b => b.Book);
            modelBuilder.Entity<Book>().HasMany(o => o.Remarks).WithRequired(b => b.Book);

            modelBuilder.Entity<ApplicationUser>().HasMany(o => o.Remarks).WithRequired(r => r.People);
            modelBuilder.Entity<ApplicationUser>().HasMany(o => o.Books);
            modelBuilder.Entity<ApplicationUser>().HasMany(o => o.Borrows).WithRequired(r => r.ApplicationUser);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Borrow> Borrow { get; set; }

        public virtual DbSet<Remark> Remarks { get; set; }
    }
}