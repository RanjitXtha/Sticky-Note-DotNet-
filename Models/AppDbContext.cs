using Microsoft.EntityFrameworkCore;

namespace StickyNote.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Note> Notes { get; set; }
    }
}
