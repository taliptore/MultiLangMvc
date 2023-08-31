using Microsoft.EntityFrameworkCore;

namespace MultiLangMvc.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContext) : base(dbContext)
        { }
        public DbSet<Language>   Languages { get; set; }
        public DbSet<StringResource>    StringResources { get; set; }
    }
}
