using Microsoft.EntityFrameworkCore;
using Nguyen_Duong_The_Vi.Models;

namespace Nguyen_Duong_The_Vi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {



        }
        public DbSet<ThongTin> thongTins { get; set; }
        public DbSet<Post> posts { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<PostCategory> postCategories { get; set; }
        public DbSet<User> users { get; set; }

        public DbSet<Contact> contacts { get; set; }
        public DbSet<ContactAll> contactalls { get; set; }
    }
}
