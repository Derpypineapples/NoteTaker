using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace NoteTaker.Models
{
    public class NoteContext : DbContext
    {
        public NoteContext() { }
        public NoteContext(DbContextOptions<NoteContext> options)
            : base(options)
        { }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<NoteContext>(
                options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=NoteDB");
        }

        public DbSet<Note> Notes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().HasData(
                new Note
                {
                    NoteID = 1,
                    Name = "Note 1",
                    Content = "Contents of Note 1"
                },
                new Note
                {
                    NoteID = 2,
                    Name = "Note 2",
                    Content = "Contents of Note 2"
                },
                new Note
                {
                    NoteID = 3,
                    Name = "Note 3",
                    Content = "Contents of Note 3"
                }
            );
        }
    }
}