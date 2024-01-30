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
    }
}
