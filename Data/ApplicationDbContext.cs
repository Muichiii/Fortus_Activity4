using Microsoft.EntityFrameworkCore;
using Fortus_Activity4.Models.Entities;

namespace Fortus_Activity4.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Game> Games { get; set; }
    }
}
