namespace LibAPI;

using Microsoft.EntityFrameworkCore;

public class LibContext : DbContext
{
    public LibContext(DbContextOptions<LibContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<UserBook> UserBooks {get; set; }
    public DbSet<ExchangeDataForm> ExchangeForms { get; set; }
    public DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(u => u.UserID);
        modelBuilder.Entity<Book>().HasKey(b => b.ID);
        modelBuilder.Entity<UserBook>().HasKey(b => new {b.UserID, b.BookID});
        modelBuilder.Entity<ExchangeDataForm>().HasKey(e => e.ExchangeID);
        modelBuilder.Entity<Review>().HasKey(r => r.ReviewID);
        
    }
}