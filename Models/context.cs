using Microsoft.EntityFrameworkCore;

namespace Bright_Ideas.Models
{
    public class Bright_IdeasPlannerContext : DbContext 
    {
        public Bright_IdeasPlannerContext(DbContextOptions<Bright_IdeasPlannerContext> options): base(options){}

        public DbSet<User> User {get;set;}
        public DbSet<Like> Like {get;set;}
        public DbSet<Post> Post {get;set;}
    }
}