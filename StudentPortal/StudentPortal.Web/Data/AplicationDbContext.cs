using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Models.Entities;
namespace StudentPortal.Web.Data
{
    public class AplicationDbContext: DbContext 
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) 
        { 

        }
        public DbSet <Student> Students { get; set; }
    }
}
