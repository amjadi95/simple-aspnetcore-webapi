using Microsoft.EntityFrameworkCore;
using ApiServer.Models;
namespace ApiServer.Data
{
    public class AppDbContext : DbContext 
    {
        public DbSet<Student> Students {get;set;}
        public AppDbContext(DbContextOptions<AppDbContext> opt): base(opt)
        {
            
        }
       
    }
}