using Microsoft.EntityFrameworkCore;
using Notes.Models;

namespace Notes.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }
        public DbSet<Noting> NotesLists { get; set; }
    }
}
